using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Retete.Models
{
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }

        // Foreign key relationship with Recipe
        [ForeignKey(typeof(Recipe))]
        public int RecipeID { get; set; }

        // Reference to the associated recipe
        [ManyToOne]
        public Recipe AssociatedRecipe { get; set; }
    }
}