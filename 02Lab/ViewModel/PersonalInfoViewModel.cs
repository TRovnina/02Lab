using System.Windows.Input;
using _02Lab.Tools;
using _02Lab.Tools.Manager;
using _02Lab.Tools.Navigation;

namespace _02Lab.ViewModel
{
    internal class PersonalInfoViewModel: BasicViewModel
    { 
        #region Commands
        private ICommand _returnCommand;
        #endregion

        #region Properties

        public string Name
        {
            get
            {
                return StaticManager.CurrentPerson.Name;
            }
        }

        public string Surname
        {
            get
            {
                return StaticManager.CurrentPerson.Surname;
            }
        }

        public string Birthday
        {
            get
            {
                return StaticManager.CurrentPerson.Birthday.Day + "." 
                       + StaticManager.CurrentPerson.Birthday.Month + "." 
                       + StaticManager.CurrentPerson.Birthday.Year;
            }
        }

        public string Email
        {
            get
            {
                return StaticManager.CurrentPerson.Email;
            }
            
        }
        
        public string IsAdult
        {
            get
            {
                return StaticManager.CurrentPerson.IsAdult + "      age = " 
                                                           + StaticManager.CurrentPerson.Age;
            }
        }

        public string SunSign
        {
            get
            {
                return StaticManager.CurrentPerson.SunSign;
            }
        }

        public string ChineseSign
        {
            get
            {
                return StaticManager.CurrentPerson.ChineseSign;
            }
        }

        public string IsBirthday
        {
            get
            {
                if(StaticManager.CurrentPerson.IsBirthday)
                    return StaticManager.CurrentPerson.IsBirthday
                    + "     Happy Birthday, " + Name + "!";

                return ""+StaticManager.CurrentPerson.IsBirthday;
            }
        }

        #endregion

        public ICommand ReturnCommand
        {
            get
            {
                return _returnCommand ?? (_returnCommand = new RelayCommand<object>(
                           o =>
                           {
                               NavigationManager.Instance.Navigate(ViewType.LogIn);
                           }));
            }
        }
    }
}
