using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using CommuteApp.Core.Interfaces.Stations;
using CommuteApp.Core.Models.Bikes;
using CommuteApp.Core.Models.Stations;
using CommuteApp.Data.Interfaces; 

namespace CommuteApp.ViewModels
{
    //Implement sorting when clicking headers,
    //implement filtering, implement searching, implement click to open google maps, by default order by proxixity to user
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IBikeApiClient _bikeApiClient;
        private string _bikeSearchText;

        public ObservableCollection<BikeStation> Stations { get; set; }
        public ObservableCollection<BikeStation> FilteredStations { get; set; }
        public ObservableCollection<Bike> Bikes { get; set; }

        public string BikeSearchText
        {
            get => _bikeSearchText;
            set
            {
                _bikeSearchText = value;
                OnPropertyChanged(nameof(BikeSearchText));
                FilterStations();
            }
        }

        public MainWindowViewModel(IBikeApiClient bikeApiClient)
        {
            _bikeApiClient = bikeApiClient;
            Stations = new ObservableCollection<BikeStation>();
            FilteredStations = new ObservableCollection<BikeStation>();
            Bikes = new ObservableCollection<Bike>();

            LoadDataAsync();
        }

        public async void LoadDataAsync()
        {
            List<BikeStation> stations = await _bikeApiClient.GetBikeStationsAsync();
            foreach (var station in stations)
            {
                Stations.Add(station);
            }

            var bikes = await _bikeApiClient.GetBikesAsync();
            foreach (var bike in bikes)
            {
                Bikes.Add(bike);
                Stations.Where(s => s.ID == bike.StationId).FirstOrDefault()?.Bikes.Add(bike);
            }

            foreach (var station in Stations)
            {
                station.NumberOfBikes = station.Bikes.Count;
                station.NumberOfElectricBikes = station.Bikes.OfType<ElectricBike>().Count();
            }

            FilterStations();
        }

        public void FilterStations()
        {
            FilteredStations.Clear();
            var filtered = Stations
                .Where(station => station.Name.ToLower().Contains(BikeSearchText?.ToLower() ?? string.Empty))
                .ToList();

            foreach (var station in filtered)
            {
                FilteredStations.Add(station);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
