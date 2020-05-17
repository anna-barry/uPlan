using LiteDB;
using System;
using System.Linq;
//using Windows.UI.Xaml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows;
using System.Timers;
namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartWorkout : ContentPage
    {
        private Label LilTime = new Label();
        private Timer _timer;
        private int _countSeconds;
        public StartWorkout(DateTime day)
        {
            InitializeComponent();

                        LilTime.FontSize = 23;
                        var c = Database.db.GetCollection<Workout>("AllWorkouts");
                        var listOfWorkouts = c.Find(Query.EQ("DueDate", day.Date));

                        int seconds = 0;
                        int kactual = 1;
                        int nb_workouts = listOfWorkouts.Count();
                        int ActExercice = 1;
                        int round = 1;

                        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                        {
                            // do something every 30 seconds
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                Type.Text = listOfWorkouts.ElementAt(kactual-1).Type;
                                LilTime.Text = (30 - seconds).ToString();
                                LilTime.HorizontalOptions = LayoutOptions.Center;

                                switch (ActExercice)
                                {
                                    case 1:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice1.Description;
                                        break;
                                    case 2:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice2.Description;
                                        break;
                                    case 3:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice3.Description;
                                        break;
                                    case 4:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice4.Description;
                                        break;
                                    case 5:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice5.Description;
                                        break;
                                    case 6:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice6.Description;
                                        break;
                                    case 7:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice7.Description;
                                        break;
                                    case 8:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice8.Description;
                                        break;
                                    case 9:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice9.Description;
                                        break;
                                    case 10:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice10.Description;
                                        break;
                                }


                                InTheFrame.Content = LilTime;
                                if (seconds >= 25)
                                {InTheFrame.BackgroundColor = Color.IndianRed;}
                                else
                                {InTheFrame.BackgroundColor = Color.LightGreen;}

                                if (seconds == 30 && ActExercice == 10 && round == 1)
                                {
                                    round = 2;
                                    seconds = 0;
                                    ActExercice = 1;
                                }
                                else
                                {
                                    if (!(seconds == 30 && kactual == nb_workouts && round == 2 && ActExercice == 10))
                                    {
                                        if (seconds == 30)
                                        {
                                            if (ActExercice==10 && round==2)
                                            {
                                                kactual += 1;
                                                seconds = 0;
                                                ActExercice = 1;
                                            }
                                            else
                                            {
                                                ActExercice += 1;
                                                seconds = 0;
                                            }
                                         }
                                    }

                                }
                                seconds += 1;
                            });

                            if (seconds == 30 && kactual == nb_workouts && round == 2 && ActExercice == 10)
                            {
                                return false;
                            }
                            return true; // runs again, or false to stop
                        });

                    }
                }

                 
    //______________ Pour Pause à faire _____________________________
                        //InTheFrame.BackgroundColor = Color.LavenderBlush;
                        //Type.Text = "";
                        //Exerice.Text = "Take a break between your workouts";
                    
          

}