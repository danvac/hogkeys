using GalaSoft.MvvmLight;
using net.willshouse.HogKeys.Boards;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HogKeysUI.Model;

namespace HogKeysUI.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class BoardViewModel : ViewModelBase
    {
        

        /// <summary>
        /// Initializes a new instance of the BoardViewModel class.
        /// </summary>
       

        public BoardViewModel(Board board)
        {
            // TODO: Complete member initialization
            this.Model = board;
            ShowInputsCommand = new RelayCommand(() => Messenger.Default.Send<IInputs>(this.Model as IInputs), () => Model is IInputs);
            ShowOutputsCommand = new RelayCommand(() => Messenger.Default.Send<IOutputs>(this.Model as IOutputs), () => Model is IOutputs);
           

        }

        public Visibility Enabled
        {
            get
            {
                return Model.Enabled ? Visibility.Collapsed : Visibility.Visible;
            }
        }
        public Board Model
        {
            get;
            private set;
        }

        public RelayCommand ShowInputsCommand { get; private set; }

        public RelayCommand ShowOutputsCommand { get; private set; }

    }
}