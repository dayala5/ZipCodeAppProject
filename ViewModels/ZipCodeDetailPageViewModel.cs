using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ZipCodeAppProject.Models;

namespace ZipCodeAppProject.ViewModels
{
    public class ZipCodeDetailPageViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ZipLookupResponse? _zipCodeDetails;
        private ObservableCollection<Place> _placesData = new ObservableCollection<Place>();

        public ZipLookupResponse? ZipCodeDetails
        {
            get => _zipCodeDetails;
            set
            {
                _zipCodeDetails = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Place> PlacesData
        {
            get => _placesData;
            set
            {
                _placesData = value;
                OnPropertyChanged();
            }
        }
        //Receive API response from StartPage and update properties accordingly
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            ZipCodeDetails = query["ZipLookupResponse"] as ZipLookupResponse;

            PlacesData = new ObservableCollection<Place>(ZipCodeDetails?.Places ?? new List<Place>());
            
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
