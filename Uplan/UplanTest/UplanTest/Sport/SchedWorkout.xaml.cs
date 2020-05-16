using LiteDB;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedWorkout : ContentPage
    {
       

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


        }
        
        private async void OnCloseClicked2(object sender, EventArgs args)
        {

            await Navigation.PopAsync();

        }

       

        //_________________ ABS
        private async void GetInfoAbs1(object sender, EventArgs args)
        {
            ShowDescI("Abs1");
        }

        private async void AddAbs1(object sender, EventArgs args)
        {
            
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Abs1");
               await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Strength"));


        }

        private async void GetInfoAbs2(object sender, EventArgs args)
        {
            ShowDescI("Abs2");

        }

        private async void AddAbs2(object sender, EventArgs args)
        {
            
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Abs2");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "IronClad"));
            

        }

        private async void GetInfoAbs3(object sender, EventArgs args)
        {
            ShowDescI("Abs3");
        }

        private async void AddAbs3(object sender, EventArgs args)
        {
            
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Abs3");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Obliques"));

        }

        private async void GetInfoAbs4(object sender, EventArgs args)
        {
            ShowDescI("Abs4");
        }

        private async void AddAbs4(object sender, EventArgs args)
        {
            
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Abs4");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "WOCrunches"));
            

        }

        private async void GetInfoAbs5(object sender, EventArgs args)
        {
            ShowDescI("Abs5");

        }

        private async void AddAbs5(object sender, EventArgs args)
        {
            
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Abs5");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "SumAb1"));

        }

        private async void GetInfoAbs6(object sender, EventArgs args)
        {

            ShowDescI("Abs6");
        }

        private async void AddAbs6(object sender, EventArgs args)
        {
            
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Abs6");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "SumAb2"));
        }


        //__________ Arms
        private async void GetInfoArms1(object sender, EventArgs args)
        {
            ShowDescI("Arms1");

        }

        private async void AddArms1(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Arms1");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Beginner Arm Workout"));

        }

        private async void GetInfoArms2(object sender, EventArgs args)
        {
            ShowDescI("Arms2");

        }

        private async void AddArms2(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Arms2");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Arm Workout challenge "));


        }

        private async void GetInfoArms3(object sender, EventArgs args)
        {

            ShowDescI("Arms3");
        }

        private async void AddArms3(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Arms3");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Burn Arm Fat Workout"));

        }

        private async void GetInfoArms4(object sender, EventArgs args)
        {

            ShowDescI("Arms4");
        }

        private async void AddArms4(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Arms4");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Toned Arms Workout"));


        }

        private async void GetInfoArms5(object sender, EventArgs args)
        {

            ShowDescI("Arms5");
        }

        private async void AddArms5(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Arms5");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Big Arms Workout"));


        }

        private async void GetInfoArms6(object sender, EventArgs args)
        {

            ShowDescI("Arms6");
        }

        private async void AddArms6(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Arms6");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Triceps Workout"));


        }

        //_________________ Leg
        private async void GetInfoLeg1(object sender, EventArgs args)
        {

            ShowDescI("Legs1");
        }

        private async void AddLeg1(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Legs1");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Core strengthening Workout"));


        }

        private async void GetInfoLeg2(object sender, EventArgs args)
        {

            ShowDescI("Legs2");
        }

        private async void AddLeg2(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Legs2");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Thigh workout "));


        }

        private async void GetInfoLeg3(object sender, EventArgs args)
        {
            ShowDescI("Legs3");

        }

        private async void AddLeg3(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Legs3");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Toned Legs"));


        }

        private async void GetInfoLeg4(object sender, EventArgs args)
        {

            ShowDescI("Legs4");
        }

        private async void AddLeg4(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Legs4");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Burn Leg Fat"));

        }

        private async void GetInfoLeg5(object sender, EventArgs args)
        {
            ShowDescI("Legs5");

        }

        private async void AddLeg5(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Legs5");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Dumbbell workout"));


        }

        private async void GetInfoLeg6(object sender, EventArgs args)
        {
            ShowDescI("Legs6");

        }

        private async void AddLeg6(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Legs6");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Resistant band workout"));



        }

        //__________________ Booty 
        private async void GetInfoGlutes1(object sender, EventArgs args)
        {
            ShowDescI("Booty1");
        }

        private async void AddGlutes1(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Booty1");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Bubble But Workout"));

        }

        private async void GetInfoGlutes2(object sender, EventArgs args)
        {
            ShowDescI("Booty2");

        }

        private async void AddGlutes2(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Booty2");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Tighten up workout "));

        }

        private async void GetInfoGlutes3(object sender, EventArgs args)
        {
            ShowDescI("Booty3");

        }

        private async void AddGlutes3(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Booty3");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Bodyweight Workout"));


        }

        private async void GetInfoGlutes4(object sender, EventArgs args)
        {
            ShowDescI("Booty4");

        }

        private async void AddGlutes4(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Booty4");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Targeted Glutes Workout"));


        }

        private async void GetInfoGlutes5(object sender, EventArgs args)
        {
            ShowDescI("Booty5");

        }

        private async void AddGlutes5(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Booty5");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Butt Lift Workout"));


        }

        private async void GetInfoGlutes6(object sender, EventArgs args)
        {

            ShowDescI("Booty6");
        }

        private async void AddGlutes6(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Booty6");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Toned Glutes Workout"));



        }

        //__________ Full Body
        private async void GetInfoFullBody1(object sender, EventArgs args)
        {
            ShowDescI("Body1");
        }

        private async void AddFullBody1(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Body1");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Full Body Blast"));


        }

        private async void GetInfoFullBody2(object sender, EventArgs args)
        {
            ShowDescI("Body2");

        }

        private async void AddFullBody2(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Body2");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "High intensity"));

        }

        private async void GetInfoFullBody3(object sender, EventArgs args)
        {
            ShowDescI("Body3");
        }

        private async void AddFullBody3(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Body3");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Full Body Circuit"));


        }

        private async void GetInfoFullBody4(object sender, EventArgs args)
        {
            ShowDescI("Body4");
        }

        private async void AddFullBody4 (object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Body4");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Beginner HIIT"));

        }

        private async void GetInfoFullBody5(object sender, EventArgs args)
        {
            ShowDescI("Body5");
        }

        private async void AddFullBody5(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Body5");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "Strength workout"));



        }

        private async void GetInfoFullBody6(object sender, EventArgs args)
        {
            ShowDescI("Body6");
        }

        private async void AddFullBody6(object sender, EventArgs args)
        {
            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll("Body6");
            await Navigation.PushAsync(new SaveWorkoutLater(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, "No-equipment workout"));

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

        
        
        public (ListEntry ex1,ListEntry ex2,ListEntry ex3,ListEntry ex4,ListEntry ex5,ListEntry ex6,ListEntry ex7, ListEntry ex8,ListEntry ex9,ListEntry ex10) GetAll(string type)
        {
            //recupérer la list des etry coresponndant au type
            var col = Database.db.GetCollection<ListEntry>("ListEntries");
            var exercices = col.Find(Query.EQ("Type", type));
            ListEntry ex1= exercices.ElementAt(0);
            ListEntry ex2 = exercices.ElementAt(1);
            ListEntry ex3= exercices.ElementAt(2); 
            ListEntry ex4 = exercices.ElementAt(3);
            ListEntry ex5 = exercices.ElementAt(4);
            ListEntry ex6 = exercices.ElementAt(5);
            ListEntry ex7 = exercices.ElementAt(6);
            ListEntry ex8 = exercices.ElementAt(7);
            ListEntry ex9 = exercices.ElementAt(8);
            ListEntry ex10= exercices.ElementAt(9);

            return (ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10);


        }

    }
}