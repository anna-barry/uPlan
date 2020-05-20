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

            (expenses,amounts) =DisplayExepenses(type);
            money.ItemsSource = expenses;
            desc.ItemsSource = amounts;


        }

        public static (List<string>,List<float>) DisplayExepenses(string type)
        {
            List<float> am = new List<float> {};
            List<string> desc = new List<string> {};
            var c = Database.db.GetCollection<Money>("Money");
            var list = c.Find(Query.EQ("Type",type ));
            foreach (var expense in list)
            {
                am.Add(expense.Amount);
                desc.Add(expense.Description);
            }

            return (desc, am);
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
                ret += amount[l] * 10 ^ l;
                l--;
            }
            if (l == 0)
            { return ret; }
            l--;
            int t = -l;
            while (t < 0)
            {
                ret += amount[l] * 10 ^ t;
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