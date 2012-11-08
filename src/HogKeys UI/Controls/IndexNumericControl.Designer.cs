namespace net.willshouse.HogKeys.UI.controls
{
    partial class IndexNumericControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.pinIndexLabel = new System.Windows.Forms.Label();
            this.pinNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pinNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = ":";
            // 
            // pinIndexLabel
            // 
            this.pinIndexLabel.AutoSize = true;
            this.pinIndexLabel.Location = new System.Drawing.Point(4, 7);
            this.pinIndexLabel.Name = "pinIndexLabel";
            this.pinIndexLabel.Size = new System.Drawing.Size(25, 13);
            this.pinIndexLabel.TabIndex = 3;
            this.pinIndexLabel.Text = "128";
            // 
            // pinNumericUpDown
            // 
            this.pinNumericUpDown.Location = new System.Drawing.Point(39, 3);
            this.pinNumericUpDown.Name = "pinNumericUpDown";
            this.pinNumericUpDown.Size = new System.Drawing.Size(44, 20);
            this.pinNumericUpDown.TabIndex = 6;
            this.pinNumericUpDown.ValueChanged += new System.EventHandler(this.pinNumericUpDown_ValueChanged);
            // 
            // IndexNumericControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pinNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pinIndexLabel);
            this.Name = "IndexNumericControl";
            this.Size = new System.Drawing.Size(87, 26);
            ((System.ComponentModel.ISupportInitialize)(this.pinNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label pinIndexLabel;
        private System.Windows.Forms.NumericUpDown pinNumericUpDown;
    }
}
