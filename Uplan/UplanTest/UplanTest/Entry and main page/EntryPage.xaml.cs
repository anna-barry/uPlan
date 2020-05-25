using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        bool started = false;
        public EntryPage()
        {
            InitializeComponent();
            Database.Initiate();


            
               // ? ImageSource.FromFile("Resources/default.png")
                //: ImageSource.FromFile("Resources/default.png");

          /*  DefauDevice.RuntimePlatform == Device.UWP
                ? ImageSource.FromFile("Assets/default.png")
                : ImageSource.FromFile("Assets/default.png");*/
        }
        private void StartCliked(object sender, EventArgs e)
        {
            started = true;
           // Database.Initiate();
           
            Navigation.PushAsync(new MainPage());
        }
        private void NewCliked(object sender, EventArgs e)
        {
           // started = true;
           
            Navigation.PushAsync(new AccountPage());
            
        }

    }
}
