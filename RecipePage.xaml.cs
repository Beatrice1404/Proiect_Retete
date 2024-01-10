namespace Proiect_Retete;
using Proiect_Retete.Models;
public partial class RecipePage : ContentPage
{
	public RecipePage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Recipe)BindingContext;
        slist.Date = DateTime.UtcNow;
        Restaurant selectedShop = (RestaurantPicker.SelectedItem as Restaurant);
        slist.RestaurantID = selectedShop.ID;
        await App.Database.SaveRecipeAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Recipe)BindingContext;
        await App.Database.DeleteRecipeAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new IngredientPage((Recipe)
       this.BindingContext)
        {
            BindingContext = new Ingredient()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var items = await App.Database.GetRestaurantsAsync();
        RestaurantPicker.ItemsSource = (System.Collections.IList)items;
        RestaurantPicker.ItemDisplayBinding = new Binding("RestaurantDetails");
        var ingr = (Recipe)BindingContext;

        listView.ItemsSource = await App.Database.GetIngredientAsync(ingr.ID);
    }
}