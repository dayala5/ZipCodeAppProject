using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ZipCodeAppProject.Models;
using ZipCodeAppProject.Services;
using ZipCodeAppProject.Views;

namespace ZipCodeAppProject.ViewModels
{
    internal class StartPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _inputZipCode = "";

        private string _errorMessage = "";

        private bool _isErrorMessageVisible = false;

        private bool _isButtonEnabled = false;

        private readonly IZipLookupService zipCodeService;

        public IAsyncRelayCommand SubmitZipCodeCommand { get; }
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

        public StartPageViewModel(IZipLookupService zipCodeService)
        {
            this.zipCodeService = zipCodeService;
            SubmitZipCodeCommand = new AsyncRelayCommand(SubmitZipCodeExecute);
        }

        private async Task SubmitZipCodeExecute()
        {
            if(string.IsNullOrEmpty(InputZipCode))
            {
                return;
            }

            // Call the API

            ZipLookupResponse? response = await zipCodeService.GetZipInformationAsync(InputZipCode);

            //If the API returned an empty JSON object or in other words it's not a valid zip code
            if(response == null)
            {
                ErrorMessage = "Could not find details about your Zip Code. Please make sure your Zip Code is valid.";
                IsErrorMessageVisible = true;
                IsButtonEnabled = false;
                return;
            }

            Debug.WriteLine("HERE" + response);

            //Navigate to second screen
            var navigationParameter = new Dictionary<string, object>
            {
                { "ZipLookupResponse", response}
            };
            await Shell.Current.GoToAsync(nameof(ZipCodeDetailPage), navigationParameter);
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
                IsErrorMessageVisible = false;
                IsButtonEnabled = true;
            }
        }
        bool IsStringAllDigits(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
