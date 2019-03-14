using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using _Laboratory02.Exceptions;
using _Laboratory02.Models;
using _Laboratory02.Tools;
using _Laboratory02.Tools.Manager;
using _Laboratory02.Tools.Navigation;

namespace _Laboratory02.ViewModel
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
            var stop = false;
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                Thread.Sleep(1000);

                try
                {
                    var person = new Person(Name, Surname, Convert.ToDateTime(_birthday), Email);
                    StaticManager.CurrentPerson = person;
                }
                catch (EmailException ex)
                {
                    MessageBox.Show(ex.Message);
                    stop = true;
                }
                catch (AgeException ex)
                {
                    MessageBox.Show(ex.Message);
                    stop = true;
                }
            });

            LoaderManager.Instance.HideLoader();

            if (!stop)
                NavigationManager.Instance.Navigate(ViewType.PersonalInfo);
        }


        private void Close(object obj)
        {
            StaticManager.CloseApp();
        }

    }
}
