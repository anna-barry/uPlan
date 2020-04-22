using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.SimpleAudioPlayer;
using SkiaSharp;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Buttons;
using Xamarin.Forms;

using MediaManager;
using MediaManager.Forms;

using Xamarin.Forms.Xaml;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms.PlatformConfiguration;
using System.Text.RegularExpressions;
using UplanTest;
using MediaManager.Player;
using System.ComponentModel;
using MediaManager.Notifications;
//using UplanTest.Well_Being;//

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WellBeing : ContentPage


    {

        DateTime tps;



        public WellBeing()
        {
            InitializeComponent();

            //la faire un random pour trouver la quote du jour et la mettre a quote !;text breffff
            //var col= Database.db.GetCollection<ListEntry>("ListEntries");
            //var quotes = col.FindAll(Query.EQ("DueDate", Monday.Date));

            //  Device.StartTimer(TimeSpan.FromSeconds(1),)//

            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);







        }
        DateTime actu = DateTime.Now;






        bool OnTimerTick()
        {
            if (_switch.IsToggled && DateTime.Now >= tps)
            {
                _switch.IsToggled = false;
                DisplayAlert("Timer Alert", "The '" + "'break'" + "' timer has elapsed", "OK");
                var alert = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();

                alert.Load("alert.mp3");
                alert.Play();


            }
            return true;
        }
        void Event(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Time")
            {
                SetTriggerTime();
                _switch.IsVisible = true;
            }
        }

        void Pass(object sender, ToggledEventArgs args)
        {
            SetTriggerTime();
            Navigation.PushAsync(new musik());
        }

        void SetTriggerTime()
        {
            if (_switch.IsToggled)
            {
                tps = DateTime.Today + Chrono.Time;
                if (tps < DateTime.Now)
                {
                    tps += TimeSpan.FromDays(1);
                }
            }
        }








        public static void ToPause1(object sender, EventArgs e)
        {





        }
        private void ToPlay2(object sender, EventArgs e)
        {




        }
        private void ToPause2(object sender, EventArgs e)
        {



        }


    }

}