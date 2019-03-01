using _02Lab.Tools.Navigation;
using _02Lab.ViewModel;

namespace _02Lab.View
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
