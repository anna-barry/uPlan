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
        public WorkoutNow()
        {
            InitializeComponent();
        }
        
        private async void OnCloseClicked2(object sender, EventArgs args)
        {

            
            await Navigation.PopAsync();

        }


    }
}