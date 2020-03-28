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
    public partial class FoodPlan : ContentPage
    {
        public FoodPlan()
        {
            InitializeComponent();
            //à faire et dcp revoir avec la question user etc... ou de la date? 
            //monlun
            //var food= Food.GetAllFood();
            //string Monlun = food[0].FoodCategoryDescProt1 + "/n" + food[0].FoodCategoryDescCarb2 + "/n" + food[0].FoodCategoryDescVeggies3;
        }
    }
}