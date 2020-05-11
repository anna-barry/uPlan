using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

using System.Linq;

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
        int amount = 0;
       
        public AddInShop()
        {
            InitializeComponent();

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
            amount = (int) pickerAmount.SelectedItem;

            var col = Database.db.GetCollection<FoodItem>("FoodForShoppingList");
            FoodItem.InsertFoodItem(Type, Code, Desc, DueDate,amount);
            FoodItem thisAdd = FoodItem.getEntryfromTypeAndCode(Type, Code);
            
            var resultforthis = col.FindOne(Query.And(Query.EQ("NameCode", Code), Query.EQ("Type", Type)));
            if (resultforthis!=null)
            {
                resultforthis.Amount += amount;
                col.Update(resultforthis);
            }
            else
            {
                col.Insert(thisAdd);
            }
            

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