using Proiect_Retete.Models;

namespace Proiect_Retete
{
    public partial class RecipeEntryPage : ContentPage
    {
        public RecipeEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetRecipesWithRestaurantsAsync();
        }

        async void OnRecipeAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipePage
            {
                BindingContext = new Recipe()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new RecipePage
                {
                    BindingContext = e.SelectedItem as Recipe
                });
            }
        }
    }
}

