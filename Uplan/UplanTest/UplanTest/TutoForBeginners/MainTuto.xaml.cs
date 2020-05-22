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
    public partial class MainTuto : CarouselPage
    {
        public MainTuto()
        {
            InitializeComponent();
        }

        async void GoToApp(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MainPage());
        }

        async void SkipToTheGoodBit(object sender, EventArgs args)
        {
            CarPage.SelectedItem = DatLastOne;
            //CarPage.Navigation.PushAsync(new DatLastOne());
            
        }
    }
}