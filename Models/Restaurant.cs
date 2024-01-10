using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Retete.Models
{
    public class Restaurant
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string RestaurantName { get; set; }
        public string Adress { get; set; }
        public string RestaurantDetails
        {
            get
            {
                return RestaurantName + " "+Adress;} }
        [OneToMany]
        public List<Recipe> ShopLists { get; set; }
    }
}
