using GalaSoft.MvvmLight;
using net.willshouse.HogKeys.IO.Inputs;
using net.willshouse.HogKeys.IO;

namespace HogKeysUI.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class OutputViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the InputViewModel class.
        /// </summary>
        public OutputViewModel(Output model)
        {
            this.Model = model;
        }


        public Output Model 
        { 
            get;
            private set;
        }
    }
}