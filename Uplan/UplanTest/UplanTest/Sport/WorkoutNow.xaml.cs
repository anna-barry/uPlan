using LiteDB;
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
    public partial class WorkoutNow : ContentPage
    {
        public List<string> Contents=new List<string>();
        public ListView ListVieww = new ListView();
        public WorkoutNow()
        {
           // Contents = null;
            
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

            var c = Database.db.GetCollection<Workout>("AllWorkouts");
            var listOfWorkouts = c.Find(Query.EQ("DueDate", DateTime.Now.Date));
            foreach (var item in listOfWorkouts)
            {
                Contents.Add(item.Type + ": " + "\n" + item.Exercice1.Description + "\n" + item.Exercice2.Description + "\n" + item.Exercice3.Description + "\n" + item.Exercice4.Description + "\n" + item.Exercice5.Description + "\n" + item.Exercice6.Description + "\n" +
                item.Exercice7.Description + "\n" + item.Exercice8.Description + "\n" + item.Exercice9.Description + "\n" + item.Exercice10.Description + "\n" + "\n");
            }




            ListVieww.ItemsSource = Contents;
            ListVieww.SelectedItem = SelectionMode.None;
            ListVieww.SeparatorColor = Color.Lavender;
            ListVieww.RefreshControlColor = Color.LightPink;
            Framing.Content = ListVieww;

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
            NewAdd("Strength", "Abs1");

        }

        private async void GetInfoAbs2(object sender, EventArgs args)
        {
            ShowDescI("Abs2");

        }

        private async void AddAbs2(object sender, EventArgs args)
        {
            NewAdd("IronClad", "Abs2");
        }

        private async void GetInfoAbs3(object sender, EventArgs args)
        {
            ShowDescI("Abs3");
        }

        private async void AddAbs3(object sender, EventArgs args)
        {
            NewAdd("Obliques", "Abs3");
        }

        private async void GetInfoAbs4(object sender, EventArgs args)
        {
            ShowDescI("Abs4");
        }

        private async void AddAbs4(object sender, EventArgs args)
        {
            NewAdd("WOCrunches", "Abs4");
        }

        private async void GetInfoAbs5(object sender, EventArgs args)
        {
            ShowDescI("Abs5");

        }

        private async void AddAbs5(object sender, EventArgs args)
        {
            NewAdd("SumAb1", "Abs5");
        }

        private async void GetInfoAbs6(object sender, EventArgs args)
        {

            ShowDescI("Abs6");
        }

        private async void AddAbs6(object sender, EventArgs args)
        {
            NewAdd("SumAb2", "Abs6");
        }


        //__________ Arms
        private async void GetInfoArms1(object sender, EventArgs args)
        {
            ShowDescI("Arms1");

        }

        private async void AddArms1(object sender, EventArgs args)
        {
            NewAdd("Beginner Arm Workout", "Arms1");
        }

        private async void GetInfoArms2(object sender, EventArgs args)
        {
            ShowDescI("Arms2");

        }

        private async void AddArms2(object sender, EventArgs args)
        {
            NewAdd("Arm Workout challenge ", "Arms2");
        }

        private async void GetInfoArms3(object sender, EventArgs args)
        {

            ShowDescI("Arms3");
        }

        private async void AddArms3(object sender, EventArgs args)
        {
            NewAdd("Burn Arm Fat Workout", "Arms3");
        }

        private async void GetInfoArms4(object sender, EventArgs args)
        {

            ShowDescI("Arms4");
        }

        private async void AddArms4(object sender, EventArgs args)
        {
            NewAdd("Toned Arms Workout", "Arms4");
        }

        private async void GetInfoArms5(object sender, EventArgs args)
        {

            ShowDescI("Arms5");
        }

        private async void AddArms5(object sender, EventArgs args)
        {
            NewAdd("Big Arms Workout", "Arms5");
        }

        private async void GetInfoArms6(object sender, EventArgs args)
        {

            ShowDescI("Arms6");
        }

        private async void AddArms6(object sender, EventArgs args)
        {
            NewAdd("Triceps Workout", "Arms6");
        }

        //_________________ Leg
        private async void GetInfoLeg1(object sender, EventArgs args)
        {

            ShowDescI("Leg1");
        }

        private async void AddLeg1(object sender, EventArgs args)
        {
            NewAdd("Core strengthening Workout", "Legs1");
        }

        private async void GetInfoLeg2(object sender, EventArgs args)
        {

            ShowDescI("Leg2");
        }

        private async void AddLeg2(object sender, EventArgs args)
        {
            NewAdd("Thigh workout ", "Legs2");
        }

        private async void GetInfoLeg3(object sender, EventArgs args)
        {
            ShowDescI("Leg3");

        }

        private async void AddLeg3(object sender, EventArgs args)
        {
            NewAdd("Toned Legs", "Legs3");
        }

        private async void GetInfoLeg4(object sender, EventArgs args)
        {

            ShowDescI("Leg4");
        }

        private async void AddLeg4(object sender, EventArgs args)
        {
            NewAdd("Burn Leg Fat", "Legs4");
        }

        private async void GetInfoLeg5(object sender, EventArgs args)
        {
            ShowDescI("Leg5");

        }

        private async void AddLeg5(object sender, EventArgs args)
        {
            NewAdd("Dumbbell workout", "Legs5");
        }

        private async void GetInfoLeg6(object sender, EventArgs args)
        {
            ShowDescI("Leg6");

        }

        private async void AddLeg6(object sender, EventArgs args)
        {
            NewAdd("Resistant band workout", "Legs6");
        }

        //__________________ Booty 
        private async void GetInfoGlutes1(object sender, EventArgs args)
        {
            ShowDescI("Booty1");
        }

        private async void AddGlutes1(object sender, EventArgs args)
        {
            NewAdd("Bubble But Workout", "Booty1");
        }

        private async void GetInfoGlutes2(object sender, EventArgs args)
        {
            ShowDescI("Booty2");

        }

        private async void AddGlutes2(object sender, EventArgs args)
        {
            NewAdd("Tighten up workout ", "Booty2");
        }

        private async void GetInfoGlutes3(object sender, EventArgs args)
        {
            ShowDescI("Booty3");

        }

        private async void AddGlutes3(object sender, EventArgs args)
        {
            NewAdd("Bodyweight Workout", "Booty3");
        }

        private async void GetInfoGlutes4(object sender, EventArgs args)
        {
            ShowDescI("Booty4");

        }

        private async void AddGlutes4(object sender, EventArgs args)
        {
            NewAdd("Targeted Glutes Workout", "Booty4");
        }

        private async void GetInfoGlutes5(object sender, EventArgs args)
        {
            ShowDescI("Booty5");

        }

        private async void AddGlutes5(object sender, EventArgs args)
        {
            NewAdd("Butt Lift Workout", "Booty5");
        }

        private async void GetInfoGlutes6(object sender, EventArgs args)
        {

            ShowDescI("Booty6");
        }

        private async void AddGlutes6(object sender, EventArgs args)
        {
            NewAdd("Toned Glutes Workout", "Booty6");
        }

        //__________ Full Body
        private async void GetInfoFullBody1(object sender, EventArgs args)
        {
            ShowDescI("Body1");
        }

        private async void AddFullBody1(object sender, EventArgs args)
        {
            NewAdd("Full Body Blast", "Body1");
        }

        private async void GetInfoFullBody2(object sender, EventArgs args)
        {
            ShowDescI("Body2");

        }

        private async void AddFullBody2(object sender, EventArgs args)
        {
            NewAdd("High intensity", "Body2");
        }

        private async void GetInfoFullBody3(object sender, EventArgs args)
        {
            ShowDescI("Body3");
        }

        private async void AddFullBody3(object sender, EventArgs args)
        {
            NewAdd("Full Body Circuit", "Body3");
        }

        private async void GetInfoFullBody4(object sender, EventArgs args)
        {
            ShowDescI("Body4");
        }

        private async void AddFullBody4(object sender, EventArgs args)
        {
            NewAdd("Beginner HIIT", "Body4");
        }

        private async void GetInfoFullBody5(object sender, EventArgs args)
        {
            ShowDescI("Body5");
        }

        private async void AddFullBody5(object sender, EventArgs args)
        {
            NewAdd("Strength workout", "Body5");
        }

        private async void GetInfoFullBody6(object sender, EventArgs args)
        {
            ShowDescI("Body6");
        }

        private async void AddFullBody6(object sender, EventArgs args)
        {
            NewAdd("No-equipment workout", "Body6");
        }

        public void ShowDescI(string type)
        {
            //recupérer la list des etry coresponndant au type
            var col = Database.db.GetCollection<ListEntry>("ListEntries");
            var exercices = col.Find(Query.EQ("Type", type));

            string show = "";

            foreach (var exe in exercices)
            {
                show += exe.Description + "\n";
            }

            DisplayAlert("Workout description", show, "ok wow");
        }

       
        public void NewAdd(string type, string tocall)
        {
            ListView ListVieww2 = new ListView();

            (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) = GetAll(tocall);
            Workout.InsertWorkout(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, DateTime.Today, type);
            Contents.Add(type + ": " + "\n" + ex1.Description+ "\n"+ ex2.Description + "\n" + ex3.Description + "\n" + ex4.Description + "\n" + ex5.Description + "\n" + ex6.Description + "\n" +
                ex7.Description + "\n" + ex8.Description + "\n" + ex9.Description + "\n" + ex10.Description + "\n" + "\n");

            ListVieww2.ItemsSource = Contents;
            
            ListVieww2.SelectedItem = SelectionMode.None;
            ListVieww2.SeparatorColor = Color.Lavender;
            ListVieww2.RefreshControlColor = Color.LightPink;
            
            Framing.Content = ListVieww2;

        }
        public (ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10) GetAll(string type)
        {
            //recupérer la list des etry coresponndant au type
            var col = Database.db.GetCollection<ListEntry>("ListEntries");
            var exercices = col.Find(Query.EQ("Type", type));
            ListEntry ex1 = exercices.ElementAt(0);
            ListEntry ex2 = exercices.ElementAt(1);
            ListEntry ex3 = exercices.ElementAt(2);
            ListEntry ex4 = exercices.ElementAt(3);
            ListEntry ex5 = exercices.ElementAt(4);
            ListEntry ex6 = exercices.ElementAt(5);
            ListEntry ex7 = exercices.ElementAt(6);
            ListEntry ex8 = exercices.ElementAt(7);
            ListEntry ex9 = exercices.ElementAt(8);
            ListEntry ex10 = exercices.ElementAt(9);

            return (ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10);


        }

        private async void StartWorkout(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new StartWorkout(DateTime.Now));
        }


    }
}