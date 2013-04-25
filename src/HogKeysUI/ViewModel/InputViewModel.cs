using GalaSoft.MvvmLight;
using net.willshouse.HogKeys.IO.Inputs;

namespace HogKeysUI.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class InputViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the InputViewModel class.
        /// </summary>
        public InputViewModel(Input model)
        {
            this.Model = model;
        }


        public Input Model 
        { 
            get;
            private set;
        }
    }
}