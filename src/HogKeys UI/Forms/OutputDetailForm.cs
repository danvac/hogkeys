using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using net.willshouse.HogKeys.IO;
using net.willshouse.HogKeys.UI.Controls;

namespace net.willshouse.HogKeys.UI
{
    public partial class OutputDetailForm : Form
    {
        private Output currentOutput;
        private bool isNew;
        private BindingSource outputSource;


        public OutputDetailForm(Output aOutput)
            : this(aOutput, null) { }

        public OutputDetailForm(Output aOutput, BindingSource aSource)
        {
            if (aSource == null)
            {
                this.isNew = false;
            }
            else
            {
                outputSource = aSource;
                this.isNew = true;
            }
            currentOutput = aOutput;
            InitializeComponent();
        }

        public bool IsNew { get { return isNew; } }

        private void OutputDetailForm_Load(object sender, EventArgs e)
        {
            nameTextBox.Text = currentOutput.Name;
            descriptionTextBox.Text = currentOutput.Description;
            typeTextBox.Text = currentOutput.Type.ToString();
            offsetMaskedTextBox.Text = currentOutput.Offset.ToString();
            InitializeDetailForm();
        }

        private void InitializeDetailForm()
        {
            switch (currentOutput.Type)
            {
                case OutputType.ToggleOutput:
                    InitializeToggleOutputDetail();
                    break;
            }
                    
        }

        private void InitializeToggleOutputDetail()
        {
            ToggleOutputDetailControl toggleOutputDetailControl = new ToggleOutputDetailControl();
            splitContainer1.Panel2.Controls.Add(toggleOutputDetailControl);
            toggleOutputDetailControl.Dock = DockStyle.Fill;
            toggleOutputDetailControl.Output = (ToggleOutput)currentOutput;
            this.saveButton.Click += new EventHandler(toggleOutputDetailControl.SaveHandler);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            currentOutput.Name = nameTextBox.Text;
            currentOutput.Description = descriptionTextBox.Text;
            currentOutput.Offset = Convert.ToInt32(offsetMaskedTextBox.Text);
            if (isNew)
            {
                outputSource.Add(currentOutput);
            }
            this.Close();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
