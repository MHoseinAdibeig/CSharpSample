using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public abstract class ViewModel :Validatable, IViewModel
    {
        private bool _isModified;
        private bool _isLoading;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsModified
        {
            get
            {
                return _isModified;
            }
            set
            {
                if (_isModified != value)
                {
                    _isModified = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    RaisePropertyChanged();
                }
            }
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string property = "")
        {
            RaisePropertyChanged(false, property);
        }

        protected virtual void RaisePropertyChanged(bool causesModification, [CallerMemberName] string property = "")
        {
            IsModified = IsModified || causesModification;

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        /// <summary>
        /// Gets the first error found in the given property
        /// and raises an OnPropertyChange of "HasErrors"
        /// </summary>
        /// <param name="columnName">property name</param>
        /// <returns>the error or empty if no error</returns>
        public override string this[string columnName]
        {
            get
            {
                string retVal = GetError(columnName);

                RaisePropertyChanged(false, "IsValid");

                return retVal;
            }
        }
    }
}
