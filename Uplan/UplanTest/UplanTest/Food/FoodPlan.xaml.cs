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
    public partial class FoodPlan : ContentPage
    {
        public static string Lunmon;
        public static string Luntue;
        public static string Lunwed;
        public static string Lunthu;
        public static string Lunfri;
        public static string Lunsat;
        public static string Lunsun;
        public static string Dinmon;
        public static string Dintue;
        public static string Dinwed;
        public static string Dinthu;
        public static string Dinfri;
        public static string Dinsat;
        public static string Dinsun;

        public FoodPlan()
        {
            InitializeComponent();
            
            var wfood = MyFoodWeek.thisweek;


            //chaque dejeuner  et diner est consituté d'une source de prot, d'une source de carb et d'une source de veggies
            //ici on assigne les source préalablement choisies par l'utilisateur, pour chacun des jours
            //ListEntry.getDescfromEntry

            

            //partie dejeuner
            Lunmon = wfood.FoodCategoryDescCarb1 + '\n' + wfood.FoodCategoryDescProt1 + '\n' + wfood.FoodCategoryDescVeggies1;
            lunmon.Text = Lunmon;

            Luntue = wfood.FoodCategoryDescCarb2 + '\n' + wfood.FoodCategoryDescProt2 + '\n' + wfood.FoodCategoryDescVeggies2;
            luntue.Text = Luntue;

            Lunwed = wfood.FoodCategoryDescCarb3 + '\n' + wfood.FoodCategoryDescProt3 + '\n' + wfood.FoodCategoryDescVeggies3;
            lunwed.Text = Lunwed;

            Lunthu = wfood.FoodCategoryDescCarb1 + '\n' + wfood.FoodCategoryDescProt2 + '\n' + wfood.FoodCategoryDescVeggies3;
            lunthu.Text = Lunthu;

            Lunfri = wfood.FoodCategoryDescCarb3 + '\n' + wfood.FoodCategoryDescProt1 + '\n' + wfood.FoodCategoryDescVeggies2;
            lunfri.Text = Lunfri;

            Lunsat = wfood.FoodCategoryDescCarb2 + '\n' + wfood.FoodCategoryDescProt3 + '\n' + wfood.FoodCategoryDescVeggies1;
            lunsat.Text = Lunsat;

            Lunsun = wfood.FoodCategoryDescCarb3 + '\n' + wfood.FoodCategoryDescProt2 + '\n' + wfood.FoodCategoryDescVeggies1;
            lunsun.Text = Lunsun;

            //ici partie dinner

            Dinmon = wfood.FoodCategoryDescCarb3 + '\n' + wfood.FoodCategoryDescProt1 + '\n' + wfood.FoodCategoryDescVeggies2;
            dinmon.Text = Dinmon;

            Dintue = wfood.FoodCategoryDescCarb3+ '\n' + wfood.FoodCategoryDescProt2 + '\n' + wfood.FoodCategoryDescVeggies1;
            dintue.Text = Dintue;

            Dinwed = wfood.FoodCategoryDescCarb1 + '\n' + wfood.FoodCategoryDescProt2 + '\n' + wfood.FoodCategoryDescVeggies3;
            dinwed.Text = Dinwed;

            Dinthu = wfood.FoodCategoryDescCarb2 + '\n' + wfood.FoodCategoryDescProt1 + '\n' + wfood.FoodCategoryDescVeggies2;
            dinthu.Text = Dinthu;

            Dinfri = wfood.FoodCategoryDescCarb1 + '\n' + wfood.FoodCategoryDescProt1 + '\n' + wfood.FoodCategoryDescVeggies2;
            dinfri.Text = Dinfri;

            Dinsat = wfood.FoodCategoryDescCarb2 + '\n' + wfood.FoodCategoryDescProt2+ '\n' + wfood.FoodCategoryDescVeggies2;
            dinsat.Text = Dinsat;

            Dinsun = wfood.FoodCategoryDescCarb3 + '\n' + wfood.FoodCategoryDescProt3 + '\n' + wfood.FoodCategoryDescVeggies3;
            dinsun.Text = Dinsun;

           

        }

        private async void OnCloseClicked2(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new FoodW());

        }
    }
}