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

            for (int i = 0; i < listOfWorkouts.Count(); i++)
            {
                Type.Text = listOfWorkouts.ElementAt(i).Type;
                for (int k = 0; k < 2; k++)
                {

                    for (int j = 0; j < 10; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                Exerice.Text = listOfWorkouts.ElementAt(i).Exercice1.Description;
                                break;
                            case 1:
                                Exerice.Text = listOfWorkouts.ElementAt(i).Exercice2.Description;
                                break;
                            case 2:
                                Exerice.Text = listOfWorkouts.ElementAt(i).Exercice3.Description;
                                break;
                            case 3:
                                Exerice.Text = listOfWorkouts.ElementAt(i).Exercice4.Description;
                                break;
                            case 4:
                                Exerice.Text = listOfWorkouts.ElementAt(i).Exercice5.Description;
                                break;
                            case 5:
                                Exerice.Text = listOfWorkouts.ElementAt(i).Exercice6.Description;
                                break;
                            case 6:
                                Exerice.Text = listOfWorkouts.ElementAt(i).Exercice7.Description;
                                break;
                            case 7:
                                Exerice.Text = listOfWorkouts.ElementAt(i).Exercice8.Description;
                                break;
                            case 8:
                                Exerice.Text = listOfWorkouts.ElementAt(i).Exercice9.Description;
                                break;
                            case 9:
                                Exerice.Text = listOfWorkouts.ElementAt(i).Exercice10.Description;
                                break;
                        }

                        /*_timer = new Timer();
                        //Trigger event every second
                        _timer.Interval = 1000;
                        /*_timer.Elapsed += OnTimedEvent;
                        //count down 5 seconds
                        _countSeconds = 30;
                        _timer.Enabled = true;*/

                        
                        int seconds = 0;
                        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                        {
                                                    // do something every 30 seconds
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                                      
                             LilTime.Text = "                             "+(30 - seconds).ToString();

                             //____ Test -> ne rentre pas dedans _______ //
                             //Type.Text= (30 - seconds).ToString();
                             //_______________________________________ //

                            seconds += 1;
                            InTheFrame.Content = LilTime;
                            if (seconds == 25)
                            {
                                InTheFrame.BackgroundColor = Color.IndianRed;
                            }
                            if (seconds==0)
                            {
                               InTheFrame.BackgroundColor = Color.LightGreen;
                            }

                            });
                            if (seconds==30)
                            { 
                                return false; 
                            }
                             return true; // runs again, or false to stop
                            });
                    }
                }

                int seconds2 = 0;
                Device.StartTimer(new TimeSpan(0, 0, 5), () =>
                {
                    // do something every 30 seconds
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Label LilTime = new Label();
                        LilTime.Text = (30 - seconds2).ToString();
                        seconds2 += 1;
                        InTheFrame.Content = LilTime;
                        InTheFrame.BackgroundColor = Color.LavenderBlush;
                        Type.Text = "";
                        Exerice.Text = "Take a break between your workouts";
                        

                    });
                    if (seconds2 == 30)
                    { 
                        return false; }
                    return true; // runs again, or false to stop
                });
            }

            
            /*DispatcherTimer timerr = new DispatcherTimer();
            timerr.Interval = TimeSpan.FromSeconds(1);
            timerr.Tick += timer_Tick;
         
            timerr.Start();*/

        }


        /*private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {

            _countSeconds--;
            Label LilTime = new Label();
            LilTime.FontSize = 23;
            LilTime.HorizontalOptions = LayoutOptions.Center;
            LilTime.Text = "                             " + (_countSeconds.ToString());
            //Update visual representation here
            //Remember to do it on UI thread
            if (_countSeconds ==30)
            {
                InTheFrame.BackgroundColor = Color.LightGreen;
            }

            if (_countSeconds==5)
            {
                InTheFrame.BackgroundColor = Color.IndianRed;
            }

            if (_countSeconds == 0)
            {
                _timer.Stop();
            }
        }*/

        /*void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
        }*/
    }
}