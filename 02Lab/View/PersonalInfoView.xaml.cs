using _Laboratory02.Tools.Navigation;
using _Laboratory02.ViewModel;

namespace _Laboratory02.View
{
    /// <summary>
    /// Interaction logic for PersonalInfoView.xaml
    /// </summary>
    public partial class PersonalInfoView : INavigatable
    {
        public PersonalInfoView()
        {
            InitializeComponent();
            DataContext = new PersonalInfoViewModel();
        }
    }
}
