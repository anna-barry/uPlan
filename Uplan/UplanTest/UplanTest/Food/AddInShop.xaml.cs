using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddInShop : ContentPage
    {
        string Type = "";
        string Code = "";
        string Desc = "";
        public DateTime DueDate = DateTime.Now.AddDays(-1);
       
        public AddInShop()
        {
            InitializeComponent();
            // Type = "PROTEIN"
           
           
            

        }

        async void OnSaveClicked2(object sender, EventArgs args)
        {
            var actualSlect = picker.SelectedItem;
            switch (actualSlect)
            {
                case "Protein for strength":
                    Type = "PROTEIN";
                    break;
                case "Carbohydrate for energy":
                    Type = "CARB";
                    break;
                default:
                    Type = "VEGGIES";
                    break;
            }

            
            Code = DescForType.Text;
            Code= Code.ToUpper();
            Desc = DescForType.Text;
            var col = Database.db.GetCollection<FoodItem>("FoodForShoppingList");
            FoodItem.InsertFoodItem(Type, Code, Desc, DueDate);
            FoodItem thisAdd = FoodItem.getEntryfromTypeAndCode(Type, Code);
            col.Insert(thisAdd);

            Shopping_List.RefreshView();
            await Navigation.PopAsync();
            

        }

        private async void OnCloseClicked2(object sender, EventArgs args)
        {
            
            Shopping_List.RefreshView();
            await Navigation.PopAsync();
            
        }
    }
}