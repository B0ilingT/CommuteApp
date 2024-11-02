using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommuteApp.Core.Models.Bikes;
using CommuteApp.Core.Models.Stations;
using CommuteApp.Data.Interfaces; 

namespace CommuteApp.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly IBikeApiClient _bikeApiClient;
        //private readonly ITrainApiClient _trainApiClient;

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
        }
    }
}
