namespace net.willshouse.HogKeys.UI.controls
{
    partial class BinarySwitchPinManager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pinsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pinsPanel = new System.Windows.Forms.Panel();
            this.valuesLabel = new System.Windows.Forms.Label();
            this.PinsLabel = new System.Windows.Forms.Label();
            this.PinsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.valuesLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.switchTabControl = new System.Windows.Forms.TabControl();
            this.switchPinsTab = new System.Windows.Forms.TabPage();
            this.switchValuesTab = new System.Windows.Forms.TabPage();
            this.pinsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PinsNumericUpDown)).BeginInit();
            this.switchTabControl.SuspendLayout();
            this.switchPinsTab.SuspendLayout();
            this.switchValuesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // pinsFlowLayoutPanel
            // 
            this.pinsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pinsFlowLayoutPanel.Location = new System.Drawing.Point(0, 38);
            this.pinsFlowLayoutPanel.Name = "pinsFlowLayoutPanel";
            this.pinsFlowLayoutPanel.Size = new System.Drawing.Size(378, 83);
            this.pinsFlowLayoutPanel.TabIndex = 2;
            // 
            // pinsPanel
            // 
            this.pinsPanel.Controls.Add(this.valuesLabel);
            this.pinsPanel.Controls.Add(this.pinsFlowLayoutPanel);
            this.pinsPanel.Controls.Add(this.PinsLabel);
            this.pinsPanel.Controls.Add(this.PinsNumericUpDown);
            this.pinsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pinsPanel.Location = new System.Drawing.Point(3, 3);
            this.pinsPanel.Name = "pinsPanel";
            this.pinsPanel.Size = new System.Drawing.Size(378, 121);
            this.pinsPanel.TabIndex = 4;
            // 
            // valuesLabel
            // 
            this.valuesLabel.AutoSize = true;
            this.valuesLabel.Location = new System.Drawing.Point(276, 12);
            this.valuesLabel.Name = "valuesLabel";
            this.valuesLabel.Size = new System.Drawing.Size(35, 13);
            this.valuesLabel.TabIndex = 3;
            this.valuesLabel.Text = "label1";
            // 
            // PinsLabel
            // 
            this.PinsLabel.AutoSize = true;
            this.PinsLabel.Location = new System.Drawing.Point(137, 12);
            this.PinsLabel.Name = "PinsLabel";
            this.PinsLabel.Size = new System.Drawing.Size(82, 13);
            this.PinsLabel.TabIndex = 1;
            this.PinsLabel.Text = "Number of Pins:";
            // 
            // PinsNumericUpDown
            // 
            this.PinsNumericUpDown.Location = new System.Drawing.Point(219, 8);
            this.PinsNumericUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.PinsNumericUpDown.Name = "PinsNumericUpDown";
            this.PinsNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.PinsNumericUpDown.TabIndex = 0;
            this.PinsNumericUpDown.ValueChanged += new System.EventHandler(this.PinsNumericUpDown_ValueChanged);
            // 
            // valuesLayoutPanel
            // 
            this.valuesLayoutPanel.AutoScroll = true;
            this.valuesLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valuesLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.valuesLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.valuesLayoutPanel.Name = "valuesLayoutPanel";
            this.valuesLayoutPanel.Size = new System.Drawing.Size(378, 127);
            this.valuesLayoutPanel.TabIndex = 5;
            // 
            // switchTabControl
            // 
            this.switchTabControl.Controls.Add(this.switchPinsTab);
            this.switchTabControl.Controls.Add(this.switchValuesTab);
            this.switchTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchTabControl.Location = new System.Drawing.Point(0, 0);
            this.switchTabControl.Name = "switchTabControl";
            this.switchTabControl.Padding = new System.Drawing.Point(0, 0);
            this.switchTabControl.SelectedIndex = 0;
            this.switchTabControl.Size = new System.Drawing.Size(392, 159);
            this.switchTabControl.TabIndex = 7;
            // 
            // switchPinsTab
            // 
            this.switchPinsTab.Controls.Add(this.pinsPanel);
            this.switchPinsTab.Location = new System.Drawing.Point(4, 22);
            this.switchPinsTab.Name = "switchPinsTab";
            this.switchPinsTab.Padding = new System.Windows.Forms.Padding(3);
            this.switchPinsTab.Size = new System.Drawing.Size(384, 133);
            this.switchPinsTab.TabIndex = 1;
            this.switchPinsTab.Text = "Input Pins";
            this.switchPinsTab.UseVisualStyleBackColor = true;
            // 
            // switchValuesTab
            // 
            this.switchValuesTab.Controls.Add(this.valuesLayoutPanel);
            this.switchValuesTab.Location = new System.Drawing.Point(4, 22);
            this.switchValuesTab.Name = "switchValuesTab";
            this.switchValuesTab.Padding = new System.Windows.Forms.Padding(3);
            this.switchValuesTab.Size = new System.Drawing.Size(384, 133);
            this.switchValuesTab.TabIndex = 0;
            this.switchValuesTab.Text = "Input Values";
            this.switchValuesTab.UseVisualStyleBackColor = true;
            // 
            // BinarySwitchPinManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.switchTabControl);
            this.Name = "BinarySwitchPinManager";
            this.Size = new System.Drawing.Size(392, 159);
            this.pinsPanel.ResumeLayout(false);
            this.pinsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PinsNumericUpDown)).EndInit();
            this.switchTabControl.ResumeLayout(false);
            this.switchPinsTab.ResumeLayout(false);
            this.switchValuesTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pinsFlowLayoutPanel;
        private System.Windows.Forms.Panel pinsPanel;
        private System.Windows.Forms.Label PinsLabel;
        private System.Windows.Forms.NumericUpDown PinsNumericUpDown;
        private System.Windows.Forms.FlowLayoutPanel valuesLayoutPanel;
        private System.Windows.Forms.TabControl switchTabControl;
        private System.Windows.Forms.TabPage switchValuesTab;
        private System.Windows.Forms.TabPage switchPinsTab;
        private System.Windows.Forms.Label valuesLabel;
    }
}
