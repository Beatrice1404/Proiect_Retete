using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Retete.Models
{
    public class ListIngredient
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Recipe))]
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
    }
}
