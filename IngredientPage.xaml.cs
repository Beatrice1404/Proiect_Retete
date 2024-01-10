using Proiect_Retete.Models;

namespace Proiect_Retete;

public partial class IngredientPage : ContentPage
{
    Recipe r;
    public IngredientPage(Recipe rec)
    {
        InitializeComponent();
        r = rec;

    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var ingredient = (Ingredient)BindingContext;
        await App.Database.SaveIngredientAsync(ingredient);
        listView.ItemsSource = await App.Database.GetIngredientAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var ingredient = (Ingredient)BindingContext;
        await App.Database.DeleteIngredientAsync(ingredient);
        listView.ItemsSource = await App.Database.GetIngredientAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetIngredientAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Ingredient i;
        if (listView.SelectedItem != null)
        {
            i = listView.SelectedItem as Ingredient;
            var li = new ListIngredient()
            {
                RecipeID = r.ID,
                IngredientID = i.ID
            };
            await App.Database.SaveIngredientAsync(li);
            i.ListIngredients = new List<ListIngredient> { li };
            await Navigation.PopAsync();
        }

    }
}