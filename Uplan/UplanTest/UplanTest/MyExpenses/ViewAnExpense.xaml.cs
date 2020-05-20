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
                    //
                    break;
                case "Going Out":
                    //
                    break;
                case "Clothes and accessories":
                    //
                    break;
                case "Health":
                    //
                    break;
                case "Hobbies":
                    //
                    break;
                case "Other":
                    //
                    break;
                default:
                    break;
            }
        }

        public static float Convert(string amount)
        {
            float ret = 0;
            int l = amount.Length;
            while (l > 0 && amount[l] != ',' && amount[l] != '.')
            {
                ret += amount[l] * 10 ^ l;
                l++;
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