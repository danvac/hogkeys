using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using net.willshouse.HogKeys.Inputs;
using net.willshouse.HogKeys.Devices;
using System.Xml.Serialization;
using System.IO;

namespace net.willshouse.HogKeys.UI
{
    public partial class SwitchStatusForm : Form
    {
        BindingSource switchSource;
        TestDriver driver;

        public SwitchStatusForm()
        {
            InitializeComponent();
        }

        private void SwitchStatus_Load(object sender, EventArgs e)
        {
            switchSource = new BindingSource();

            driver = new TestDriver();


            switchSource.DataSource = typeof(Input);
            NewColumn("Name", "Name");
            NewColumn("State", "Current State");
            NewColumn("DeviceId", "Device Id");
            NewColumn("ButtonId", "Button Id");
            NewColumn("Type", "Type");
            NewColumn("Description", "Description");
            gridStatus.DataSource = switchSource;
            //BuildTestData();
            try
            {
                driver.InitializeConnection(0);
            }
            catch (Exception)
            {
                MessageBox.Show("No Pokeys Device Found");

            }
            driver.Inputs = switchSource;
            GetUserSettings();
            hostTextBox.DataBindings.Add("Text", driver, "Host");
            portTextBox.DataBindings.Add("Text", driver, "Port");

            if (Properties.Settings.Default.lastOpenedFile != "")
            {
                LoadConfig(Properties.Settings.Default.lastOpenedFile);
            }
        }

        private void GetUserSettings()
        {
            driver.Host = Properties.Settings.Default.host;
            driver.Port = Properties.Settings.Default.port;
            pollingIntervalTrackBar.Value = Properties.Settings.Default.pollingInterval;
            hostTextBox.Text = driver.Host;
            portTextBox.Text = driver.Port.ToString();
            pollingIntervalTextBox.Text = pollingIntervalTrackBar.Value.ToString();
        }

        private void SetUserSettings()
        {
            Properties.Settings.Default.host = driver.Host;
            Properties.Settings.Default.port = driver.Port;
            Properties.Settings.Default.pollingInterval = pollingIntervalTrackBar.Value;
            Properties.Settings.Default.Save();
        }

        private void NewColumn(string dataPropertyName, string headerText)
        {
            DataGridViewTextBoxColumn aColumn = new DataGridViewTextBoxColumn();
            aColumn.DataPropertyName = dataPropertyName;
            aColumn.HeaderText = headerText;
            gridStatus.Columns.Add(aColumn);
        }

        private void BuildTestData()
        {
            switchSource.DataSource = typeof(Input);
            MultiSwitch test1 = new MultiSwitch("Test1");
            test1.Values.Add(".1");
            test1.Values.Add(".2");
            test1.Values.Add(".3");
            test1.Pins.Add(11);
            test1.Pins.Add(12);
            test1.Pins.Add(13);
            switchSource.Add(test1);

            BinarySwitch test2 = new BinarySwitch("test2");
            test2.Values.Add(".25");
            test2.Values.Add(".50");
            test2.Values.Add(".75");
            test2.Values.Add("1");
            test2.Pins.Add(21);
            test2.Pins.Add(22);
            switchSource.Add(test2);

            ToggleSwitch test3 = new ToggleSwitch("test3");
            test3.Values.Add("-1");
            test3.Values.Add("1");
            test3.Pins.Add(31);
            switchSource.Add(test3);
        }

        private void editSwitch(object sender, EventArgs e)
        {
            LaunchSwitchDetailForm((Input)switchSource.Current);
        }

        private void newSwitch(object sender, EventArgs e)
        {
            LaunchSwitchDetailForm(new ToggleSwitch(), switchSource);
        }

        private void LaunchSwitchDetailForm(Input aSwitch)
        {
            LaunchSwitchDetailForm(aSwitch, null);
        }

        private void LaunchSwitchDetailForm(Input aSwitch, BindingSource aSource)
        {
            SwitchDetailForm switchDetail = new SwitchDetailForm(aSwitch, aSource);
            switchDetail.ShowDialog();
        }


        private void toggleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchSwitchDetailForm(new ToggleSwitch(), switchSource);
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchSwitchDetailForm(new BinarySwitch(), switchSource);
        }

        private void multiPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchSwitchDetailForm(new MultiSwitch(), switchSource);
        }

        private void gridStatus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //http://code.google.com/p/hogkeys/issues/detail?id=1
            // check to make sure the row we selected is in bounds
            if (e.RowIndex > -1)
            {
                LaunchSwitchDetailForm((Input)switchSource[e.RowIndex]);
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Input selectedSwitch = (Input)switchSource.Current;
            DialogResult result = MessageBox.Show("Are you sure you want to delete: " +
                selectedSwitch.Name + " ?", "Confirm Input Delete", MessageBoxButtons.OKCancel);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                switchSource.Remove(selectedSwitch);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = openFileDialog1.FileName;


            LoadConfig(fileName);
            Properties.Settings.Default.lastOpenedFile = fileName;
            Properties.Settings.Default.Save();
        }

        private void LoadConfig(string fileName)
        {
            BindingList<Input> switches;
            XmlSerializer ser = new XmlSerializer(typeof(BindingList<Input>), new Type[] { typeof(ToggleSwitch), typeof(BinarySwitch), typeof(MultiSwitch) });
            using (var stream = File.OpenRead(fileName))
            {
                switches = (BindingList<Input>)ser.Deserialize(stream);
            }
            switchSource.DataSource = switches;
            MessageBox.Show("Done:" + switches.Count.ToString() + " items loaded");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileDialog1.FileName;
            SaveConfig(fileName);
            Properties.Settings.Default.lastOpenedFile = fileName;
            Properties.Settings.Default.Save();
        }

        private void SaveConfig(string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(BindingList<Input>), new Type[] { typeof(ToggleSwitch), typeof(BinarySwitch), typeof(MultiSwitch) });
            using (var stream = File.Create(fileName))
            {
                ser.Serialize(stream, switchSource.List);
            }
            MessageBox.Show("Items Saved");
        }

        private void pollOnceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            driver.poll();
        }

        private void startPollingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pollOnceToolStripMenuItem.Enabled = false;
            startPollingToolStripMenuItem.Enabled = false;
            stopPollingToolStripMenuItem.Enabled = true;
            timer1.Enabled = true;
            pollingStatusLabel.Text = "Polling:ON";
        }

        private void stopPollingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pollOnceToolStripMenuItem.Enabled = true;
            startPollingToolStripMenuItem.Enabled = true;
            stopPollingToolStripMenuItem.Enabled = false;
            timer1.Enabled = false;
            pollingStatusLabel.Text = "Polling:OFF";
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            driver.poll();
        }

        private void pollingIntervalTrackBar_Scroll(object sender, EventArgs e)
        {
            pollingIntervalTextBox.Text = pollingIntervalTrackBar.Value.ToString();
            timer1.Interval = (1000 / pollingIntervalTrackBar.Value);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            GetUserSettings();
            MessageBox.Show(driver.Host);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            SetUserSettings();
        }






    }
}
