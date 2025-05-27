using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.Input;
using ZipCodeAppProject.Models;
using ZipCodeAppProject.Services;
using ZipCodeAppProject.Views;

namespace ZipCodeAppProject.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
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

            //Assign command on submit button press
            SubmitZipCodeCommand = new AsyncRelayCommand(SubmitZipCodeExecute);
        }

        //On submit button press
        private async Task SubmitZipCodeExecute()
        {
            if(string.IsNullOrEmpty(InputZipCode))
            {
                return;
            }

            // Call the API

            ZipLookupResponse? response = await zipCodeService.GetZipInformationAsync(InputZipCode);

            //If the API returned a 404 error or in other words it's not a valid zip code according to the API (despite being 5 digits)
            if(response == null)
            {
                ErrorMessage = "Could not find details about your Zip Code. Please make sure your Zip Code is valid.";
                IsErrorMessageVisible = true;
                IsButtonEnabled = false;
                return;
            }

            //Navigate to second screen and with API response as a parameter
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "ZipLookupResponse", response}
            };
            await Shell.Current.GoToAsync(nameof(ZipCodeDetailPage), navigationParameter);
        }

        

        //Validate zip code input based on conditions, update error messsage if necessary. If zip code is valid (5 digits), enable submit button.
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
        //Helper function to determine if the given input characters are all digits
        private bool IsStringAllDigits(string input)
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

        //Notifies UI that a property's value has changed
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
