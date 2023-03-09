namespace ProcessManipulation
{
    partial class ProcessManipulationForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listAvailableAssemblies = new System.Windows.Forms.ListBox();
            this.listStartedAssemblies = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnCloseWindow = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRunNotepad = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listAvailableAssemblies
            // 
            this.listAvailableAssemblies.FormattingEnabled = true;
            this.listAvailableAssemblies.Location = new System.Drawing.Point(6, 19);
            this.listAvailableAssemblies.Name = "listAvailableAssemblies";
            this.listAvailableAssemblies.Size = new System.Drawing.Size(279, 407);
            this.listAvailableAssemblies.TabIndex = 0;
            this.listAvailableAssemblies.SelectedIndexChanged += new System.EventHandler(this.ListAvailableAssemblies_SelectedIndexChanged);
            // 
            // listStartedAssemblies
            // 
            this.listStartedAssemblies.FormattingEnabled = true;
            this.listStartedAssemblies.Location = new System.Drawing.Point(6, 19);
            this.listStartedAssemblies.Name = "listStartedAssemblies";
            this.listStartedAssemblies.Size = new System.Drawing.Size(279, 407);
            this.listStartedAssemblies.TabIndex = 1;
            this.listStartedAssemblies.SelectedIndexChanged += new System.EventHandler(this.ListStartedAssemblies_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listStartedAssemblies);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 432);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Запущенные процессы";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listAvailableAssemblies);
            this.groupBox2.Location = new System.Drawing.Point(497, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 432);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Доступные сборки";
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(367, 87);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.AutoSize = true;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(367, 116);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnCloseWindow
            // 
            this.btnCloseWindow.AutoSize = true;
            this.btnCloseWindow.Enabled = false;
            this.btnCloseWindow.Location = new System.Drawing.Point(362, 145);
            this.btnCloseWindow.Name = "btnCloseWindow";
            this.btnCloseWindow.Size = new System.Drawing.Size(85, 23);
            this.btnCloseWindow.TabIndex = 6;
            this.btnCloseWindow.Text = "Close Window";
            this.btnCloseWindow.UseVisualStyleBackColor = true;
            this.btnCloseWindow.Click += new System.EventHandler(this.BtnCloseWindow_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(367, 174);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnRunNotepad
            // 
            this.btnRunNotepad.AutoSize = true;
            this.btnRunNotepad.Location = new System.Drawing.Point(367, 203);
            this.btnRunNotepad.Name = "btnRunNotepad";
            this.btnRunNotepad.Size = new System.Drawing.Size(81, 23);
            this.btnRunNotepad.TabIndex = 8;
            this.btnRunNotepad.Text = "Run Notepad";
            this.btnRunNotepad.UseVisualStyleBackColor = true;
            this.btnRunNotepad.Click += new System.EventHandler(this.BtnRunNotepad_Click);
            // 
            // ProcessManipulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRunNotepad);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCloseWindow);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProcessManipulationForm";
            this.Text = "Управление дочерними процессами";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProcessManipulationForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listAvailableAssemblies;
        private System.Windows.Forms.ListBox listStartedAssemblies;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnCloseWindow;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRunNotepad;
    }
}

