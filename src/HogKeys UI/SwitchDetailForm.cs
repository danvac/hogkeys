using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using net.willshouse.HogKeys.Inputs;


namespace net.willshouse.HogKeys.UI
{
    public partial class SwitchDetailForm : Form
    {
        private Input currentSwitch;
        private bool isNew;
        private BindingSource switchSource;
        private ToggleSwitchPinManager toggleSwitchPinManager1;
        private BinarySwitchPinManager binarySwitchPinManager1;
        private MultiSwitchPinManager multiSwitchPinManager1;


        public SwitchDetailForm(Input aSwitch)
            : this(aSwitch, null) { }

        public SwitchDetailForm(Input aSwitch, BindingSource aSource)
        {
            if (aSource == null)
            {
                this.isNew = false;
            }
            else
            {
                switchSource = aSource;
                this.isNew = true;
            }
            currentSwitch = aSwitch;
            InitializeComponent();
        }

        public bool IsNewSwitch
        {
            get { return isNew; }
        }

        private void SwitchDetailForm_Load(object sender, EventArgs e)
        {
            nameTextBox.Text = currentSwitch.Name;
            deviceTextBox.Text = currentSwitch.DeviceId.ToString();
            buttonTextBox.Text = currentSwitch.ButtonId.ToString();
            descriptionTextBox.Text = currentSwitch.Description;
            typeTextBox.Text = currentSwitch.Type.ToString();
            InitializePinManager();
            this.saveButton.Click += new EventHandler(saveButton_Click);
        }

        private void InitializePinManager()
        {
            switch (currentSwitch.Type)
            {
                case InputType.ToggleSwitch:
                    {
                        InitializeToggleSwitchPinManager();
                        break;
                    }
                case InputType.BinarySwitch:
                    {
                        InitializeBinarySwitchPinManager();
                        break;
                    }
                case InputType.MultiSwitch:
                    {
                        InitializeMultiSwitchPinManager();
                        break;
                    }
            }
        }

        private void InitializeMultiSwitchPinManager()
        {
            multiSwitchPinManager1 = new MultiSwitchPinManager();
            multiSwitchPinManager1.Dock = DockStyle.Fill;
            multiSwitchPinManager1.Switch = (MultiSwitch)currentSwitch;
            splitContainer1.Panel2.Controls.Add(multiSwitchPinManager1);
            this.saveButton.Click +=new EventHandler(multiSwitchPinManager1.SaveHandler);
        }

        private void InitializeBinarySwitchPinManager()
        {
            binarySwitchPinManager1 = new BinarySwitchPinManager();
            binarySwitchPinManager1.Dock = DockStyle.Fill;
            binarySwitchPinManager1.Switch = (BinarySwitch)currentSwitch;
            splitContainer1.Panel2.Controls.Add(binarySwitchPinManager1);
            this.saveButton.Click += new EventHandler(binarySwitchPinManager1.SaveHandler);
        }

        private void InitializeToggleSwitchPinManager()
        {
            toggleSwitchPinManager1 = new ToggleSwitchPinManager();
            splitContainer1.Panel2.Controls.Add(toggleSwitchPinManager1);
            toggleSwitchPinManager1.Location = new Point(107, 13);
            toggleSwitchPinManager1.Size = new System.Drawing.Size(178, 84);
            toggleSwitchPinManager1.Switch = (ToggleSwitch)currentSwitch;
            this.saveButton.Click += new EventHandler(toggleSwitchPinManager1.SaveHandler);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            currentSwitch.Name = nameTextBox.Text;
            currentSwitch.DeviceId = Convert.ToInt32(deviceTextBox.Text);
            currentSwitch.ButtonId = Convert.ToInt32(buttonTextBox.Text);
            currentSwitch.Description = descriptionTextBox.Text;
            if (isNew)
            {
                switchSource.Add(currentSwitch);
            }
            this.Close();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
