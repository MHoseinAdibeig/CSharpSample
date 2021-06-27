using System.Windows.Input;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using ViewModelTest.Model;
namespace ViewModelTest.ViewModel
{
    class UserViewModel
    {
        private IList<User> _UserList;
        public UserViewModel()
        {
            _UserList = new List<User>
            {
                new User{UserId = 1, FirstName="Mohammad Hossein", LastName = "Adibeig", City = "Tabriz", State = "Azerbaycan", Country = "IRAN" },
                new User { UserId = 2, FirstName = "Mohammad Javad", LastName = "Bahman", City = "Tehran", State = "Tehran", Country = "IRAN" },
                new User { UserId = 3, FirstName = "Izad", LastName = "Nariman", City = "Tehran", State = "Tehran", Country = "IRAN" },
                new User { UserId = 4, FirstName = "Hani", LastName = "Askari", City = "Tehran", State = "Tehran", Country = "IRAN" },
                new User { UserId = 5, FirstName = "Omid", LastName = "Mirza", City = "Tehran", State = "Tehran", Country = "IRAN" },


            };

        }
        public IList<User> Users
        {
            get { return _UserList; }
            set { _UserList = value; }
        }
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
        private class Updater : ICommand
        {
            #region ICommand Members
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged;
            public void Execute(object parameter)
            {

            }
            #endregion
        }
    }
}
