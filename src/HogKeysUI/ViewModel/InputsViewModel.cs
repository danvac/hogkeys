using GalaSoft.MvvmLight;
using net.willshouse.HogKeys.IO.Inputs;
using net.willshouse.HogKeys.Boards;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace HogKeysUI.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class InputsViewModel : ViewModelBase
    {
        public RelayCommand CloseCommand { get; private set; }
        public ObservableCollection<InputViewModel> Inputs { get; set; }
        public string DisplayName { get; private set; }
        /// <summary>
        /// Initializes a new instance of the InputsViewModel class.
        /// </summary>
        public InputsViewModel(IInputs model)
        {
            DisplayName = (model as Board).Name + " Inputs";
            CloseCommand = new RelayCommand(() => Messenger.Default.Send<ViewModelBase>(this), () => true);
            Inputs = new ObservableCollection<InputViewModel>();
            foreach (var input in model.Inputs)
            {
                Inputs.Add(new InputViewModel(input));
            }
        }
    }
}