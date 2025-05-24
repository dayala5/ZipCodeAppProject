using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ZipCodeAppProject.ViewModels
{
    internal class StartPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _inputZipCode = "";

        private string _errorMessage = "";

        private bool _isErrorMessageVisible = false;

        private bool _isButtonEnabled = false;
        public string InputZipCode
        {
            get => _inputZipCode;
            set
            {
                if (_inputZipCode != value)
                {
                    _inputZipCode = value;
                    OnPropertyChanged();
                    ValidateZipCode();
                }
            }
        }

        public bool IsErrorMessageVisible
        {
            get => _isErrorMessageVisible;
            private set
            {
                if (_isErrorMessageVisible != value)
                {
                    _isErrorMessageVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            private set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsButtonEnabled
        {
            get => _isButtonEnabled;
            private set
            {
                if (_isButtonEnabled != value)
                {
                    _isButtonEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public StartPageViewModel()
        {

        }

        bool IsStringAllDigits(string input)
        {
            foreach(char c in input)
            {
                if(!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        //Validate zip code based on conditions, update error messsage if necessary. If zip code is valid (5 digits) enable submit button.
        private void ValidateZipCode()
        {
            if (string.IsNullOrEmpty(InputZipCode))
            {
                ErrorMessage = "Zip Code is required.";
                IsErrorMessageVisible = true;
                IsButtonEnabled = false;
            }
            else if (!IsStringAllDigits(InputZipCode))
            {
                ErrorMessage = "Zip Code must only contain digits.";
                IsErrorMessageVisible = true;
                IsButtonEnabled = false;
            }
            else if (InputZipCode.Length != 5)
            {
                ErrorMessage = "Zip Code must be 5 digits.";
                IsErrorMessageVisible = true;
                IsButtonEnabled = false;
            }
            else
            {
                ErrorMessage = "";
                IsErrorMessageVisible = true;
                IsButtonEnabled = true;
            }
        }


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
