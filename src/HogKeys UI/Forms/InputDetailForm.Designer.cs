namespace net.willshouse.HogKeys.UI
{
    partial class InputDetailForm
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
            this.deviceTextBox = new System.Windows.Forms.TextBox();
            this.deviceLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.buttonLabel = new System.Windows.Forms.Label();
            this.buttonTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
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
            this.splitContainer1.Panel1.Controls.Add(this.deviceTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.deviceLabel);
            this.splitContainer1.Panel1.Controls.Add(this.nameLabel);
            this.splitContainer1.Panel1.Controls.Add(this.nameTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.descriptionLabel);
            this.splitContainer1.Panel1.Controls.Add(this.descriptionTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.typeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.typeTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.buttonLabel);
            this.splitContainer1.Panel1.Controls.Add(this.buttonTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.saveButton);
            this.splitContainer1.Panel2.Controls.Add(this.Cancelbutton);
            this.splitContainer1.Size = new System.Drawing.Size(392, 433);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 0;
            // 
            // deviceTextBox
            // 
            this.deviceTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deviceTextBox.Location = new System.Drawing.Point(96, 71);
            this.deviceTextBox.Name = "deviceTextBox";
            this.deviceTextBox.Size = new System.Drawing.Size(72, 20);
            this.deviceTextBox.TabIndex = 21;
            // 
            // deviceLabel
            // 
            this.deviceLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deviceLabel.AutoSize = true;
            this.deviceLabel.Location = new System.Drawing.Point(37, 74);
            this.deviceLabel.Name = "deviceLabel";
            this.deviceLabel.Size = new System.Drawing.Size(53, 13);
            this.deviceLabel.TabIndex = 20;
            this.deviceLabel.Text = "DeviceId:";
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
            this.nameTextBox.Location = new System.Drawing.Point(96, 17);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(72, 20);
            this.nameTextBox.TabIndex = 17;
            this.nameTextBox.Text = "Enter Name";
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
            this.descriptionTextBox.Location = new System.Drawing.Point(96, 108);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(225, 102);
            this.descriptionTextBox.TabIndex = 25;
            this.descriptionTextBox.Text = "Enter Description";
            // 
            // typeLabel
            // 
            this.typeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(212, 20);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(34, 13);
            this.typeLabel.TabIndex = 19;
            this.typeLabel.Text = "Type:";
            // 
            // typeTextBox
            // 
            this.typeTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.typeTextBox.Location = new System.Drawing.Point(252, 17);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.ReadOnly = true;
            this.typeTextBox.Size = new System.Drawing.Size(69, 20);
            this.typeTextBox.TabIndex = 18;
            // 
            // buttonLabel
            // 
            this.buttonLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLabel.AutoSize = true;
            this.buttonLabel.Location = new System.Drawing.Point(196, 74);
            this.buttonLabel.Name = "buttonLabel";
            this.buttonLabel.Size = new System.Drawing.Size(50, 13);
            this.buttonLabel.TabIndex = 22;
            this.buttonLabel.Text = "ButtonId:";
            // 
            // buttonTextBox
            // 
            this.buttonTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTextBox.Location = new System.Drawing.Point(252, 71);
            this.buttonTextBox.Name = "buttonTextBox";
            this.buttonTextBox.Size = new System.Drawing.Size(69, 20);
            this.buttonTextBox.TabIndex = 23;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveButton.Location = new System.Drawing.Point(319, 192);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(70, 20);
            this.saveButton.TabIndex = 26;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancelbutton.Location = new System.Drawing.Point(244, 192);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(69, 20);
            this.Cancelbutton.TabIndex = 27;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // InputDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 433);
            this.Controls.Add(this.splitContainer1);
            this.Name = "InputDetailForm";
            this.Text = "Switch Details";
            this.Load += new System.EventHandler(this.SwitchDetailForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox deviceTextBox;
        private System.Windows.Forms.Label deviceLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Label buttonLabel;
        private System.Windows.Forms.TextBox buttonTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button Cancelbutton;


    }
}