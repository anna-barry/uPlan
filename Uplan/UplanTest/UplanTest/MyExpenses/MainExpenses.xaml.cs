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

        }
        private async void GoToClothes(object sender, EventArgs args)
        {

        }
        private async void GoToHealth(object sender, EventArgs args)
        {

        }
        private async void GoToHobbies(object sender, EventArgs args)
        {

        }
        private async void GoToOther(object sender, EventArgs args)
        {

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