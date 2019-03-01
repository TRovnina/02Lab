using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using _02Lab.Models;
using _02Lab.Tools;
using _02Lab.Tools.Manager;
using _02Lab.Tools.Navigation;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace _02Lab.ViewModel
{
   internal class LoginViewModel: BasicViewModel
   {
        #region Fields

        private string _name;
        private string _surname;
        private DateTime? _birthday;
        private string _email;
  
        #endregion

        #region Commands

        private ICommand _logInCommand;
        private ICommand _closeCommand;

        #endregion

        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public DateTime? Birthday
        {
            get { return _birthday; }
            set
            {
               _birthday = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
               _email = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand LogInCommand
        {
            get
            {
                return _logInCommand ?? (_logInCommand =
                           new RelayCommand<object>(LogInImplementation, CanLogInExecute));
            }
        }


        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(Close));
            }
        }

        #endregion

        private bool CanLogInExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_surname) &&
                   !string.IsNullOrWhiteSpace(_email) && _birthday != null;
        }

        private async void LogInImplementation(object obj)
        {
            bool stop = false;
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                Thread.Sleep(1000);

                DateTime birthday = Convert.ToDateTime(_birthday);
                int age = CalculateAge(birthday);
                if (age > 135 || age < 0)
                {
                    MessageBox.Show("Wrong birthay! This person should not exist ");
                    stop = true;
                    return;
                }

                if (!new EmailAddressAttribute().IsValid(Email))
                {
                    MessageBox.Show("Wrong Email!");
                    stop = true;
                    return;
                }

                Person person = new Person(Name, Surname, birthday, Email);
                person.Age = age;
                StaticManager.CurrentPerson = person;
            });

            LoaderManager.Instance.HideLoader();
            if (stop) return;

            NavigationManager.Instance.Navigate(ViewType.PersonalInfo);
        }

        //calculate person age
        private int CalculateAge(DateTime birthday)
        {
            DateTime today = DateTime.Today;
            if ((today.Month > birthday.Month) || (today.Month == birthday.Month && today.Day >= birthday.Day))
                return today.Year - birthday.Year;
            
             return today.Year - birthday.Year - 1;
        }

        private void Close(object obj)
        {
            StaticManager.CloseApp();
        }

    }
}
