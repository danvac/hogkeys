using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using net.willshouse.HogKeys.IO;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Win32;

namespace net.willshouse.HogKeys.UI
{
    public partial class HogKeysStatusForm : Form
    {
        BindingSource inputSource, outputSource;
        TestDriver driver;
        private int hogKeysPort;
        private string configFileName;

        public HogKeysStatusForm()
        {
            InitializeComponent();
        }

        private void SwitchStatus_Load(object sender, EventArgs e)
        {
            if (!VerifyRegistry())
            {
                CreateRegistery();
            }
            inputSource = new BindingSource();
            outputSource = new BindingSource();
            driver = new TestDriver();
            inputSource.DataSource = typeof(Input);
            outputSource.DataSource = typeof(Output);
            CreateInputStatusColumns();
            CreateOutputStatusColumns();
            inputStatusDataGridView.DataSource = inputSource;
            outputStatusDataGridView.AutoGenerateColumns = false;
            outputStatusDataGridView.DataSource = outputSource;
            //BuildTestInputData();
            //BuildTestOutputData();

            try
            {
                driver.InitializeConnection(0);
            }
            catch (Exception)
            {
                MessageBox.Show("No Pokeys Device Found");

            }
            driver.Inputs = inputSource;
            driver.Outputs = outputSource;
            GetUserSettings();
            hostTextBox.DataBindings.Add("Text", driver, "Host");
            dcsPortTextBox.DataBindings.Add("Text", driver, "Port");
            if ((configFileName != "") && (File.Exists(configFileName)))
            {
                LoadConfig(configFileName);
            }
        }

        private bool VerifyRegistry()
        {
            bool passed = false;
            string[] validValues = { "LastOpenedFile", "DCSHostName", "DCSPort", "PollingInterval", "HogKeysPort", "" };
            RegistryKey software = Registry.CurrentUser.OpenSubKey("Software");
            if (software != null)
            {
                RegistryKey hogKeys = software.OpenSubKey("HogKeys");
                if (hogKeys != null)
                {
                    passed = true;
                    foreach (string name in hogKeys.GetValueNames())
                    {
                        if (!validValues.Contains<string>(name))
                        {
                            passed = false;
                        }
                    }
                }
            }
            return passed;
        }

        private void CreateRegistery()
        {
            RegistryKey softWare = Registry.CurrentUser.CreateSubKey("Software");
            softWare.DeleteSubKey("HogKeys");
            RegistryKey hogKeys = softWare.CreateSubKey("HogKeys");
            hogKeys.SetValue("LastOpenedFile", "", RegistryValueKind.String);
            hogKeys.SetValue("DCSHostName", "localhost", RegistryValueKind.String);
            hogKeys.SetValue("DCSPort", "9089", RegistryValueKind.String);
            hogKeys.SetValue("PollingInterval", "25", RegistryValueKind.String);
            hogKeys.SetValue("HogKeysPort", "9090", RegistryValueKind.String);
            hogKeys.Flush();
            softWare.Flush();
        }

        private void CreateInputStatusColumns()
        {
            NewColumn("Name", "Name", inputStatusDataGridView);
            NewColumn("State", "Current State", inputStatusDataGridView);
            NewColumn("DeviceId", "Device Id", inputStatusDataGridView);
            NewColumn("ButtonId", "Button Id", inputStatusDataGridView);
            NewColumn("Type", "Type", inputStatusDataGridView);
            NewColumn("Description", "Description", inputStatusDataGridView);
        }

        private void CreateOutputStatusColumns()
        {
            NewColumn("Name", "Name", outputStatusDataGridView);
            NewColumn("State", "Current State", outputStatusDataGridView);
            NewColumn("Description", "Description", outputStatusDataGridView);
        }

        private void GetUserSettings()
        {

            RegistryKey hogKeys = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("HogKeys");
            driver.Host = (string)hogKeys.GetValue("DCSHostName");
            driver.Port = Convert.ToInt32((string)hogKeys.GetValue("DCSPort"));
            pollingIntervalTrackBar.Value = Convert.ToInt32((string)hogKeys.GetValue("PollingInterval"));
            hostTextBox.Text = driver.Host;
            dcsPortTextBox.Text = driver.Port.ToString();
            pollingIntervalTextBox.Text = pollingIntervalTrackBar.Value.ToString();
            hogKeysPort = Convert.ToInt32((string)hogKeys.GetValue("HogKeysPort"));
            hogKeysPortTextBox.Text = hogKeysPort.ToString();
            configFileName = (string)hogKeys.GetValue("LastOpenedFile");
        }

        private void SetUserSettings()
        {
            RegistryKey hogKeys = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("HogKeys",true);
            hogKeys.SetValue("DCSHostName",driver.Host.ToString());
            hogKeys.SetValue("DCSPort",driver.Port.ToString());
            hogKeys.SetValue("PollingInterval", pollingIntervalTrackBar.Value.ToString());
            hogKeys.SetValue("HogKeysPort", hogKeysPortTextBox.Text);
        }

        private void NewColumn(string dataPropertyName, string headerText, DataGridView target)
        {
            DataGridViewTextBoxColumn aColumn = new DataGridViewTextBoxColumn();
            aColumn.DataPropertyName = dataPropertyName;
            aColumn.HeaderText = headerText;
            target.Columns.Add(aColumn);
        }

        private void BuildTestInputData()
        {
            inputSource.DataSource = typeof(Input);
            MultiSwitch test1 = new MultiSwitch("Test1");
            test1.Values.Add(".1");
            test1.Values.Add(".2");
            test1.Values.Add(".3");
            test1.Pins.Add(11);
            test1.Pins.Add(12);
            test1.Pins.Add(13);
            inputSource.Add(test1);

            BinarySwitch test2 = new BinarySwitch("test2");
            test2.Values.Add(".25");
            test2.Values.Add(".50");
            test2.Values.Add(".75");
            test2.Values.Add("1");
            test2.Pins.Add(21);
            test2.Pins.Add(22);
            inputSource.Add(test2);

            ToggleSwitch test3 = new ToggleSwitch("test3");
            test3.Values.Add("-1");
            test3.Values.Add("1");
            test3.Pins.Add(31);
            inputSource.Add(test3);
        }

        private void BuildTestOutputData()
        {
            ToggleOutput test1, test2, test3;
            test1 = new ToggleOutput();
            test2 = new ToggleOutput();
            test3 = new ToggleOutput();
            outputSource.Add(test1);
            outputSource.Add(test2);
            outputSource.Add(test3);
        }

        private void editSwitch(object sender, EventArgs e)
        {
            LaunchSwitchDetailForm((Input)inputSource.Current);
        }

        private void newSwitch(object sender, EventArgs e)
        {
            LaunchSwitchDetailForm(new ToggleSwitch(), inputSource);
        }

        private void LaunchSwitchDetailForm(Input aSwitch)
        {
            LaunchSwitchDetailForm(aSwitch, null);
        }

        private void LaunchSwitchDetailForm(Input aSwitch, BindingSource aSource)
        {
            InputDetailForm switchDetail = new InputDetailForm(aSwitch, aSource);
            switchDetail.ShowDialog();
        }

        private void LaunchOutputDetailForm(Output output)
        {
            OutputDetailForm outputDetail = new OutputDetailForm(output);
            outputDetail.ShowDialog();
        }

        private void LaunchoutputDetailForm(Output output, BindingSource source)
        {
            OutputDetailForm outputDetail = new OutputDetailForm(output, source);
            outputDetail.ShowDialog();
        }

        private void toggleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchSwitchDetailForm(new ToggleSwitch(), inputSource);
        }

        private void toggleOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchoutputDetailForm(new ToggleOutput(), outputSource);
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchSwitchDetailForm(new BinarySwitch(), inputSource);
        }

        private void multiPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchSwitchDetailForm(new MultiSwitch(), inputSource);
        }

        private void gridStatus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //http://code.google.com/p/hogkeys/issues/detail?id=1
            // check to make sure the row we selected is in bounds
            if (e.RowIndex > -1)
            {
                LaunchSwitchDetailForm((Input)inputSource[e.RowIndex]);
            }

        }

        private void outputStatusDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                LaunchOutputDetailForm((Output)outputSource[e.RowIndex]);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == inputStatusTabPage)
            {
                PromptAndDelete(inputSource);
            }
            else if (tabControl1.SelectedTab == outputStatusTabPage)
            {
                PromptAndDelete(outputSource);
            }
        }

        private void PromptAndDelete(BindingSource itemSource)
        {
            HogKeysIO selectedItem = (HogKeysIO)itemSource.Current;
            DialogResult result = MessageBox.Show("Are you sure you want to delete: " +
                selectedItem.Name + " ?", "Confirm Input Delete", MessageBoxButtons.OKCancel);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                itemSource.Remove(selectedItem);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = configFileName;
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = openFileDialog1.FileName;
            LoadConfig(fileName);
            RegistryKey hogKeys = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("HogKeys",true);
            hogKeys.SetValue("LastOpenedFile", fileName, RegistryValueKind.String);
            
        }

        private void LoadConfig(string fileName)
        {
            HogKeysConfig loader;
            XmlSerializer ser = new XmlSerializer(typeof(HogKeysConfig), new Type[] { typeof(ToggleSwitch), typeof(BinarySwitch), typeof(MultiSwitch), typeof(ToggleOutput) });
            using (var stream = File.OpenRead(fileName))
            {
                loader = (HogKeysConfig)ser.Deserialize(stream);
            }
            inputSource.DataSource = (BindingList<Input>)loader.Inputs;
            outputSource.DataSource = (BindingList<Output>)loader.Outputs;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = configFileName;
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileDialog1.FileName;
            SaveConfig(fileName);
            RegistryKey hogKeys = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("HogKeys", true);
            hogKeys.SetValue("LastOpenedFile", fileName, RegistryValueKind.String);
        }

        private void SaveConfig(string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(HogKeysConfig), new Type[] { typeof(ToggleSwitch), typeof(BinarySwitch), typeof(MultiSwitch), typeof(ToggleOutput) });
            using (var stream = File.Create(fileName))
            {
                HogKeysConfig saver = new HogKeysConfig();
                saver.Inputs = (BindingList<Input>)inputSource.List;
                saver.Outputs = (BindingList<Output>)outputSource.List;
                ser.Serialize(stream, saver);
            }
            MessageBox.Show("Items Saved");
        }

        private void pollOnceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            driver.poll();
        }

        private void startPollingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartPolling();
        }

        private void StartPolling()
        {
            pollOnceToolStripMenuItem.Enabled = false;
            startPollingToolStripMenuItem.Enabled = false;
            stopPollingToolStripMenuItem.Enabled = true;
            timer1.Enabled = true;
            UDPListener.Start(hogKeysPort);
            UDPListener.MessageReceived += new UDPListener.UDPListenerEventHandler(driver.UDPListenerEventHandlerMessageReceived);
            pollingStatusLabel.Text = "Polling:ON";
        }

        private void StopPolling()
        {
            pollOnceToolStripMenuItem.Enabled = true;
            startPollingToolStripMenuItem.Enabled = true;
            stopPollingToolStripMenuItem.Enabled = false;
            timer1.Enabled = false;
            UDPListener.Stop();
            UDPListener.MessageReceived -= driver.UDPListenerEventHandlerMessageReceived;
            pollingStatusLabel.Text = "Polling:OFF";
        }

        private void stopPollingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopPolling();
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
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            SetUserSettings();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location);
            MessageBox.Show("HogKeys Version:\n" + fileVersion.ProductVersion, "About HogKeys");
        }

    }
}
