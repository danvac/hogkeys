namespace net.willshouse.HogKeys.UI
{
    partial class OutputDetailForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.offsetMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.offsetLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.offsetLabel);
            this.splitContainer1.Panel1.Controls.Add(this.offsetMaskedTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.typeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.typeTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.nameLabel);
            this.splitContainer1.Panel1.Controls.Add(this.nameTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.descriptionLabel);
            this.splitContainer1.Panel1.Controls.Add(this.descriptionTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.saveButton);
            this.splitContainer1.Panel2.Controls.Add(this.Cancelbutton);
            this.splitContainer1.Size = new System.Drawing.Size(392, 433);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(52, 20);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 16;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nameTextBox.Location = new System.Drawing.Point(96, 16);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(72, 20);
            this.nameTextBox.TabIndex = 17;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(27, 108);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 24;
            this.descriptionLabel.Text = "Description:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descriptionTextBox.Location = new System.Drawing.Point(96, 106);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(225, 102);
            this.descriptionTextBox.TabIndex = 25;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveButton.Location = new System.Drawing.Point(319, 183);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(70, 20);
            this.saveButton.TabIndex = 26;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancelbutton.Location = new System.Drawing.Point(244, 183);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(69, 20);
            this.Cancelbutton.TabIndex = 27;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // typeLabel
            // 
            this.typeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(211, 20);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(34, 13);
            this.typeLabel.TabIndex = 27;
            this.typeLabel.Text = "Type:";
            // 
            // typeTextBox
            // 
            this.typeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.typeTextBox.Location = new System.Drawing.Point(251, 16);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.ReadOnly = true;
            this.typeTextBox.Size = new System.Drawing.Size(69, 20);
            this.typeTextBox.TabIndex = 26;
            // 
            // offsetMaskedTextBox
            // 
            this.offsetMaskedTextBox.Location = new System.Drawing.Point(126, 55);
            this.offsetMaskedTextBox.Mask = "99990";
            this.offsetMaskedTextBox.Name = "offsetMaskedTextBox";
            this.offsetMaskedTextBox.Size = new System.Drawing.Size(41, 20);
            this.offsetMaskedTextBox.TabIndex = 28;
            // 
            // offsetLabel
            // 
            this.offsetLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.offsetLabel.AutoSize = true;
            this.offsetLabel.Location = new System.Drawing.Point(52, 59);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(38, 13);
            this.offsetLabel.TabIndex = 29;
            this.offsetLabel.Text = "Offset:";
            // 
            // OutputDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 433);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OutputDetailForm";
            this.Text = "OutputDetailForm";
            this.Load += new System.EventHandler(this.OutputDetailForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Label offsetLabel;
        private System.Windows.Forms.MaskedTextBox offsetMaskedTextBox;

    }
}