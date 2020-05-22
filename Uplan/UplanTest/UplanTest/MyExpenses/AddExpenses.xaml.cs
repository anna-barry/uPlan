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
            await Navigation.PushAsync(new ViewAnExpense(type));
        }

        public static float Convert(string amount)
        {
            float ret = 0;
            string dec = "";
            string virg = "";
            bool decdid = false;
            int i = 0;
            int l = amount.Length;
            while (i < l)
            {
                if (amount[i] == '.' | amount[i] == ',')
                {
                    decdid = true;
                }
                else
                {
                    if (decdid)
                    {
                        virg += amount[i];
                    }
                    else
                    {
                        dec += amount[i];
                    }
                }
                i++;

            }

            int ld = dec.Length - 1;
            i = 0;
            while (i <= ld)
            {
                ret += (dec[i] % 48) * SquareF(ld - i, 10);
                i++;

            }
            ld = virg.Length;
            i = 0;
            while (i < ld)
            {
                ret += (virg[i] % 48) * SquareF(i+1, (float) 0.1);
                i++;
            }
            return ret;
        }

        public static float SquareF(int rep, float i)
        {
           float y = 1;
           while (rep > 0)
           {
              y = y * i;
              rep--;
           }
           return y;
        }
        async void OnCloseClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new ViewAnExpense(type));
            
        }
    }
}

