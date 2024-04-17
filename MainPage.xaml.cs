using Formula1.Models;
using System.Collections.ObjectModel;

namespace Formula1
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Race> Races { get; set; } = new();
        public ObservableCollection<Driver> Drivers { get; set; } = new();
        public MainPage()
        {
            InitializeComponent();
        }

        
    }

}
