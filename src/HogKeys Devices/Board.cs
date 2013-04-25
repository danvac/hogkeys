using net.willshouse.HogKeys.SimulatorAdapter;


namespace net.willshouse.HogKeys.Boards
{
    public abstract class Board
    {
        /// <summary>
        /// Returns the Index of the board according to the driver
        /// </summary>

        protected Board(ISimAdapter adapter)
                    
        {

        }

        public abstract void Initialize();
        public abstract void Shutdown();
        
        public int DriverIndex { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public bool Enabled { get; set; }

        public abstract bool Connected { get;}

        public string Type
        {
            get
            {
                string type = this.GetType().ToString();
                var i = type.LastIndexOf(".");
                return type.Substring(i + 1);
            }
        }



    }

}
