using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UplanTest.API;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LiteDB;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class apipage : ContentPage
    {
       public apipage()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }
        public async void Sauvegarder_Clicked(System.Object sender, System.EventArgs e)
        {
            
           
            

           // if (isNumeric(EntréeCodeBarre.Text))
            {
                var nutriInfo = await InfoResponseApi.LoadInfo((EntréeCodeBarre.Text));
                SortieApi.Text = $"le classe de nutriment est {nutriInfo}";
            }
        }

        public bool isNumeric(string entree)
        {
            bool isNumeric;
            try
            {
                int.Parse(entree);
                isNumeric = true;
            }
            catch
            {
                isNumeric = false;
            }
            return isNumeric;
        }
    
    } 
}