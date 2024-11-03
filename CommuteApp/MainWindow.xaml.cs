using CommuteApp.Data.Clients;
using CommuteApp.Data.Interfaces;
using CommuteApp.ViewModels;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommuteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader _lastHeaderClicked;
        private ListSortDirection _lastDirection = ListSortDirection.Ascending;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtBikeSearch_TextChanged(Object sender, TextChangedEventArgs e)
        {
            if (txtBikeSearch.Text != "")
            {
                txtBikeSearchPlaceholder.Visibility = Visibility.Hidden;
            }
            else
            {
                txtBikeSearchPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            var headerClicked = sender as GridViewColumnHeader;
            if (headerClicked == null) return;

            string sortBy = headerClicked.Column.DisplayMemberBinding is Binding binding ? binding.Path.Path : null;
            if (string.IsNullOrEmpty(sortBy)) return;

            ListSortDirection direction = ListSortDirection.Descending;
            if (headerClicked == _lastHeaderClicked && _lastDirection == ListSortDirection.Descending)
                direction = ListSortDirection.Ascending;

            Sort(sortBy, direction);

            _lastHeaderClicked = headerClicked;
            _lastDirection = direction;
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(StationsListView.ItemsSource);

            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(new SortDescription(sortBy, direction));
            dataView.Refresh();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel viewModel)
            {
                viewModel.Stations.Clear();
                viewModel.LoadDataAsync();
            }
        }
    }
}