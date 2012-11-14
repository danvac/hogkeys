namespace net.willshouse.HogKeys.UI.Controls
{
    partial class AnalogDetailControl
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
            this.minVallabel = new System.Windows.Forms.Label();
            this.minValTextBox = new System.Windows.Forms.TextBox();
            this.maxLabel = new System.Windows.Forms.Label();
            this.maxValTextBox = new System.Windows.Forms.TextBox();
            this.maxRawTextLabel = new System.Windows.Forms.Label();
            this.maxRawTextBox = new System.Windows.Forms.TextBox();
            this.minRawLabel = new System.Windows.Forms.Label();
            this.minRawTextBox = new System.Windows.Forms.TextBox();
            this.setMinButton = new System.Windows.Forms.Button();
            this.setMaxButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.setMaxButton);
            this.groupBox1.Controls.Add(this.setMinButton);
            this.groupBox1.Controls.Add(this.maxRawTextLabel);
            this.groupBox1.Controls.Add(this.maxRawTextBox);
            this.groupBox1.Controls.Add(this.minRawLabel);
            this.groupBox1.Controls.Add(this.minRawTextBox);
            this.groupBox1.Controls.Add(this.maxLabel);
            this.groupBox1.Controls.Add(this.maxValTextBox);
            this.groupBox1.Controls.Add(this.minVallabel);
            this.groupBox1.Controls.Add(this.minValTextBox);
            this.groupBox1.Controls.Add(this.indexLabel);
            this.groupBox1.Controls.Add(this.indexNumericUpDown);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // indexNumericUpDown
            // 
            this.indexNumericUpDown.Location = new System.Drawing.Point(202, 16);
            this.indexNumericUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.indexNumericUpDown.Name = "indexNumericUpDown";
            this.indexNumericUpDown.Size = new System.Drawing.Size(33, 20);
            this.indexNumericUpDown.TabIndex = 1;
            // 
            // indexLabel
            // 
            this.indexLabel.AutoSize = true;
            this.indexLabel.Location = new System.Drawing.Point(166, 20);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(36, 13);
            this.indexLabel.TabIndex = 2;
            this.indexLabel.Text = "Index:";
            // 
            // minVallabel
            // 
            this.minVallabel.AutoSize = true;
            this.minVallabel.Location = new System.Drawing.Point(11, 59);
            this.minVallabel.Name = "minVallabel";
            this.minVallabel.Size = new System.Drawing.Size(57, 13);
            this.minVallabel.TabIndex = 5;
            this.minVallabel.Text = "Min Value:";
            // 
            // minValTextBox
            // 
            this.minValTextBox.Location = new System.Drawing.Point(70, 55);
            this.minValTextBox.Name = "minValTextBox";
            this.minValTextBox.Size = new System.Drawing.Size(49, 20);
            this.minValTextBox.TabIndex = 4;
            // 
            // maxLabel
            // 
            this.maxLabel.AutoSize = true;
            this.maxLabel.Location = new System.Drawing.Point(10, 97);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(60, 13);
            this.maxLabel.TabIndex = 7;
            this.maxLabel.Text = "Max Value:";
            // 
            // maxValTextBox
            // 
            this.maxValTextBox.Location = new System.Drawing.Point(70, 93);
            this.maxValTextBox.Name = "maxValTextBox";
            this.maxValTextBox.Size = new System.Drawing.Size(49, 20);
            this.maxValTextBox.TabIndex = 6;
            // 
            // maxRawTextLabel
            // 
            this.maxRawTextLabel.AutoSize = true;
            this.maxRawTextLabel.Location = new System.Drawing.Point(207, 97);
            this.maxRawTextLabel.Name = "maxRawTextLabel";
            this.maxRawTextLabel.Size = new System.Drawing.Size(55, 13);
            this.maxRawTextLabel.TabIndex = 11;
            this.maxRawTextLabel.Text = "Max Raw:";
            // 
            // maxRawTextBox
            // 
            this.maxRawTextBox.Location = new System.Drawing.Point(267, 93);
            this.maxRawTextBox.Name = "maxRawTextBox";
            this.maxRawTextBox.ReadOnly = true;
            this.maxRawTextBox.Size = new System.Drawing.Size(49, 20);
            this.maxRawTextBox.TabIndex = 10;
            // 
            // minRawLabel
            // 
            this.minRawLabel.AutoSize = true;
            this.minRawLabel.Location = new System.Drawing.Point(208, 59);
            this.minRawLabel.Name = "minRawLabel";
            this.minRawLabel.Size = new System.Drawing.Size(52, 13);
            this.minRawLabel.TabIndex = 9;
            this.minRawLabel.Text = "Min Raw:";
            // 
            // minRawTextBox
            // 
            this.minRawTextBox.Location = new System.Drawing.Point(267, 55);
            this.minRawTextBox.Name = "minRawTextBox";
            this.minRawTextBox.ReadOnly = true;
            this.minRawTextBox.Size = new System.Drawing.Size(49, 20);
            this.minRawTextBox.TabIndex = 8;
            // 
            // setMinButton
            // 
            this.setMinButton.Location = new System.Drawing.Point(323, 54);
            this.setMinButton.Name = "setMinButton";
            this.setMinButton.Size = new System.Drawing.Size(54, 23);
            this.setMinButton.TabIndex = 12;
            this.setMinButton.Text = "Set Min";
            this.setMinButton.UseVisualStyleBackColor = true;
            this.setMinButton.Click += new System.EventHandler(this.setMinButton_Click);
            // 
            // setMaxButton
            // 
            this.setMaxButton.Location = new System.Drawing.Point(323, 92);
            this.setMaxButton.Name = "setMaxButton";
            this.setMaxButton.Size = new System.Drawing.Size(54, 23);
            this.setMaxButton.TabIndex = 13;
            this.setMaxButton.Text = "Set Max";
            this.setMaxButton.UseVisualStyleBackColor = true;
            this.setMaxButton.Click += new System.EventHandler(this.setMaxButton_Click);
            // 
            // AnalogDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "AnalogDetailControl";
            this.Size = new System.Drawing.Size(400, 200);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown indexNumericUpDown;
        private System.Windows.Forms.Label indexLabel;
        private System.Windows.Forms.Label maxRawTextLabel;
        private System.Windows.Forms.TextBox maxRawTextBox;
        private System.Windows.Forms.Label minRawLabel;
        private System.Windows.Forms.TextBox minRawTextBox;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.TextBox maxValTextBox;
        private System.Windows.Forms.Label minVallabel;
        private System.Windows.Forms.TextBox minValTextBox;
        private System.Windows.Forms.Button setMaxButton;
        private System.Windows.Forms.Button setMinButton;
    }
}
