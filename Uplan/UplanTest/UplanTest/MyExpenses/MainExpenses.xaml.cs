using LiteDB;
using SkiaSharp;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry2 = Microcharts.Entry;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainExpenses : ContentPage
    {
        
        
        public MainExpenses()
        {
            InitializeComponent();

            
            //____________________ Food__________________________________________________________________________________________________________________

            ChartFood.Chart = new Microcharts.BarChart() { Entries = InitiateChart("Food", ThisMaxMoney.CurrentMax.MaxForFood) };
            ChartFood.Chart.BackgroundColor = SKColors.Transparent;
            //______________________ Going Out ____________________________________________________________________________________________________________
            ChartGoingOut.Chart = new Microcharts.BarChart() { Entries = InitiateChart("Going Out", ThisMaxMoney.CurrentMax.MaxForGoingOut) };
            ChartGoingOut.Chart.BackgroundColor = SKColors.Transparent;
            //________________________ Clothes ____________________________________________________________________________________________________________
            ChartClothes.Chart = new Microcharts.BarChart() { Entries = InitiateChart("Clothes and accessories", ThisMaxMoney.CurrentMax.MaxForClothes) };
            ChartClothes.Chart.BackgroundColor = SKColors.Transparent;
            //___________________________________________ Health____________________________________________________________________________________________
            ChartHealth.Chart = new Microcharts.BarChart() { Entries = InitiateChart("Health", ThisMaxMoney.CurrentMax.MaxForHealth) };
            ChartHealth.Chart.BackgroundColor = SKColors.Transparent;
            //___________________________________________ Hobbies ____________________________________________________________________________________________
            ChartHobbies.Chart = new Microcharts.BarChart() { Entries = InitiateChart("Hobbies", ThisMaxMoney.CurrentMax.MaxForHobbies) };
            ChartHobbies.Chart.BackgroundColor = SKColors.Transparent;
            //___________________________________________ Other ____________________________________________________________________________________________
            ChartOther.Chart = new Microcharts.BarChart() { Entries = InitiateChart("Other", ThisMaxMoney.CurrentMax.MaxForOthers) };
            ChartOther.Chart.BackgroundColor = SKColors.Transparent;


            //_________________________________________GlobalChart_________________________________________________________________________________________
            Global.Chart = new Microcharts.DonutChart() { Entries = MakeCurrentChart()};
            Global.Chart.BackgroundColor = SKColors.Transparent;

            //_________________________________________ShowMaxChart________________________________________________________________________________________
            Max.Chart = new Microcharts.DonutChart() { Entries = MakeMaxChart() };
            Max.Chart.BackgroundColor= SKColors.Transparent;

        }
        public List<Entry2> MakeMaxChart()
        {
            float[] type = new float[] { ThisMaxMoney.CurrentMax.MaxForFood, ThisMaxMoney.CurrentMax.MaxForGoingOut, ThisMaxMoney.CurrentMax.MaxForClothes, ThisMaxMoney.CurrentMax.MaxForHealth, ThisMaxMoney.CurrentMax.MaxForHobbies, ThisMaxMoney.CurrentMax.MaxForOthers };
            List<Entry2> ret = new List<Entry2>();
            int i = 0;
            string color = "";
            foreach (var tyype in type)
            {
                switch (i)
                {
                    case 0:
                        color = "#FF1943";
                        break;
                    case 1:
                        color = "#00ccff";
                        break;
                    case 2:
                        color = "#77d065";
                        break;
                    case 3:
                        color = "#b455b6";
                        break;
                    case 4:
                        color = "#00CED1";
                        break;
                    case 5:
                        color = "#9966ff";
                        break;
                    default:
                        break;
                }
                i++;
                ret.Add(
            new Entry2(tyype)
            {
                Color = SKColor.Parse(color),
                Label = "Max Money that should be spent",
                ValueLabel = tyype.ToString()

            });
            }
            return ret;
        }
        public List<Entry2> MakeCurrentChart()
        {
            string[] type = new string[] { "Food", "Going out", "Clothes and accessories", "Health", "Hobbies", "Other" };
            var col = Database.db.GetCollection<Money>("Money");
            List<Entry2> ret = new List<Entry2>();
            int i = 0;
            foreach (var tyype in type)
            {
                var result = col.Find(Query.EQ("Type", tyype));
                float cur = 0;
                string color= "#8043b4";
                foreach (var lilres in result)
                {
                    cur += lilres.Amount;
                }

                switch(i)
                {
                    case 0:
                        color = "#FF1943";
                        break;
                    case 1:
                        color = "#00ccff";
                        break;
                    case 2:
                        color = "#77d065";
                        break;
                    case 3:
                        color = "#b455b6";
                        break;
                    case 4:
                        color = "#00CED1";
                        break;
                    case 5:
                        color = "#9966ff";
                        break;
                    default:
                        break;
                }
                ret.Add(
                new Entry2(cur)
                {
                    Color = SKColor.Parse(color),
                    Label = "Current Money Spend on " + tyype,
                    ValueLabel = cur.ToString(),


                });
                i++;
            }
            return ret;
        }
        public List<Entry2> InitiateChart(string Type, float Max)
        {
            var col = Database.db.GetCollection<Money>("Money");
            List<Entry2> res = new List<Entry2>();
            var result = col.Find(Query.EQ("Type", Type));
            
            float Currents = 0;
            foreach (var lilres in result)
            {
                Currents += lilres.Amount;
            }

            res.Add(
                new Entry2(Currents)
                {
                    Color = SKColor.Parse("#8043b4"),
                    Label = "Current Money Spend on "+Type,
                    ValueLabel = Currents.ToString(),
                    

                });

            res.Add(
            new Entry2(Max)
            {
                Color = SKColor.Parse("#4a5394"),
                Label = "Max Money that should be spent",
                ValueLabel = Max.ToString()

            });
            return res;
        }

        private async void GoToFood(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ViewAnExpense("Food"));
        }
        private async void GoToGoOut(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ViewAnExpense("Going Out"));
        }
        private async void GoToClothes(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ViewAnExpense("Clothes and accessories"));
        }
        private async void GoToHealth(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ViewAnExpense("Health"));
        }
        private async void GoToHobbies(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ViewAnExpense("Hobbies"));
        }
        private async void GoToOther(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ViewAnExpense("Other"));
        }

        public void RefreshMoney(object sender, EventArgs args)
        {
            var col = Database.db.GetCollection<Money>("Money");
            col.DeleteAll();
            RefreshAllView();
        }

        public void RefreshAllView()
        {
            ChartFood.Chart = new Microcharts.BarChart() { Entries = InitiateChart("Food", ThisMaxMoney.CurrentMax.MaxForFood) };
            ChartFood.Chart.BackgroundColor = SKColors.Transparent;
            //______________________ Going Out ____________________________________________________________________________________________________________
            ChartGoingOut.Chart = new Microcharts.BarChart() { Entries = InitiateChart("Going Out", ThisMaxMoney.CurrentMax.MaxForGoingOut) };
            ChartGoingOut.Chart.BackgroundColor = SKColors.Transparent;
            //________________________ Clothes ____________________________________________________________________________________________________________
            ChartClothes.Chart = new Microcharts.BarChart() { Entries = InitiateChart("Clothes and accessories", ThisMaxMoney.CurrentMax.MaxForClothes) };
            ChartClothes.Chart.BackgroundColor = SKColors.Transparent;
            //___________________________________________ Health____________________________________________________________________________________________
            ChartHealth.Chart = new Microcharts.BarChart() { Entries = InitiateChart("Health", ThisMaxMoney.CurrentMax.MaxForHealth) };
            ChartHealth.Chart.BackgroundColor = SKColors.Transparent;
            //___________________________________________ Hobbies ____________________________________________________________________________________________
            ChartHobbies.Chart = new Microcharts.BarChart() { Entries = InitiateChart("Hobbies", ThisMaxMoney.CurrentMax.MaxForHobbies) };
            ChartHobbies.Chart.BackgroundColor = SKColors.Transparent;
            //___________________________________________ Other ____________________________________________________________________________________________
            ChartOther.Chart = new Microcharts.BarChart() { Entries = InitiateChart("Other", ThisMaxMoney.CurrentMax.MaxForOthers) };
            ChartOther.Chart.BackgroundColor = SKColors.Transparent;
        }

    }
}