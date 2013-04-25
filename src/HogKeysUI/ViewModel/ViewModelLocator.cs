/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:HogKeysUI.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using HogKeysUI.Model;
using net.willshouse.HogKeys.SimulatorAdapter;
using net.willshouse.HogKeys.SimulatorAdapter.Adapters;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace HogKeysUI.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
       

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<ISimAdapter, DCSAdapter>();
            }
            else
            {
                SimpleIoc.Default.Register<ISimAdapter, DCSAdapter>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<BoardViewModel>();
            SimpleIoc.Default.Register<Manager>();
            SimpleIoc.Default.Register<SettingsViewModel>();


            TestCommand = new RelayCommand<string>(
               m => MessageBox.Show("requested" + m), m => true);
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public Manager Manager
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Manager>();
            }
        }

        public BoardViewModel Board
        {

            get
            {
                return ServiceLocator.Current.GetInstance<BoardViewModel>();
            }
        }

        public static SettingsViewModel Settings {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingsViewModel>();
            }
        }

        public static RelayCommand<string> TestCommand { get; private set; }

        

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}