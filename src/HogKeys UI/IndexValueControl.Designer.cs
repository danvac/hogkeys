namespace net.willshouse.HogKeys.UI
{
    partial class IndexValueControl
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
            this.switchPositionLabel = new System.Windows.Forms.Label();
            this.SwitchValueTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // switchPositionLabel
            // 
            this.switchPositionLabel.AutoSize = true;
            this.switchPositionLabel.Location = new System.Drawing.Point(2, 6);
            this.switchPositionLabel.Name = "switchPositionLabel";
            this.switchPositionLabel.Size = new System.Drawing.Size(25, 13);
            this.switchPositionLabel.TabIndex = 0;
            this.switchPositionLabel.Text = "128";
            // 
            // SwitchValueTextBox
            // 
            this.SwitchValueTextBox.Location = new System.Drawing.Point(37, 2);
            this.SwitchValueTextBox.Name = "SwitchValueTextBox";
            this.SwitchValueTextBox.Size = new System.Drawing.Size(44, 20);
            this.SwitchValueTextBox.TabIndex = 1;
            this.SwitchValueTextBox.Text = "-12.999";
            this.SwitchValueTextBox.TextChanged += new System.EventHandler(this.SwitchValueTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = ":";
            // 
            // IndexValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SwitchValueTextBox);
            this.Controls.Add(this.switchPositionLabel);
            this.Name = "IndexValueControl";
            this.Size = new System.Drawing.Size(87, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label switchPositionLabel;
        private System.Windows.Forms.TextBox SwitchValueTextBox;
        private System.Windows.Forms.Label label2;
    }
}
