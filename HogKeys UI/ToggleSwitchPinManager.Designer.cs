namespace net.willshouse.HogKeys.UI
{
    partial class ToggleSwitchPinManager
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
            this.pinLabel = new System.Windows.Forms.Label();
            this.pinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.onLabel = new System.Windows.Forms.Label();
            this.onTextBox = new System.Windows.Forms.TextBox();
            this.offLabel = new System.Windows.Forms.Label();
            this.offTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pinNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pinLabel
            // 
            this.pinLabel.AutoSize = true;
            this.pinLabel.Location = new System.Drawing.Point(73, 8);
            this.pinLabel.Name = "pinLabel";
            this.pinLabel.Size = new System.Drawing.Size(25, 13);
            this.pinLabel.TabIndex = 0;
            this.pinLabel.Text = "Pin:";
            // 
            // pinNumericUpDown
            // 
            this.pinNumericUpDown.Location = new System.Drawing.Point(68, 21);
            this.pinNumericUpDown.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.pinNumericUpDown.Name = "pinNumericUpDown";
            this.pinNumericUpDown.Size = new System.Drawing.Size(43, 20);
            this.pinNumericUpDown.TabIndex = 1;
            this.pinNumericUpDown.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // onLabel
            // 
            this.onLabel.AutoSize = true;
            this.onLabel.Location = new System.Drawing.Point(114, 41);
            this.onLabel.Name = "onLabel";
            this.onLabel.Size = new System.Drawing.Size(54, 13);
            this.onLabel.TabIndex = 2;
            this.onLabel.Text = "On Value:";
            // 
            // onTextBox
            // 
            
            this.onTextBox.Location = new System.Drawing.Point(106, 54);
            this.onTextBox.Name = "onTextBox";
            this.onTextBox.Size = new System.Drawing.Size(53, 20);
            this.onTextBox.TabIndex = 3;
            // 
            // offLabel
            // 
            this.offLabel.AutoSize = true;
            this.offLabel.Location = new System.Drawing.Point(10, 41);
            this.offLabel.Name = "offLabel";
            this.offLabel.Size = new System.Drawing.Size(54, 13);
            this.offLabel.TabIndex = 2;
            this.offLabel.Text = "Off Value:";
            // 
            // offTextBox
            // 
            
            this.offTextBox.Location = new System.Drawing.Point(11, 54);
            this.offTextBox.Name = "offTextBox";
            this.offTextBox.Size = new System.Drawing.Size(53, 20);
            this.offTextBox.TabIndex = 3;
            // 
            // ToggleSwitchPinManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.offTextBox);
            this.Controls.Add(this.offLabel);
            this.Controls.Add(this.onTextBox);
            this.Controls.Add(this.onLabel);
            this.Controls.Add(this.pinNumericUpDown);
            this.Controls.Add(this.pinLabel);
            this.Name = "ToggleSwitchPinManager";
            this.Size = new System.Drawing.Size(178, 84);
            ((System.ComponentModel.ISupportInitialize)(this.pinNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pinLabel;
        private System.Windows.Forms.NumericUpDown pinNumericUpDown;
        private System.Windows.Forms.Label onLabel;
        private System.Windows.Forms.TextBox onTextBox;
        private System.Windows.Forms.Label offLabel;
        private System.Windows.Forms.TextBox offTextBox;
    }
}
