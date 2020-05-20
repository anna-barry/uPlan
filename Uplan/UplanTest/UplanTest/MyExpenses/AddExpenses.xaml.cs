using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class AddExpenses: ContentPage
    {
        string description;
        string type;
        float amount;


        public AddExpenses(string type)
        {
            InitializeComponent();
            this.type = type;
            typee.Text = "Add a new expens in" + type;

     
        }


        async void OnSaveClicked(object sender, EventArgs args)
        {
            description = desc.Text;
            amount = Convert(amountt.Text);
            Money.AddMoney(amount, description,type);
            await Navigation.PopAsync();
        }

        public static float Convert(string amount)
        {
            float ret = 0;
            int l = amount.Length-1;
            while (l>=0 && amount[l]!=',' && amount[l]!='.' )
            { 
                ret += amount[l] * 10^l;
                l--;
            }
            if (l<0)
            { return ret; }
            int t = -l;
            while (t < 0)
            { 
              ret += amount[l] * 10^t;
                t++;
            }
            return ret;
        }
        async void OnCloseClicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}

