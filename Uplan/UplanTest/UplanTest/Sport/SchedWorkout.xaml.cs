using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedWorkout : ContentPage
    {
        public List<string> ToCall = new List<string>();
        

        //public ObservableCollection<Workout> Workouts { get; } = new ObservableCollection<Workout>();

        public SchedWorkout()
        {
            InitializeComponent();
            

            //___________ Add Content here in case of change __________
            Abs1.Content = Strength;
            Abs2.Content = IronClad;
            Abs3.Content = Obliques;
            Abs4.Content = WOCrunches;
            Abs5.Content = SumAb1;
            Abs6.Content = SumAb2;
            Arms1.Content = ForArms1;
            Arms2.Content = ForArms2;
            Arms3.Content = ForArms3;
            Arms4.Content = ForArms4;
            Arms5.Content = ForArms5;
            Arms6.Content = ForArms6;
            Leg1.Content = ForLeg1;
            Leg2.Content = ForLeg2;
            Leg3.Content = ForLeg3;
            Leg4.Content = ForLeg4;
            Leg5.Content = ForLeg5;
            Leg6.Content = ForLeg6;
            Glutes1.Content = ForGlutes1;
            Glutes2.Content = ForGlutes2;
            Glutes3.Content = ForGlutes3;
            Glutes4.Content = ForGlutes4;
            Glutes5.Content = ForGlutes5;
            Glutes6.Content = ForGlutes6;
            FullBody1.Content = ForFullBody1;
            FullBody2.Content = ForFullBody2;
            FullBody3.Content = ForFullBody3;
            FullBody4.Content = ForFullBody4;
            FullBody5.Content = ForFullBody5;
            FullBody6.Content = ForFullBody6;
            //___________________________________________________________

            /*ToCall.Add("hello world");
            ToCall.Add("this is me");
            ToCall.Add("life should be");
            ToCall.Add("fun for everyone");
            ToCall.Add("hum hum");
            ToCall.Add("yeah");*/

            ListViewFor.ItemsSource = ToCall;


        }
        
        private async void OnCloseClicked2(object sender, EventArgs args)
        {

            await Navigation.PopAsync();

        }

        private async void GoToSave(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        //_________________ ABS
        private async void GetInfoAbs1(object sender, EventArgs args)
        {
            ShowDescI("Abs1");
        }

        private async void AddAbs1(object sender, EventArgs args)
        {
           
                 await Navigation.PushAsync(new SaveWorkoutLater());


        }

        private async void GetInfoAbs2(object sender, EventArgs args)
        {
            ShowDescI("Abs2");

        }

        private async void AddAbs2(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoAbs3(object sender, EventArgs args)
        {
            ShowDescI("Abs3");
        }

        private async void AddAbs3(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoAbs4(object sender, EventArgs args)
        {
            ShowDescI("Abs4");
        }

        private async void AddAbs4(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoAbs5(object sender, EventArgs args)
        {
            ShowDescI("Abs5");
        }

        private async void AddAbs5(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SaveWorkoutLater());
        }

        private async void GetInfoAbs6(object sender, EventArgs args)
        {
            ShowDescI("Abs6");
        }

        private async void AddAbs6(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SaveWorkoutLater());
        }


        //__________ Arms
        private async void GetInfoArms1(object sender, EventArgs args)
        {
            ShowDescI("Arms1");

        }

        private async void AddArms1(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoArms2(object sender, EventArgs args)
        {
            ShowDescI("Arms2");

        }

        private async void AddArms2(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoArms3(object sender, EventArgs args)
        {

            ShowDescI("Arms3");
        }

        private async void AddArms3(object sender, EventArgs args)
        {


            await Navigation.PushAsync(new SaveWorkoutLater());
        }

        private async void GetInfoArms4(object sender, EventArgs args)
        {

            ShowDescI("Arms4");
        }

        private async void AddArms4(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoArms5(object sender, EventArgs args)
        {

            ShowDescI("Arms");
        }

        private async void AddArms5(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoArms6(object sender, EventArgs args)
        {

            ShowDescI("Arms");
        }

        private async void AddArms6(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        //_________________ Leg
        private async void GetInfoLeg1(object sender, EventArgs args)
        {

            ShowDescI("Leg1");
        }

        private async void AddLeg1(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoLeg2(object sender, EventArgs args)
        {

            ShowDescI("Leg2");
        }

        private async void AddLeg2(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoLeg3(object sender, EventArgs args)
        {
            ShowDescI("Leg3");

        }

        private async void AddLeg3(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoLeg4(object sender, EventArgs args)
        {

            ShowDescI("Leg4");
        }

        private async void AddLeg4(object sender, EventArgs args)
        {


            await Navigation.PushAsync(new SaveWorkoutLater());
        }

        private async void GetInfoLeg5(object sender, EventArgs args)
        {
            ShowDescI("Leg5");

        }

        private async void AddLeg5(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoLeg6(object sender, EventArgs args)
        {
            ShowDescI("Leg6");

        }

        private async void AddLeg6(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SaveWorkoutLater());


        }

        //__________________ Booty 
        private async void GetInfoGlutes1(object sender, EventArgs args)
        {
            ShowDescI("Booty1");
        }

        private async void AddGlutes1(object sender, EventArgs args)
        {


            await Navigation.PushAsync(new SaveWorkoutLater());
        }

        private async void GetInfoGlutes2(object sender, EventArgs args)
        {
            ShowDescI("Booty2");

        }

        private async void AddGlutes2(object sender, EventArgs args)
        {


            await Navigation.PushAsync(new SaveWorkoutLater());
        }

        private async void GetInfoGlutes3(object sender, EventArgs args)
        {
            ShowDescI("Booty3");

        }

        private async void AddGlutes3(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoGlutes4(object sender, EventArgs args)
        {
            ShowDescI("Booty4");

        }

        private async void AddGlutes4(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoGlutes5(object sender, EventArgs args)
        {
            ShowDescI("Booty5");

        }

        private async void AddGlutes5(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoGlutes6(object sender, EventArgs args)
        {

            ShowDescI("Booty6");
        }

        private async void AddGlutes6(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SaveWorkoutLater());


        }

        //__________ Full Body
        private async void GetInfoFullBody1(object sender, EventArgs args)
        {
            ShowDescI("Body1");
        }

        private async void AddFullBody1(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SaveWorkoutLater());


        }

        private async void GetInfoFullBody2(object sender, EventArgs args)
        {
            ShowDescI("Body2");

        }

        private async void AddFullBody2(object sender, EventArgs args)
        {


            await Navigation.PushAsync(new SaveWorkoutLater());
        }

        private async void GetInfoFullBody3(object sender, EventArgs args)
        {
            ShowDescI("Body3");
        }

        private async void AddFullBody3(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new SaveWorkoutLater());

        }

        private async void GetInfoFullBody4(object sender, EventArgs args)
        {
            ShowDescI("Body4");
        }

        private async void AddFullBody4 (object sender, EventArgs args)
        {


            await Navigation.PushAsync(new SaveWorkoutLater());
        }

        private async void GetInfoFullBody5(object sender, EventArgs args)
        {
            ShowDescI("Body5");
        }

        private async void AddFullBody5(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SaveWorkoutLater());


        }

        private async void GetInfoFullBody6(object sender, EventArgs args)
        {
            ShowDescI("Body6");
        }

        private async void AddFullBody6(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SaveWorkoutLater());


        }

        public void ShowDescI(string type)
        {
            //recupérer la list des etry coresponndant au type
            var col = Database.db.GetCollection<ListEntry>("ListEntries");
            var exercices = col.Find(Query.EQ("Type", type));

            string show = "";

        foreach (var exe in exercices)
            {
                show += exe.Description +"\n";
            }

            DisplayAlert("Workout description",show, "ok wow");
        }

        public void SaveExercice(string type)
        {
            var col = Database.db.GetCollection<ListEntry>("ListEntries");
            var exercices = col.Find(Query.EQ("Type", type));
            foreach (var exe in exercices)
            {
                //Exercie= exe.Description;
            }
        }

    }
}