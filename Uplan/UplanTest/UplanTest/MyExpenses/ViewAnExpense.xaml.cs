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
        string type;
        string description;
        float amount;

        public ViewAnExpense(string type)
        {
            InitializeComponent();
            this.type = type;
            typee.Text = "See Expenses for " + type;
            tyype.Text = "Add a new expense in " + type;
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
                    list.Remove(desc.SelectedItem.ToString());
                    while (thisItem[i] != ' ')
                    {
                        res += thisItem[i];
                        i += 1;
                    }
                    var col = Database.db.GetCollection<Money>("Money");
                    var resultforItem = col.FindOne(Query.EQ("Description", res));
                    col.Delete(resultforItem.Id);

                    desc.ItemsSource = null;
                    desc.ItemsSource = list;
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
                    if (expense.Description!=null)
                    {
                        desc.Add(expense.Description + AddSpaces(expense.Description.Length) + expense.Amount);

                    }
                   // desc.Add(expense.Description + AddSpaces(expense.Description.Length) + expense.Amount);
                }
            
            

            return desc;
        }
        async void OnSaveClicked(object sender, EventArgs args)
        {
            description = descc.Text;
            amount = Convert(amountt.Text);
            Money.AddMoney(amount, description, type);
            await Navigation.PushAsync(new ViewAnExpense(type));
        }

        public static string AddSpaces(int desc)
        {
            int spaces = 70 - desc;
            string ret = "";
            for (int i = 0; i < spaces; i++)
            {
                ret += " ";
            }
            return ret;
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
            string dec = "";
            string virg = "";
            bool decdid = false;
            int i = 0;
            if (amount!=null)
            {

            
            int l = amount.Length;
            while (i < l)
            {
                if (amount[i] == '.' | amount[i] == ',')
                {
                    decdid = true;
                }
                else
                {
                    if (decdid)
                    {
                        virg += amount[i];
                    }
                    else
                    {
                        dec += amount[i];
                    }
                }
                i++;

            }

            int ld = dec.Length - 1;
            i = 0;
            while (i <= ld)
            {
                ret += (dec[i] % 48) * SquareF(ld - i, 10);
                i++;

            }
            ld = virg.Length;
            i = 0;
            while (i < ld)
            {
                ret += (virg[i] % 48) * SquareF(i + 1, (float)0.1);
                i++;
            }
            }
            return ret;
        }

        public static float SquareF(int rep, float i)
        {
            float y = 1;
            while (rep > 0)
            {
                y = y * i;
                rep--;
            }
            return y;
        }
        async void OnCloseClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MainExpenses());
        }
    }
}