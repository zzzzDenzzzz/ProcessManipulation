using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProcessManipulation
{
    // объявление делегата, принимающего параметр типа Process
    delegate void ProcessDelegate(Process proc);
    public partial class ProcessManipulationForm : Form
    {
        // константа, идентифицирующая сообщение WM_SETTEXT
        const uint WM_SETTEXT = 0x0c;

        // импортируем функцию SendMEssage из библиотеки user32.dll
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, uint msg, int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);

        // список, в котором будут храниться объекты, описывающие дочерние процессы приложения
        List<Process> Processes = new List<Process>();

        // счётчик запущенных процессов
        int Counter = 0;
        public ProcessManipulationForm()
        {
            InitializeComponent();
            LoadAvailableAssemblies();
        }

        // метод, загружающий доступные исполняемые файлы из домашней директории проекта
        void LoadAvailableAssemblies()
        {
            // название файла сборки текущего приложения
            string except = new FileInfo(Application.ExecutablePath).Name;
            // получаем название файла без расширения
            except = except.Substring(0, except.IndexOf("."));
            // получаем все *.exe файлы из домашней директории
            string[] files = Directory.GetFiles(Application.StartupPath, "*.exe");
            foreach (string file in files)
            {
                // получаем имя файла
                string fileName = new FileInfo(file).Name;

                // если имя файла не содержит имени исполняемого файла проекта, то оно добавляется в список
                if (fileName.IndexOf(except) == -1)
                    listAvailableAssemblies.Items.Add(fileName);
            }
        }

        // метод, запускающий процесс на исполнение и сохраняющий объект, который его описывает
        void RunProcess(string AssamblyName)
        {
            // запускаем процесс на основании исполняемого файла
            Process proc = Process.Start(AssamblyName);
            // добавляем процесс в список
            Processes.Add(proc);
            // проверяем, стал ли созданный процесс дочерним, по отношению к текущему и, если стал, выводим MessageBox
            if (Process.GetCurrentProcess().Id == GetParentProcessId(proc.Id))
                MessageBox.Show(proc.ProcessName + " действительно дочерний процесс текущего процесса!");

            // указываем, что процесс должен генерировать события
            proc.EnableRaisingEvents = true;
            // добавляем обработчик на событие завершения процесса
            CheckForIllegalCrossThreadCalls = false;
            proc.Exited += (sender, e) =>
            {
                Process pr = sender as Process;
                // убираем процесс из списка запущенных приложений
                listStartedAssemblies.Items.Remove(pr.ProcessName);
                // добавляем процесс в список доступных приложений
                listAvailableAssemblies.Items.Add(pr.ProcessName);
                // убираем процесс из списка дочерних процессов
                Processes.Remove(pr);
                // уменьшаем счётчик дочерних процессов на 1
                Counter--;
                int index = 0;
                // меняем текст для главных окон всех дочерних процессов
                foreach (var p in Processes)
                {
                    SetChildWindowText(p.MainWindowHandle, "Child process #" + ++index);
                }
            };

            // устанавливаем новый текст главному окну дочернего процесса
            SetChildWindowText(proc.MainWindowHandle, "Child process #" + (++Counter));
            // проверяем, запускали ли мы экземпляр такого приложения и, если нет, то добавляем в список запущенных приложений
            if (!listStartedAssemblies.Items.Contains(proc.ProcessName))
                listStartedAssemblies.Items.Add(proc.ProcessName);

            // убираем приложение из списка доступных приложений
            listAvailableAssemblies.Items.Remove(listAvailableAssemblies.SelectedItem);
        }

        // метод, получающий PID родительского процесса (использует WMI)
        int GetParentProcessId(int Id)
        {
            int parentId = 0;
            using (ManagementObject obj = new ManagementObject("win32_process.handle=" + Id.ToString()))
            {
                obj.Get();
                parentId = Convert.ToInt32(obj["ParentProcessId"]);
            }
            return parentId;
        }

        // метод обёртывания для отправки сообщения WM_SETTEXT
        void SetChildWindowText(IntPtr Handle, string text)
        {
            SendMessage(Handle, WM_SETTEXT, 0, text);
        }

        // метод, который выполняет проход по всем дочерним процессам с заданым именем и выполняющий для этих процессов заданый делегатом метод
        void ExecuteOnProcessesByName(string ProcessName, ProcessDelegate func)
        {
            // получаем список, запущенных в операционной системе процессов
            Process[] processes = Process.GetProcessesByName(ProcessName);

            foreach (var process in processes)
            {
                // если PID родительского процесса равен PID текущего процесса
                if (Process.GetCurrentProcess().Id == GetParentProcessId(process.Id))
                    // запускаем метод
                    func(process);
            }
        }

        // обработчик события нажатия на кнопку Start основного диалога
        void BtnStart_Click(object sender, EventArgs e) => RunProcess(listAvailableAssemblies.SelectedItem.ToString());

        // обработчик события нажатия на кнопку Stop основного диалога
        void BtnStop_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(listStartedAssemblies.SelectedItem.ToString(), (process) => process.Kill());
            listStartedAssemblies.Items.Remove(listStartedAssemblies.SelectedItem);
        }

        // обработчик события нажатия на кнопку CloseWindow основного диалога
        void BtnCloseWindow_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(listStartedAssemblies.SelectedItem.ToString(), (process) => process.CloseMainWindow());
            listStartedAssemblies.Items.Remove(listStartedAssemblies.SelectedItem);
        }

        // обработчик события нажатия на кнопку Refresh основного диалога
        void BtnRefresh_Click(object sender, EventArgs e)
        {
            ExecuteOnProcessesByName(listStartedAssemblies.SelectedItem.ToString(), (process) => process.Refresh());
        }

        // обработчик события изменения индекса выделенного элемента в списке доступных приложений
        void ListAvailableAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listAvailableAssemblies.SelectedItems.Count == 0)
                btnStart.Enabled = false;
            else
                btnStart.Enabled = true;
        }

        // обработчик события изменения индекса выделенного элемента в списке запущенных приложений
        void ListStartedAssemblies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listStartedAssemblies.SelectedItems.Count == 0)
            {
                btnStop.Enabled = false;
                btnStop.Enabled = false;
                btnCloseWindow.Enabled = false;
            }
            else
            {
                btnStop.Enabled = true;
                btnStop.Enabled = true;
                btnCloseWindow.Enabled = true;
            }
        }

        // обработчик события закрытия основного окна приложения
        void ProcessManipulationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var proc in Processes)
            {
                proc.Kill();
            }
        }

        // обработчик события нажатия на кнопку "Run Notepad"
        void BtnRunNotepad_Click(object sender, EventArgs e) => RunProcess("notepad.exe");
    }
}
