namespace net.willshouse.HogKeys.UI
{
    partial class IndexPinValueControl
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
            this.indexLabel = new System.Windows.Forms.Label();
            this.pinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pinNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // indexLabel
            // 
            this.indexLabel.AutoSize = true;
            this.indexLabel.Location = new System.Drawing.Point(6, 9);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(22, 13);
            this.indexLabel.TabIndex = 0;
            this.indexLabel.Text = "10:";
            // 
            // pinNumericUpDown
            // 
            this.pinNumericUpDown.Location = new System.Drawing.Point(28, 5);
            this.pinNumericUpDown.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.pinNumericUpDown.Name = "pinNumericUpDown";
            this.pinNumericUpDown.Size = new System.Drawing.Size(45, 20);
            this.pinNumericUpDown.TabIndex = 1;
            this.pinNumericUpDown.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(73, 5);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(42, 20);
            this.valueTextBox.TabIndex = 2;
            this.valueTextBox.Text = "-12.345";
            // 
            // IndexPinValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.pinNumericUpDown);
            this.Controls.Add(this.indexLabel);
            this.Name = "IndexPinValueControl";
            this.Size = new System.Drawing.Size(120, 30);
            ((System.ComponentModel.ISupportInitialize)(this.pinNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label indexLabel;
        private System.Windows.Forms.NumericUpDown pinNumericUpDown;
        private System.Windows.Forms.TextBox valueTextBox;
    }
}
