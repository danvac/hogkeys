using net.willshouse.HogKeys.SimulatorAdapter;


namespace net.willshouse.HogKeys.Boards
{
    public abstract class Board
    {
        /// <summary>
        /// Returns the Index of the board according to the driver
        /// </summary>

        protected Board()
        {

        }

        public abstract void Initialize(ISimAdapter adapter);
                    
        
        public int DriverIndex { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public abstract bool Connected { get;}



    }

}
