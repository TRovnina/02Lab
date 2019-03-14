using System.Windows;
using System.Windows.Controls;
using _Laboratory02.Tools.Manager;
using _Laboratory02.Tools.Navigation;
using _Laboratory02.ViewModel;

namespace _Laboratory02
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
