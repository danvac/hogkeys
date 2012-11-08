namespace net.willshouse.HogKeys.UI.Controls
{
    partial class ToggleOutputDetailControl
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
            this.indexNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.indexLabel = new System.Windows.Forms.Label();
            this.logicOnLabel = new System.Windows.Forms.Label();
            this.logicOnMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.logicOnMaskedTextBox);
            this.groupBox1.Controls.Add(this.logicOnLabel);
            this.groupBox1.Controls.Add(this.indexLabel);
            this.groupBox1.Controls.Add(this.indexNumericUpDown);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // indexNumericUpDown
            // 
            this.indexNumericUpDown.Location = new System.Drawing.Point(108, 34);
            this.indexNumericUpDown.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.indexNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.indexNumericUpDown.Name = "indexNumericUpDown";
            this.indexNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.indexNumericUpDown.TabIndex = 0;
            // 
            // indexLabel
            // 
            this.indexLabel.AutoSize = true;
            this.indexLabel.Location = new System.Drawing.Point(31, 40);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(71, 13);
            this.indexLabel.TabIndex = 1;
            this.indexLabel.Text = "Output Index:";
            // 
            // logicOnLabel
            // 
            this.logicOnLabel.AutoSize = true;
            this.logicOnLabel.Location = new System.Drawing.Point(31, 72);
            this.logicOnLabel.Name = "logicOnLabel";
            this.logicOnLabel.Size = new System.Drawing.Size(74, 13);
            this.logicOnLabel.TabIndex = 2;
            this.logicOnLabel.Text = "On Threshold:";
            // 
            // logicOnMaskedTextBox
            // 
            this.logicOnMaskedTextBox.Location = new System.Drawing.Point(108, 68);
            this.logicOnMaskedTextBox.Mask = "990.09";
            this.logicOnMaskedTextBox.Name = "logicOnMaskedTextBox";
            this.logicOnMaskedTextBox.Size = new System.Drawing.Size(58, 20);
            this.logicOnMaskedTextBox.TabIndex = 3;
            // 
            // ToggleOutputDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ToggleOutputDetailControl";
            this.Size = new System.Drawing.Size(392, 159);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label indexLabel;
        private System.Windows.Forms.NumericUpDown indexNumericUpDown;
        private System.Windows.Forms.MaskedTextBox logicOnMaskedTextBox;
        private System.Windows.Forms.Label logicOnLabel;
    }
}
