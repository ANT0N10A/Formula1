using Formula1.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace Formula1;

public partial class PilotiPage : ContentPage
{
	private string urlDriver = "https://ergast.com/api/f1/2001/drivers.json";
	private readonly HttpClient _httpClient;
	public ObservableCollection<Driver> Drivers { get; set; } = new();
    public PilotiPage()
	{
		InitializeComponent();
		_httpClient = new HttpClient();
		BindingContext = this;
        collectionViewPiloti.ItemsSource = Drivers;

	}
	

    protected override async void OnAppearing() 
	{
			
		base.OnAppearing();
		onLoading();
        LoadingIndicator.IsVisible = true;
    }

    private async void onLoading()
    {
        Drivers.Clear();
		DriverRoot response = await _httpClient.GetFromJsonAsync<DriverRoot>(urlDriver);
		response.MRData.DriverTable.Drivers.ForEach(driver => Drivers.Add(driver));

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