namespace net.willshouse.HogKeys.UI
{
    partial class SwitchStatusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridStatus = new System.Windows.Forms.DataGridView();
            this.switchMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.binaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pollOnceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pollingStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.startPollingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopPollingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.inputStatusTabPage = new System.Windows.Forms.TabPage();
            this.setupTabPage = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Timers.Timer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pollingIntervalTrackBar = new System.Windows.Forms.TrackBar();
            this.PollingIntervalLabel = new System.Windows.Forms.Label();
            this.pollingIntervalTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatus)).BeginInit();
            this.switchMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.inputStatusTabPage.SuspendLayout();
            this.setupTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollingIntervalTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // gridStatus
            // 
            this.gridStatus.AllowUserToAddRows = false;
            this.gridStatus.AllowUserToDeleteRows = false;
            this.gridStatus.AllowUserToOrderColumns = true;
            this.gridStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStatus.Location = new System.Drawing.Point(3, 3);
            this.gridStatus.Name = "gridStatus";
            this.gridStatus.ReadOnly = true;
            this.gridStatus.RowHeadersVisible = false;
            this.gridStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridStatus.Size = new System.Drawing.Size(578, 495);
            this.gridStatus.TabIndex = 0;
            this.gridStatus.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridStatus_CellDoubleClick);
            // 
            // switchMenu
            // 
            this.switchMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.deviceToolStripMenuItem});
            this.switchMenu.Location = new System.Drawing.Point(0, 0);
            this.switchMenu.Name = "switchMenu";
            this.switchMenu.Size = new System.Drawing.Size(592, 24);
            this.switchMenu.TabIndex = 4;
            this.switchMenu.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.newToolStripMenuItem1,
            this.saveToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchToolStripMenuItem});
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem1.Text = "New";
            // 
            // switchToolStripMenuItem
            // 
            this.switchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchToolStripMenuItem1});
            this.switchToolStripMenuItem.Name = "switchToolStripMenuItem";
            this.switchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.switchToolStripMenuItem.Text = "Input";
            // 
            // switchToolStripMenuItem1
            // 
            this.switchToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.binaryToolStripMenuItem,
            this.multiPositionToolStripMenuItem,
            this.toggleToolStripMenuItem});
            this.switchToolStripMenuItem1.Name = "switchToolStripMenuItem1";
            this.switchToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.switchToolStripMenuItem1.Text = "Switch";
            // 
            // binaryToolStripMenuItem
            // 
            this.binaryToolStripMenuItem.Name = "binaryToolStripMenuItem";
            this.binaryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.binaryToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.binaryToolStripMenuItem.Text = "BinarySwitch Switch";
            this.binaryToolStripMenuItem.Click += new System.EventHandler(this.binaryToolStripMenuItem_Click);
            // 
            // multiPositionToolStripMenuItem
            // 
            this.multiPositionToolStripMenuItem.Name = "multiPositionToolStripMenuItem";
            this.multiPositionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.multiPositionToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.multiPositionToolStripMenuItem.Text = "MultiSwitch-Position Switch";
            this.multiPositionToolStripMenuItem.Click += new System.EventHandler(this.multiPositionToolStripMenuItem_Click);
            // 
            // toggleToolStripMenuItem
            // 
            this.toggleToolStripMenuItem.Name = "toggleToolStripMenuItem";
            this.toggleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.toggleToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.toggleToolStripMenuItem.Text = "ToggleSwitch Switch";
            this.toggleToolStripMenuItem.Click += new System.EventHandler(this.toggleToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pollOnceToolStripMenuItem,
            this.startPollingToolStripMenuItem,
            this.stopPollingToolStripMenuItem});
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.deviceToolStripMenuItem.Text = "Device";
            // 
            // pollOnceToolStripMenuItem
            // 
            this.pollOnceToolStripMenuItem.Name = "pollOnceToolStripMenuItem";
            this.pollOnceToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.pollOnceToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.pollOnceToolStripMenuItem.Text = "Poll Once";
            this.pollOnceToolStripMenuItem.Click += new System.EventHandler(this.pollOnceToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pollingStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(592, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // pollingStatusLabel
            // 
            this.pollingStatusLabel.Name = "pollingStatusLabel";
            this.pollingStatusLabel.Size = new System.Drawing.Size(68, 17);
            this.pollingStatusLabel.Text = "Polling:OFF";
            // 
            // startPollingToolStripMenuItem
            // 
            this.startPollingToolStripMenuItem.Name = "startPollingToolStripMenuItem";
            this.startPollingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.startPollingToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.startPollingToolStripMenuItem.Text = "Start Polling";
            this.startPollingToolStripMenuItem.Click += new System.EventHandler(this.startPollingToolStripMenuItem_Click);
            // 
            // stopPollingToolStripMenuItem
            // 
            this.stopPollingToolStripMenuItem.Enabled = false;
            this.stopPollingToolStripMenuItem.Name = "stopPollingToolStripMenuItem";
            this.stopPollingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.stopPollingToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.stopPollingToolStripMenuItem.Text = "Stop Polling";
            this.stopPollingToolStripMenuItem.Click += new System.EventHandler(this.stopPollingToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.inputStatusTabPage);
            this.tabControl1.Controls.Add(this.setupTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(592, 527);
            this.tabControl1.TabIndex = 6;
            // 
            // inputStatusTabPage
            // 
            this.inputStatusTabPage.Controls.Add(this.gridStatus);
            this.inputStatusTabPage.Location = new System.Drawing.Point(4, 22);
            this.inputStatusTabPage.Name = "inputStatusTabPage";
            this.inputStatusTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.inputStatusTabPage.Size = new System.Drawing.Size(584, 501);
            this.inputStatusTabPage.TabIndex = 0;
            this.inputStatusTabPage.Text = "Input Status";
            this.inputStatusTabPage.UseVisualStyleBackColor = true;
            // 
            // setupTabPage
            // 
            this.setupTabPage.Controls.Add(this.groupBox1);
            this.setupTabPage.Location = new System.Drawing.Point(4, 22);
            this.setupTabPage.Name = "setupTabPage";
            this.setupTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.setupTabPage.Size = new System.Drawing.Size(584, 501);
            this.setupTabPage.TabIndex = 1;
            this.setupTabPage.Text = "Setup";
            this.setupTabPage.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.SynchronizingObject = this;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PollingIntervalLabel);
            this.groupBox1.Controls.Add(this.pollingIntervalTextBox);
            this.groupBox1.Controls.Add(this.pollingIntervalTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(8, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Polling Interval";
            // 
            // pollingIntervalTrackBar
            // 
            this.pollingIntervalTrackBar.Location = new System.Drawing.Point(39, 70);
            this.pollingIntervalTrackBar.Maximum = 50;
            this.pollingIntervalTrackBar.Minimum = 1;
            this.pollingIntervalTrackBar.Name = "pollingIntervalTrackBar";
            this.pollingIntervalTrackBar.Size = new System.Drawing.Size(104, 45);
            this.pollingIntervalTrackBar.TabIndex = 0;
            this.pollingIntervalTrackBar.TickFrequency = 5;
            this.pollingIntervalTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.pollingIntervalTrackBar.Value = 25;
            this.pollingIntervalTrackBar.Scroll += new System.EventHandler(this.pollingIntervalTrackBar_Scroll);
            // 
            // PollingIntervalLabel
            // 
            this.PollingIntervalLabel.AutoSize = true;
            this.PollingIntervalLabel.Location = new System.Drawing.Point(80, 33);
            this.PollingIntervalLabel.Name = "PollingIntervalLabel";
            this.PollingIntervalLabel.Size = new System.Drawing.Size(63, 13);
            this.PollingIntervalLabel.TabIndex = 6;
            this.PollingIntervalLabel.Text = "Per Second";
            // 
            // pollingIntervalTextBox
            // 
            this.pollingIntervalTextBox.Location = new System.Drawing.Point(39, 30);
            this.pollingIntervalTextBox.Name = "pollingIntervalTextBox";
            this.pollingIntervalTextBox.ReadOnly = true;
            this.pollingIntervalTextBox.Size = new System.Drawing.Size(40, 20);
            this.pollingIntervalTextBox.TabIndex = 7;
            // 
            // SwitchStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 573);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.switchMenu);
            this.MainMenuStrip = this.switchMenu;
            this.Name = "SwitchStatusForm";
            this.Text = "SwitchStatus";
            this.Load += new System.EventHandler(this.SwitchStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridStatus)).EndInit();
            this.switchMenu.ResumeLayout(false);
            this.switchMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.inputStatusTabPage.ResumeLayout(false);
            this.setupTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pollingIntervalTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridStatus;
        private System.Windows.Forms.MenuStrip switchMenu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem switchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem switchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem binaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pollOnceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startPollingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopPollingToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel pollingStatusLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage inputStatusTabPage;
        private System.Windows.Forms.TabPage setupTabPage;
        private System.Timers.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label PollingIntervalLabel;
        private System.Windows.Forms.TextBox pollingIntervalTextBox;
        private System.Windows.Forms.TrackBar pollingIntervalTrackBar;
    }
}

