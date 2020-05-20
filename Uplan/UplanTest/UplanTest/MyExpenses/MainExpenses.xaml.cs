using LiteDB;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry2 = Microcharts.Entry;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainExpenses : ContentPage
    {
        List<Entry2> ForFood = new List<Entry2>();
        List<Entry2> ForGoingOut = new List<Entry2>();
        public MainExpenses()
        {
            InitializeComponent();
            var col = Database.db.GetCollection<Money>("Money");

            //____________________ Food______________________

            var resultForFood = col.Find(Query.EQ("Type", "Food"));
            float MaxFood = ThisMaxMoney.CurrentMax.MaxForFood;
            float CurrentMoneySpent = 0;
            foreach (var LilFood in resultForFood)
            {
                CurrentMoneySpent += LilFood.Amount;
            }

            ForFood.Add(
                new Entry2(CurrentMoneySpent)
            {
                Color = SKColor.Parse("#FF1493"),
                Label = "Current Money Spend on Food",
                ValueLabel = CurrentMoneySpent.ToString(),

            });

            ForFood.Add(
            new Entry2(MaxFood)
            {
                Color = SKColor.Parse("#00BFFF"),
                Label = "Max Money On Food",
                ValueLabel = MaxFood.ToString()

            });
            ChartFood.Chart = new Microcharts.BarChart() { Entries = ForFood };
            //______________________________________________________________
            //______________________ Going Out _____________________________
            var resultForGoingOut = col.Find(Query.EQ("Type", "Going Out"));
            float MaxGoingOut = ThisMaxMoney.CurrentMax.MaxForGoingOut;
            float CurrentMoneySpentGO = 0;
            foreach (var lilres in resultForGoingOut)
            {
                CurrentMoneySpentGO += lilres.Amount;
            }

            ForGoingOut.Add(
                new Entry2(CurrentMoneySpent)
                {
                    Color = SKColor.Parse("#FF1493"),
                    Label = "Current Money Spend on Going Out",
                    ValueLabel = CurrentMoneySpent.ToString(),

                });

            ForGoingOut.Add(
            new Entry2(MaxFood)
            {
                Color = SKColor.Parse("#00BFFF"),
                Label = "Max Money to go out and have fun",
                ValueLabel = MaxGoingOut.ToString()    });
            ChartGoingOut.Chart = new Microcharts.BarChart() { Entries = ForGoingOut };

        }
        private async void GoToFood(object sender, EventArgs args)
        {
            
        }


    }
}