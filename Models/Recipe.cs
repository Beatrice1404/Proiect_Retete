using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Retete.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(250), Unique]
        public string Description { get; set; }
        public DateTime Date { get; set; }

        // Foreign key relationship with Restaurant
        [ForeignKey(typeof(Restaurant))]
        public int RestaurantID { get; set; }

        // Reference to the associated restaurant
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Restaurant AssociatedRestaurant { get; set; }

        // Property to hold the associated ingredients
        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public List<Ingredient> Ingredients { get; set; }

        // Add a property to get RestaurantDetails based on the associated restaurant
        public string RestaurantDetails => AssociatedRestaurant?.RestaurantDetails;
    }
}
