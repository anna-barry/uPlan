﻿using LiteDB;
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
            int inbetween = 30;
            bool pause = false;

            if (nb_workouts>0)
            {

            
                        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                        {
                            // do something every 30 seconds
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                if (!pause)
                                {
                                    Type.Text = listOfWorkouts.ElementAt(kactual-1).Type;
                                LilTime.Text =(30 - seconds).ToString();
                                LilTime.HorizontalOptions = LayoutOptions.Center;
                                LilTime.VerticalOptions = LayoutOptions.Center;
                                LilTime.FontSize = 70;

                                switch (ActExercice)
                                {
                                    case 1:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice1.Description;
                                            if (seconds == 0)
                                            { Picture.Source = listOfWorkouts.ElementAt(kactual - 1).Exercice1.Code; }
                                        break;
                                    case 2:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice2.Description;
                                            if (seconds== 0)
                                            { Picture.Source = listOfWorkouts.ElementAt(kactual - 1).Exercice2.Code; }
                                        break;
                                    case 3:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice3.Description;
                                            if (seconds == 0)
                                            { Picture.Source = listOfWorkouts.ElementAt(kactual - 1).Exercice3.Code; }
                                            break;
                                    case 4:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice4.Description;
                                            if (seconds == 0)
                                            { Picture.Source = listOfWorkouts.ElementAt(kactual - 1).Exercice4.Code; }
                                        break;
                                    case 5:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice5.Description;
                                            if (seconds == 0)
                                            { Picture.Source = listOfWorkouts.ElementAt(kactual - 1).Exercice5.Code; }
                                            break;
                                    case 6:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice6.Description;
                                            if (seconds == 0)
                                            { Picture.Source = listOfWorkouts.ElementAt(kactual - 1).Exercice6.Code; }
                                        break;
                                    case 7:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice7.Description;
                                            if (seconds == 0)
                                            { Picture.Source = listOfWorkouts.ElementAt(kactual - 1).Exercice7.Code; }
                                        break;
                                    case 8:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice8.Description;
                                            if (seconds== 0)
                                            { Picture.Source = listOfWorkouts.ElementAt(kactual - 1).Exercice8.Code; }
                                        break;
                                    case 9:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice9.Description;
                                            if (seconds == 0)
                                            { Picture.Source =listOfWorkouts.ElementAt(kactual - 1).Exercice9.Code; }
                                        break;
                                    case 10:
                                        Exerice.Text = listOfWorkouts.ElementAt(kactual - 1).Exercice10.Description;
                                            if (seconds == 0)
                                            { Picture.Source = listOfWorkouts.ElementAt(kactual - 1).Exercice10.Code; }
                                        break;
                                }


                                InTheFrame.Content = LilTime;
                                if (seconds == 25)
                                {InTheFrame.BackgroundColor = Color.IndianRed;}
                                if (seconds%30==1)
                                {InTheFrame.BackgroundColor = Color.LightGreen;}

                                if ( seconds==30 && ActExercice == 10 && round == 1)
                                {
                                    round = 2;
                                    seconds = 0;
                                    ActExercice = 1;
                                }
                                else
                                {
                                    if (!(seconds== 30 && kactual == nb_workouts && round == 2 && ActExercice == 10))
                                    {
                                        if (seconds == 30)
                                        {
                                            if (ActExercice==10 && round==2)
                                            {
                                                kactual += 1;
                                                seconds = 0;
                                                ActExercice = 1;
                                                inbetween = 30;
                                                pause = true;


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
                                }
                                else
                                {
                                    if (inbetween>0)
                                    {
                                        Type.Text = "";
                                        Exerice.Text = "Take a quick break";
                                        LilTime.Text = inbetween.ToString();
                                        LilTime.HorizontalOptions = LayoutOptions.Center;
                                        LilTime.VerticalOptions = LayoutOptions.Center;
                                        LilTime.FontSize = 20;
                                        InTheFrame.BackgroundColor = Color.LavenderBlush;
                                        inbetween -= 1;
                                    }
                                    else
                                    {
                                        pause = false;
                                    }

                                }
                            });

                            if (seconds >= 30*nb_workouts*2*10 && kactual == nb_workouts && round == 2 && ActExercice == 10)
                            {
                                Type.Text = "Well done";
                                Exerice.Text = "You have finished your workout, you should be proud of yourself";
                                InTheFrame.IsVisible = false;

                                return false;

                            }
                            return true; // runs again, or false to stop
                        });

            }



        }

        private async void OnCloseClicked2(object sender, EventArgs args)
        {

            //await Navigation.PopAsync();
            await Navigation.PushAsync(new MainMyWorkouts());


        }
    }

        
          

}