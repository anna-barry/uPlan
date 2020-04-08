using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
