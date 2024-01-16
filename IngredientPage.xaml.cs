using Proiect_Retete.Models;

namespace Proiect_Retete;

public partial class IngredientPage : ContentPage
{
    Recipe r;
    public IngredientPage(Recipe rec)
    {
        InitializeComponent();
        r = rec;
        BindingContext = new Ingredient();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var ingredient = (Ingredient)BindingContext;

        if (ingredient == null)
        {
            // Handle the case where the BindingContext is null
            return;
        }

        if (!string.IsNullOrWhiteSpace(ingredient.Description))
        {
            // Check if the ingredient already exists in the database
            var existingIngredient = await App.Database.GetIngredientByNameAsync(ingredient.Description);

            if (existingIngredient != null)
            {
                // Ingredient already exists, update its properties
                existingIngredient.Description = ingredient.Description;
                // Update the existing ingredient in the database
                await App.Database.SaveIngredientAsync(existingIngredient);
            }
            else
            {
                // Ingredient does not exist, save the new ingredient
                await App.Database.SaveIngredientAsync(ingredient);
            }

            // Refresh the ListView
            listView.ItemsSource = await App.Database.GetIngredientAsync();
        }
        else
        {
            // Handle the case where the ingredient or its description is null or empty
            // You might want to display an error message or take appropriate action
        }
    }





    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var ingredientNameToDelete = (BindingContext as Ingredient)?.Description;

        if (!string.IsNullOrWhiteSpace(ingredientNameToDelete))
        {
            // Get the ingredient by name
            var ingredientToDelete = await App.Database.GetIngredientByNameAsync(ingredientNameToDelete);

            if (ingredientToDelete != null)
            {
                // Delete the ingredient
                await App.Database.DeleteIngredientAsync(ingredientToDelete);
                // Refresh the ListView
                listView.ItemsSource = await App.Database.GetIngredientAsync();
            }
            else
            {
                // Ingredient not found by name, handle accordingly (display a message, log, etc.)
            }
        }
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetIngredientAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Ingredient selectedIngredient = listView.SelectedItem as Ingredient;

        if (selectedIngredient != null)
        {
            ListIngredient listIngredient = new ListIngredient()
            {
                RecipeID = r.ID,
                IngredientID = selectedIngredient.ID
            };

            // Save the ListIngredient in the database
            await App.Database.SaveIngredientAsync(listIngredient);

            // Retrieve the associated list of ingredients for the recipe
            r.Ingredients = await App.Database.GetIngredientAsync(r.ID);

            // Navigate back to the RecipePage
            await Navigation.PopAsync();
        }
    }


}
