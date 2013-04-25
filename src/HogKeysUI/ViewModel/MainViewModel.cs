using GalaSoft.MvvmLight;
using HogKeysUI.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using net.willshouse.HogKeys.Boards;

namespace HogKeysUI.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        Manager _manager;
        ObservableCollection<ViewModelBase> _workspaces;
        public ObservableCollection<BoardViewModel> Boards { get; set; }

        /// <summary>
        /// The <see cref="SelectedBoard" /> property's name.
        /// </summary>
        public const string SelectedBoardPropertyName = "SelectedBoard";

        private BoardViewModel _selectedBoard = null;

        /// <summary>
        /// Sets and gets the SelectedBoard property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public BoardViewModel SelectedBoard
        {
            get
            {
                return _selectedBoard;
            }

            set
            {
                if (_selectedBoard == value)
                {
                    return;
                }

                //RaisePropertyChanging(SelectedBoardPropertyName);
                var oldValue = _selectedBoard;
                _selectedBoard = value;
                RaisePropertyChanged(SelectedBoardPropertyName, oldValue, value, true);
            }
        }

        public ObservableCollection<ViewModelBase> Workspaces
        {
            get
            {
                if (_workspaces == null)
                {
                    _workspaces = new ObservableCollection<ViewModelBase>();
                }
                return _workspaces;
            }
        }

        public RelayCommand ShowSettingsCommand { get; private set; }

        public RelayCommand PollOnceCommand { get; private set; }

        public RelayCommand StartPollingCommand { get; private set; }

        public RelayCommand StopPollingCommand { get; private set; }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(Manager manager)
        {
            _manager = manager;
            ShowSettingsCommand = new RelayCommand(ShowSettings, () => true);
            PollOnceCommand = new RelayCommand(_manager.Poll, () => true);
            StartPollingCommand = new RelayCommand(_manager.StartPolling,() => !(_manager.PollingTimer.Enabled));
            StopPollingCommand = new RelayCommand(_manager.StopPolling,() => _manager.PollingTimer.Enabled);
           
            Boards = new ObservableCollection<BoardViewModel>();
            Messenger.Default.Register<ViewModelBase>(this, OnWorkSpaceCloseMessage);
            Messenger.Default.Register<IInputs>(this, ShowInputs);
            Messenger.Default.Register<IOutputs>(this, ShowOutputs);
            foreach (var board in _manager.Boards)
            {
                Boards.Add(new BoardViewModel(board));
            }
        }

        #endregion

        void ShowSettings()
        {
            
            if (!this.Workspaces.Contains(ViewModelLocator.Settings))
            {
                this.Workspaces.Add(ViewModelLocator.Settings);
            }

            this.SetActiveWorkspace(ViewModelLocator.Settings);
        }

        void ShowInputs(IInputs model)
        {
            var workspace = new InputsViewModel(model);
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        void ShowOutputs(IOutputs model)
        {
            var workspace = new OutputsViewModel(model);
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }

        void SetActiveWorkspace(ViewModelBase workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        void OnWorkSpaceCloseMessage(ViewModelBase vm)
        {
            this.Workspaces.Remove(vm);
        }
    }
}