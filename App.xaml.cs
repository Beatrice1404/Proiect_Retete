using System;
using Proiect_Retete.Data;
using System.IO;

namespace Proiect_Retete
{
    public partial class App : Application
    {
        static RecipeDatabase database;
        public static RecipeDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   RecipeDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Recipe.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}