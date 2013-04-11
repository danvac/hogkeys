
using System.Windows.Forms;
using net.willshouse.HogKeys.IO.Inputs;
namespace net.willshouse.HogKeys.IO
{
 

    public class Board
    {
        private Driver driver;

        public int BoardId { get; set; } // the id of the board as enumerated.  this is unique per architecture type

        public int ID { get; set; } // this id is should be unique across hogkeys.

        public string ArchType { get; set; } // the type of board e.g hogduino,pokeys,etc

        public string Type { get; set; } // the classname of the driver for this board

        public string Name { get; set; } //the friendly name of the board.

        public BindingSource InputSource { get; set; }

        public BindingSource OutputSource { get; set; }

        public Driver Driver { get { return driver; } }


        public Board()
        {
            driver = new PokeysDriver();
            driver.Host = "localhost";
            driver.Port = 9189;
            InputSource = new BindingSource();
            OutputSource = new BindingSource();
            InputSource.DataSource = typeof(Input);
            OutputSource.DataSource = typeof(Output);
        }

        public void Initialize()
        {
            driver.InitializeConnection(BoardId);
            driver.Inputs = InputSource;  //assign the pokeys driver a list of inputs to monitor
            driver.Outputs = OutputSource; //assign the pokeys driver a list of outputs to monitor
        }

        public void Poll()
        {
            driver.Poll();
        }

        
    }
}
