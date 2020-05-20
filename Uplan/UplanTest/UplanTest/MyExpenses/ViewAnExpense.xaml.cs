using LiteDB;
using Newtonsoft.Json.Converters;
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
    public partial class ViewAnExpense : ContentPage
    {
        List<string> expenses;
        List<float> amounts;
        string type;

        public ViewAnExpense(string type)
        {
            InitializeComponent();
            this.type = type;
            typee.Text = "See Expenses for" + type;
            switch (type)
            {
                case "Food":
                    max.Placeholder = ThisMaxMoney.CurrentMax.MaxForFood.ToString();
                    break;
                case "Going Out":
                    max.Placeholder = ThisMaxMoney.CurrentMax.MaxForGoingOut.ToString();
                    break;
                case "Clothes and accessories":
                    max.Placeholder = ThisMaxMoney.CurrentMax.MaxForClothes.ToString();
                    break;
                case "Health":
                    max.Placeholder = ThisMaxMoney.CurrentMax.MaxForHealth.ToString();
                    break;
                case "Hobbies":
                    max.Placeholder = ThisMaxMoney.CurrentMax.MaxForHobbies.ToString();
                    break;
                case "Other":
                    max.Placeholder = ThisMaxMoney.CurrentMax.MaxForOthers.ToString();
                    break;
                default:
                    break;
            }

            List<string> list = DisplayExepenses(type);
            desc.ItemsSource = list;

            desc.ItemSelected += async (sender, e) =>
            {
                bool answer = await DisplayAlert("Delete expens", "Do you really want to delete this expense", "No", "Yes");
                if (!answer)
                {
                    string res = "";
                    string thisItem = desc.SelectedItem.ToString();
                    int i = 0;
                    while (thisItem[i] != ' ')
                    {
                        res += thisItem[i];
                        i += 1;
                    }
                    var col = Database.db.GetCollection<Money>("Money");
                    var resultforItem = col.FindOne(Query.EQ("Description", res));
                    col.Delete(resultforItem.Id);

                    desc.ItemsSource = null;
                }


            };
        }
            


        public static List<string> DisplayExepenses(string type)
        {
            List<string> desc = new List<string> { };
            var c = Database.db.GetCollection<Money>("Money");
            var list = c.Find(Query.EQ("Type",type ));
            foreach (var expense in list)
            {
                
                desc.Add(expense.Description+ "               "+ expense.Amount);
            }

            return desc;
        }

        async void OnMaxClicked(object sender, EventArgs args)
        {
            float maxi = Convert(max.Text);
            switch (type)
            {
                case "Food":
                    ThisMaxMoney.UpdateForFood(maxi);
                    break;
                case "Going Out":
                    ThisMaxMoney.UpdateForGoingOut(maxi);
                    break;
                case "Clothes and accessories":
                    ThisMaxMoney.UpdateForClothes(maxi);
                    break;
                case "Health":
                    ThisMaxMoney.UpdateForHealth(maxi);
                    break;
                case "Hobbies":
                    ThisMaxMoney.UpdateForHobbies(maxi);
                    break;
                case "Other":
                    ThisMaxMoney.UpdateForOthers(maxi);
                    break;
                default:
                    break;
            }
        }

        public static float Convert(string amount)
        {
            float ret = 0;
            int l = amount.Length-1;
            while (l > 0 && amount[l] != ',' && amount[l] != '.')
            {
                ret += (amount[l]%48) * (10 ^ l);
                l--;
            }
            if (l == 0)
            { return ret; }
            l--;
            int t = -l;
            while (t < 0)
            {
                ret += (amount[l]%48) * (10 ^ t);
                t++;
            }
            return ret;
        }
        async void OnAddClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddExpenses(type));
        }
        async void OnCloseClicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}