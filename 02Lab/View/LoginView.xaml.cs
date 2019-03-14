using _Laboratory02.ViewModel;
using _Laboratory02.Tools.Navigation;

namespace _Laboratory02.View
{
    /// <summary>
    /// Interaction logic for LoginPageControl.xaml
    /// </summary>
    public partial class LoginView : INavigatable
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

    }
}
