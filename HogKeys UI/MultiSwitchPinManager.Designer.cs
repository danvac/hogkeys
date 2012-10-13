namespace net.willshouse.HogKeys.UI
{
    partial class MultiSwitchPinManager
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pinLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.positionsLabel = new System.Windows.Forms.Label();
            this.positionsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pinLayoutPanel);
            this.groupBox1.Controls.Add(this.positionsLabel);
            this.groupBox1.Controls.Add(this.positionsNumericUpDown);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // pinLayoutPanel
            // 
            this.pinLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pinLayoutPanel.Location = new System.Drawing.Point(3, 39);
            this.pinLayoutPanel.Name = "pinLayoutPanel";
            this.pinLayoutPanel.Size = new System.Drawing.Size(394, 158);
            this.pinLayoutPanel.TabIndex = 4;
            // 
            // positionsLabel
            // 
            this.positionsLabel.AutoSize = true;
            this.positionsLabel.Location = new System.Drawing.Point(130, 17);
            this.positionsLabel.Name = "positionsLabel";
            this.positionsLabel.Size = new System.Drawing.Size(104, 13);
            this.positionsLabel.TabIndex = 3;
            this.positionsLabel.Text = "Number of Positions:";
            // 
            // positionsNumericUpDown
            // 
            this.positionsNumericUpDown.Location = new System.Drawing.Point(234, 13);
            this.positionsNumericUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.positionsNumericUpDown.Name = "positionsNumericUpDown";
            this.positionsNumericUpDown.Size = new System.Drawing.Size(37, 20);
            this.positionsNumericUpDown.TabIndex = 2;
            this.positionsNumericUpDown.ValueChanged += new System.EventHandler(this.positionsNumericUpDown_ValueChanged);
            // 
            // MultiSwitchPinManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "MultiSwitchPinManager";
            this.Size = new System.Drawing.Size(400, 200);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionsNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel pinLayoutPanel;
        private System.Windows.Forms.Label positionsLabel;
        private System.Windows.Forms.NumericUpDown positionsNumericUpDown;
    }
}
