using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Win32;
using net.willshouse.HogKeys.IO;
using net.willshouse.HogKeys.IO.Inputs;
using net.willshouse.HogKeys.IO.Inputs.Switches;


namespace net.willshouse.HogKeys.UI
{
    public partial class HogKeysStatusForm : Form
    {
        //BindingSource inputSource, outputSource;
        //TestDriver driver;
        Board pokeys;
        private int hogKeysPort;
        private string configFileName;

        public HogKeysStatusForm()
        {
            InitializeComponent();
        }

        private void HogKeysStatus_Load(object sender, EventArgs e)
        {
            // need to move binding sources to be device specific 
            //inputSource = new BindingSource();
            //outputSource = new BindingSource();
            pokeys = new Board();
            pokeys.ArchType = "POKEYS 56U";
            pokeys.BoardId = 0;
            pokeys.ID = 0;
            pokeys.Name = "Main Board";
            pokeys.Type = "net.willshouse.HogKeys.IO.TestDriver";

            //driver = new TestDriver(); // Instantiate pokeys driver module. This needs to be moved to a config somehow
            //inputSource.DataSource = typeof(Input);
            //outputSource.DataSource = typeof(Output);
            CreateInputStatusColumns();
            CreateOutputStatusColumns();
            inputStatusDataGridView.DataSource = pokeys.InputSource;
            outputStatusDataGridView.AutoGenerateColumns = false;
            outputStatusDataGridView.DataSource = pokeys.OutputSource;
            //BuildTestInputData(); //Used for Debugging
            //BuildTestOutputData(); //Used for Debugging

            try
            {
                pokeys.Initialize();
                //driver.InitializeConnection(0); // we assume we are connecting to the first and only pokeys device..needs to be config
            }
            catch (Exception)
            {
                MessageBox.Show("No Pokeys Device Found");
            }

            //driver.Inputs = inputSource;  //assign the pokeys driver a list of inputs to monitor
            //driver.Outputs = outputSource; //assign the pokeys driver a list of outputs to monitor
            GetUserSettings();
            //hostTextBox.DataBindings.Add("Text", driver, "Host"); // give the text box the host parameter from factory
            //dcsPortTextBox.DataBindings.Add("Text", driver, "Port");// can i have multiple objects bound to same gui object?
            if ((configFileName != null) && (File.Exists(configFileName)))
            {
                LoadConfig(configFileName);
            }
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
            NewColumn("BusIndex", "Bus Index", outputStatusDataGridView);
            NewColumn("ByteIndex", "Byte Index", outputStatusDataGridView);
            //add offset?
        }

        private void GetUserSettings()
        {

            RegistryKey hogKeys = Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("HogKeys");
            // DCSHOST
            string dcsHost = (string)hogKeys.GetValue("DCSHostName", "localhost");
            //driver.Host = dcsHost;  user settings needs to be called earlier and this will be assigned by factory when its built
            // currently hardcoded
            hostTextBox.Text = dcsHost;

            //DCSPORT
            // same as above
            int dcsPort = (int)hogKeys.GetValue("DCSPort", 9089);
            //driver.Port = dcsPort;
            dcsPortTextBox.Text = dcsPort.ToString();

            //INTERVAL
            int interval = (int)hogKeys.GetValue("PollingInterval", 25);
            pollingIntervalTrackBar.Value = interval;
            pollingIntervalTextBox.Text = pollingIntervalTrackBar.Value.ToString();

            //HOGKEYSORT
            int hkPort = (int)hogKeys.GetValue("HogKeysPort", 9090);
            hogKeysPort = hkPort;
            hogKeysPortTextBox.Text = hogKeysPort.ToString();

            //LastOpenedFile
            configFileName = (string)hogKeys.GetValue("LastOpenedFile");

        }

        private void SetUserSettings()
        {
            // save needs to read from factory instead of host
            RegistryKey hogKeys = Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("HogKeys");
            //hogKeys.SetValue("DCSHostName", driver.Host.ToString());
            //hogKeys.SetValue("DCSPort", driver.Port);
            hogKeys.SetValue("PollingInterval", pollingIntervalTrackBar.Value);
            hogKeys.SetValue("HogKeysPort", Convert.ToInt32(hogKeysPortTextBox.Text));
        }

        private void NewColumn(string dataPropertyName, string headerText, DataGridView target)
        {
            DataGridViewTextBoxColumn aColumn = new DataGridViewTextBoxColumn();
            aColumn.DataPropertyName = dataPropertyName;
            aColumn.HeaderText = headerText;
            target.Columns.Add(aColumn);
        }

        //private void BuildTestInputData()
        //{
        //    inputSource.DataSource = typeof(Input);
        //    MultiSwitch test1 = new MultiSwitch("Test1");
        //    test1.Values.Add(".1");
        //    test1.Values.Add(".2");
        //    test1.Values.Add(".3");
        //    test1.Pins.Add(11);
        //    test1.Pins.Add(12);
        //    test1.Pins.Add(13);
        //    inputSource.Add(test1);

        //    BinarySwitch test2 = new BinarySwitch("test2");
        //    test2.Values.Add(".25");
        //    test2.Values.Add(".50");
        //    test2.Values.Add(".75");
        //    test2.Values.Add("1");
        //    test2.Pins.Add(21);
        //    test2.Pins.Add(22);
        //    inputSource.Add(test2);

        //    ToggleSwitch test3 = new ToggleSwitch("test3");
        //    test3.Values.Add("-1");
        //    test3.Values.Add("1");
        //    test3.Pins.Add(31);
        //    inputSource.Add(test3);
        //}

        //private void BuildTestOutputData()
        //{
        //    ToggleOutput test1, test2, test3;
        //    test1 = new ToggleOutput();
        //    test2 = new ToggleOutput();
        //    test3 = new ToggleOutput();
        //    outputSource.Add(test1);
        //    outputSource.Add(test2);
        //    outputSource.Add(test3);
        //}

        private void editSwitch(object sender, EventArgs e)
        {
            LaunchInputDetailForm((Switch)pokeys.InputSource.Current); //changed
        }

        private void newSwitch(object sender, EventArgs e)
        {
            LaunchInputDetailForm(new ToggleSwitch(), pokeys.InputSource);//changed
        }

        private void LaunchInputDetailForm(Input aSwitch)
        {
            LaunchInputDetailForm(aSwitch, null);
        }

        private void LaunchInputDetailForm(Input aSwitch, BindingSource aSource)
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
            LaunchInputDetailForm(new ToggleSwitch(), pokeys.InputSource);
        }

        private void toggleOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchoutputDetailForm(new ToggleOutput(), pokeys.OutputSource);
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchInputDetailForm(new BinarySwitch(), pokeys.InputSource);
        }

        private void multiPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchInputDetailForm(new MultiSwitch(), pokeys.InputSource);
        }

        private void analogInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchInputDetailForm(new AnalogInput(), pokeys.InputSource);
        }

        private void gridStatus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //http://code.google.com/p/hogkeys/issues/detail?id=1
            // check to make sure the row we selected is in bounds
            if (e.RowIndex > -1)
            {
                LaunchInputDetailForm((Input)pokeys.InputSource[e.RowIndex]);
            }

        }

        private void outputStatusDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                LaunchOutputDetailForm((Output)pokeys.OutputSource[e.RowIndex]);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == inputStatusTabPage)
            {
                PromptAndDelete(pokeys.InputSource);
            }
            else if (tabControl1.SelectedTab == outputStatusTabPage)
            {
                PromptAndDelete(pokeys.OutputSource);
            }
        }

        private void PromptAndDelete(BindingSource itemSource)
        {
            HogKeysIO selectedItem = (HogKeysIO)itemSource.Current;
            DialogResult result = MessageBox.Show("Are you sure you want to delete: " +
                selectedItem.Name + " ?", "Confirm Switch Delete", MessageBoxButtons.OKCancel);
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
            RegistryKey hogKeys = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("HogKeys", true);
            hogKeys.SetValue("LastOpenedFile", fileName, RegistryValueKind.String);

        }

        private void LoadConfig(string fileName)
        {
            HogKeysConfig loader;
            XmlSerializer ser = new XmlSerializer(typeof(HogKeysConfig), new Type[] { typeof(AnalogInput), typeof(ToggleSwitch), typeof(BinarySwitch), typeof(MultiSwitch), typeof(ToggleOutput) });
            using (var stream = File.OpenRead(fileName))
            {
                loader = (HogKeysConfig)ser.Deserialize(stream);
            }
            pokeys.InputSource.DataSource = (BindingList<Input>)loader.Inputs;
            pokeys.OutputSource.DataSource = (BindingList<Output>)loader.Outputs;
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
            XmlSerializer ser = new XmlSerializer(typeof(HogKeysConfig), new Type[] { typeof(AnalogInput), typeof(ToggleSwitch), typeof(BinarySwitch), typeof(MultiSwitch), typeof(ToggleOutput) });
            using (var stream = File.Create(fileName))
            {
                HogKeysConfig saver = new HogKeysConfig();
                saver.Inputs = (BindingList<Input>)pokeys.InputSource.List;
                saver.Outputs = (BindingList<Output>)pokeys.OutputSource.List;
                ser.Serialize(stream, saver);
            }
            MessageBox.Show("Items Saved");
        }

        private void pollOnceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pokeys.Poll();
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
            if (typeof(IOutputs).IsAssignableFrom(pokeys.Driver.GetType()))
            {
                IOutputs driver = (IOutputs)pokeys.Driver;
                UDPListener.MessageReceived += new UDPListener.UDPListenerEventHandler(driver.UDPListenerEventHandlerMessageReceived);
            }
            
            pollingStatusLabel.Text = "Polling:ON";
        }

        private void StopPolling()
        {

            pollOnceToolStripMenuItem.Enabled = true;
            startPollingToolStripMenuItem.Enabled = true;
            stopPollingToolStripMenuItem.Enabled = false;
            timer1.Enabled = false;
            UDPListener.Stop();

            if (typeof(IOutputs).IsAssignableFrom(pokeys.Driver.GetType()))
            {
                IOutputs driver = (IOutputs)pokeys.Driver;
                UDPListener.MessageReceived -= driver.UDPListenerEventHandlerMessageReceived;
            }

            pollingStatusLabel.Text = "Polling:OFF";
        }

        private void stopPollingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopPolling();
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            pokeys.Poll();
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
            System.Diagnostics.FileVersionInfo fileVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            MessageBox.Show("HogKeys Version:\n" + fileVersion.ProductVersion, "About HogKeys");
        }

        private void HogKeysStatusForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UDPListener.IsRunning == true)
            {
                StopPolling();
            }
        }

    }
}
