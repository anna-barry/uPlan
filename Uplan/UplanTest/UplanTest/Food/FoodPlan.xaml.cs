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

            //Cette partie est ok : raisonnement 
            //mais le getallfood ne fonctionne pas... comme si c'etait pas intégré dans la database...


            //var col = Database.db.GetCollection<Food>("EntriesforFood");
            // Use FindOne and not Find as we should have only one
            var wfood = MyFoodWeek.thisweek;


            //chaque dejeuner est consituté d'une source de prot, d'une source de carb et d'une source de veggies
            //ici on assigne les source préalablement choisies par l'utilisateur, pour chacun des jours

            //partie dejeuner
            string Lunmon = wfood.FoodCategoryDescCarb1 + "/n" + wfood.FoodCategoryDescProt1 +"/n"+ wfood.FoodCategoryDescVeggies1;
            lunmon.Text = Lunmon;

            string Luntue = wfood.FoodCategoryDescCarb2 + "/n" + wfood.FoodCategoryDescProt2 + "/n" + wfood.FoodCategoryDescVeggies2;
            luntue.Text = Luntue;

            string Lunwed = wfood.FoodCategoryDescCarb3 + "/n" + wfood.FoodCategoryDescProt3 + "/n" + wfood.FoodCategoryDescVeggies3;
            lunwed.Text = Lunwed;

            string Lunthu = wfood.FoodCategoryDescCarb1 + "/n" + wfood.FoodCategoryDescProt2 + "/n" + wfood.FoodCategoryDescVeggies3;
            lunthu.Text = Lunthu;

            string Lunfri = wfood.FoodCategoryDescCarb3 + "/n" + wfood.FoodCategoryDescProt1 + "/n" + wfood.FoodCategoryDescVeggies2;
            lunfri.Text = Lunfri;

            string Lunsat = wfood.FoodCategoryDescCarb2 + "/n" + wfood.FoodCategoryDescProt3 + "/n" + wfood.FoodCategoryDescVeggies1;
            lunsat.Text = Lunsat;

            string Lunsun = wfood.FoodCategoryDescCarb3 + "/n" + wfood.FoodCategoryDescProt2 + "/n" + wfood.FoodCategoryDescVeggies1;
            lunsun.Text = Lunsun;

            //ici partie dinner

            string Dinmon = wfood.FoodCategoryDescCarb3 + "/n" + wfood.FoodCategoryDescProt1 + "/n" + wfood.FoodCategoryDescVeggies2;
            dinmon.Text = Dinmon;

            string Dintue = wfood.FoodCategoryDescCarb3+ "/n" + wfood.FoodCategoryDescProt2 + "/n" + wfood.FoodCategoryDescVeggies1;
            dintue.Text = Dintue;

            string Dinwed = wfood.FoodCategoryDescCarb1 + "/n" + wfood.FoodCategoryDescProt2 + "/n" + wfood.FoodCategoryDescVeggies3;
            dinwed.Text = Dinwed;

            string Dinthu = wfood.FoodCategoryDescCarb2 + "/n" + wfood.FoodCategoryDescProt1 + "/n" + wfood.FoodCategoryDescVeggies2;
            dinthu.Text = Dinthu;

            string Dinfri = wfood.FoodCategoryDescCarb1 + "/n" + wfood.FoodCategoryDescProt1 + "/n" + wfood.FoodCategoryDescVeggies2;
            dinfri.Text = Dinfri;

            string Dinsat = wfood.FoodCategoryDescCarb2 + "/n" + wfood.FoodCategoryDescProt2+ "/n" + wfood.FoodCategoryDescVeggies2;
            dinsat.Text = Dinsat;

            string Dinsun = wfood.FoodCategoryDescCarb3 + "/n" + wfood.FoodCategoryDescProt3 + "/n" + wfood.FoodCategoryDescVeggies3;
            dinsun.Text = Dinsun;

           

        }
    }
}