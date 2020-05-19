using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest.MyExpenses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Expenses : ContentView
    {
        public List<string> ToCallKind = new List<string>();
        public List<string> ToCallExpense = new List<string>();
        public List<string> ToCallMax = new List<string>();
        public Expenses()
        {
            InitializeComponent();


            List<string> Kind = DisplayKind(0, ToCallKind);
            kind.ItemsSource = Kind;
            List<string> Expenses = DisplayExpenses(1, ToCallExpense);
            expenses.ItemsSource = Expenses;
            List<string> Max = DisplayLimit(2, ToCallMax);
            limit.ItemsSource = Max;
        }

        public static List<string> DisplayKind(int col, List<string> toadd)
        {

            var c = Database.db.GetCollection<MyExpenses>("Money");
            
            //foreach (var kind in c)
            {
                //toadd.Add(workout.Type);
            }

            return toadd;

        }
        public static List<string> DisplayExpenses(int col, List<string> toadd)
        {

            var c = Database.db.GetCollection<MyExpenses>("Money");
            //var list = c.FindOne(Query.EQ("Type",));
            //foreach (var workout in list)
            {
                //toadd.Add(workout.Type);
            }

            return toadd;

        }
        public static List<string> DisplayLimit(int col, List<string> toadd)
        {

            var c = Database.db.GetCollection<MyExpenses>("Money");
            //var list = c.FindOne(Query.EQ("Type",));
            //foreach (var workout in list)
            {
             //   toadd.Add(workout.Type);
            }

            return toadd;

        }

        private async void OnCloseClicked2(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        private async void AddExpenses(object sender, EventArgs args)
        {
            //Navigation.PushAsync(new AddExpenses());
        }
    }
}