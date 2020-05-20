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
    public partial class MainExpenses : ContentPage
    {
        public List<string> ToCallKind = new List<string>();
        public List<string> ToCallExpense = new List<string>();
        public List<string> ToCallMax = new List<string>();
        public MainExpenses()
        {
            InitializeComponent();
            var col = Database.db.GetCollection<Money>("Money");
            var result = col.FindAll();

            List<string> Kind = DisplayKind(0);
            kind.ItemsSource = Kind;
            List<int> Expenses = DisplayExpenses(1);
            expenses.ItemsSource = Expenses;
            List<int> Max = DisplayLimit(2);
            limit.ItemsSource = Max;
        }
        public static List<string> DisplayKind(int col)
        {
            List<string> toadd = new List<string> { };

            var co = Database.db.GetCollection<Money>("Money");
            var result = co.FindAll();

            foreach (var kind in result)
            {
                toadd.Add(kind.Type);
            }

            return toadd;
        }
        public static List<int> DisplayExpenses(int col)
        {

            List<int> toadd = new List<int> { };

            var co = Database.db.GetCollection<Money>("Money");
            var result = co.FindAll();

            foreach (var kind in result)
            {
                toadd.Add(kind.Amount);
            }

            return toadd;

        }
        public static List<int> DisplayLimit(int col)
        {
            List<int> toadd = new List<int> { };

            var co = Database.db.GetCollection<Money>("Money");
            var result = co.FindAll();

            foreach (var kind in result)
            {
               // toadd.Add(kind.Max);
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

        //private void RefreshType()
    }
}