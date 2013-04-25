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
    public class OutputsViewModel : ViewModelBase
    {
        public RelayCommand CloseCommand { get; private set; }
        public ObservableCollection<OutputViewModel> Outputs { get; set; }
        public string DisplayName { get; private set; }
        /// <summary>
        /// Initializes a new instance of the InputsViewModel class.
        /// </summary>
        public OutputsViewModel(IOutputs model)
        {
            DisplayName = (model as Board).Name + " Outputs";
            CloseCommand = new RelayCommand(() => Messenger.Default.Send<ViewModelBase>(this), () => true);
            Outputs = new ObservableCollection<OutputViewModel>();
            foreach (var input in model.Outputs)
            {
                Outputs.Add(new OutputViewModel(input));
            }
        }
    }
}