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
    public partial class AboutMe : ContentPage
    {
        public AboutMe()
        {
            InitializeComponent();

            info.Text = User.GetInfoForMe();
            //<!--.Row="8" Grid.Column="0" Grid.ColumnSpan="2" Grid.RowSpan="5"-->
        }
    }
}