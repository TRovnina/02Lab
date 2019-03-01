using System.Windows;
using System.Windows.Controls;
using _02Lab.Tools.Manager;
using _02Lab.Tools.Navigation;
using _02Lab.ViewModel;

namespace _02Lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContent
    {
        public ContentControl ContentControl
        {
            get { return ControlContent; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            StaticManager.Initialize();
            NavigationManager.Instance.Initialize(new NavigationInitialization(this));
            NavigationManager.Instance.Navigate(ViewType.LogIn);
        }
    }
}
