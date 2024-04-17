using Formula1.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;

namespace Formula1;

public partial class GarePage : ContentPage
{
    private string urlCircuit = "https://ergast.com/api/f1/2001.json";
    private readonly HttpClient _httpClient;
    public ObservableCollection<Race> Races { get; set; } = new();
    public GarePage()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
        BindingContext = this;
        collectionViewGare.ItemsSource = Races;
       
    }

    protected override async void OnAppearing()
    {
        
        base.OnAppearing();
        onLoading();
        LoadingIndicator.IsVisible = true;
    }

    private async void onLoading()
    {
        Races.Clear();
        RaceRoot response = await _httpClient.GetFromJsonAsync<RaceRoot>(urlCircuit);
        response.MRData.RaceTable.Races.ForEach(race => Races.Add(race));

        LoadingIndicator.IsVisible = false;
    }

    private void MinusButton_Clicked(object sender, EventArgs e)
    {

    }

    private void PlusButton_Clicked(object sender, EventArgs e)
    {

    }

    private void ValueEntry_TextChanged(object sender, TextChangedEventArgs e)
    {

    }
} 