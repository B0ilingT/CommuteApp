using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommuteApp.Core.Models.Bikes;
using CommuteApp.Core.Models.Stations;
using CommuteApp.Data.Interfaces; 

namespace CommuteApp.ViewModels
{
    //Implement sorting when clicking headers,
    //implement filtering, implement searching, implement click to open google maps, by default order by proxixity to user
    public class MainWindowViewModel
    {
        private readonly IBikeApiClient _bikeApiClient;

        public ObservableCollection<BikeStation> Stations { get; set; }
        public ObservableCollection<Bike> Bikes { get; set; }

        public MainWindowViewModel(IBikeApiClient bikeApiClient)
        {
            _bikeApiClient = bikeApiClient;
            Stations = new ObservableCollection<BikeStation>();
            Bikes = new ObservableCollection<Bike>();

            LoadDataAsync();
        }

        private async void LoadDataAsync()
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
            foreach (var station in Stations) // I dont like this / its not the most efficient
            {
                station.NumberOfBikes = station.Bikes.Count;
                station.NumberOfElectricBikes = station.Bikes.OfType<ElectricBike>().Count();
            }
        }
    }
}
