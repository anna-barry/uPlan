using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest.MyExpenses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Expenses : ContentView
    {
        public Expenses()
        {
            InitializeComponent();
        }
    }
}