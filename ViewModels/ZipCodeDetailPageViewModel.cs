using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZipCodeAppProject.Models;

namespace ZipCodeAppProject.ViewModels
{
    internal class ZipCodeDetailPageViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ZipLookupResponse? _zipCodeDetails;
        private ObservableCollection<Place>? _dummyData;

        public ZipLookupResponse? ZipCodeDetails
        {
            get => _zipCodeDetails;
            set
            {
                _zipCodeDetails = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Place> DummyData
        {
            get => _dummyData;
            set
            {
                _dummyData = value;
                OnPropertyChanged();
            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            ZipCodeDetails = query["ZipLookupResponse"] as ZipLookupResponse;
            OnPropertyChanged("ZipLookupResponse");

            DummyData = new ObservableCollection<Place>(ZipCodeDetails.Places);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
