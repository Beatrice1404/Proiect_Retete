using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Proiect_Retete.Models;


namespace Proiect_Retete.Data
{
    public class RecipeDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public RecipeDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Recipe>().Wait();
            _database.CreateTableAsync<Ingredient>().Wait();
            _database.CreateTableAsync<ListIngredient>().Wait(); // Adăugați CreateTableAsync pentru ListIngredient
            _database.CreateTableAsync<Restaurant>().Wait();
        }
        public Task<int> SaveIngredientAsync(Ingredient ingredient)
        {
            if (ingredient.ID != 0)
            {
                return _database.UpdateAsync(ingredient);
            }
            else
            {
                return _database.InsertAsync(ingredient);
            }
        }
        public Task<int> DeleteIngredientAsync(Ingredient ingredient)
        {
            return _database.DeleteAsync(ingredient);
        }
        public Task<List<Ingredient>> GetIngredientAsync()
        {
            return _database.Table<Ingredient>().ToListAsync();
        }
        public Task<List<Recipe>> GetRecipeAsync()
        {
            return _database.Table<Recipe>().ToListAsync();
        }
        public Task<Recipe> GetRecipeAsync(int id)
        {
            return _database.Table<Recipe>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveRecipeAsync(Recipe slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteRecipeAsync(Recipe slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveIngredientAsync(ListIngredient listi)
        {
            if (listi.ID != 0)
            {
                return _database.UpdateAsync(listi);
            }
            else
            {
                return _database.InsertAsync(listi);
            }
        }
        public Task<List<Ingredient>> GetIngredientAsync(int recipeid)
        {
            return _database.QueryAsync<Ingredient>(
            "select I.ID, I.Description from Ingredient I"
            + " inner join ListIngredient LI"
            + " on I.ID = LI.IngredientID where LI.RecipeID = ?",recipeid);
        }
        public Task<List<Restaurant>> GetRestaurantsAsync()
        {
            return _database.Table<Restaurant>().ToListAsync();
        }
        public Task<int> SaveRestaurantAsync(Restaurant restaurant)
        {
            if (restaurant.ID != 0)
            {
                return _database.UpdateAsync(restaurant);
            }
            else
            {
                return _database.InsertAsync(restaurant);
            }
        }

    }
}
