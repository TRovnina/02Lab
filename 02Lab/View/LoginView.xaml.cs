using _02Lab.ViewModel;
using _02Lab.Tools.Navigation;

namespace _02Lab.View
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
