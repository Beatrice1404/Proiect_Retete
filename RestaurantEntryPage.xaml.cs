using Proiect_Retete.Models;

namespace Proiect_Retete;

public partial class RestaurantEntryPage : ContentPage
{
	public RestaurantEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRestaurantsAsync();
    }
    async void OnRestaurantAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RestaurantPage
        {
            BindingContext = new Restaurant()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new RestaurantPage
            {
                BindingContext = e.SelectedItem as Restaurant
            });
        }
    }

}