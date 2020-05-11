using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LiteDB;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodW : ContentPage
    {
        ListHelper prot1;
        ListHelper prot2;
        ListHelper prot3;
        ListHelper carb1;
        ListHelper carb2;
        ListHelper carb3;
        ListHelper veggies1;
        ListHelper veggies2;
        ListHelper veggies3;
        bool toggled = false;
        public FoodW()
        {
            InitializeComponent();

            prot1 = new ListHelper("PROTEIN", -1, "");
            Prot_1.FontSize = 10;
            Prot_1.ItemsSource = prot1.DisplayList;
            Prot_1.SelectedIndex = prot1.CurrentIndex;

            prot2 = new ListHelper("PROTEIN", -1, "");
            Prot_2.FontSize = 10;
            Prot_2.ItemsSource = prot2.DisplayList;
            Prot_2.SelectedIndex = prot2.CurrentIndex;

            prot3 = new ListHelper("PROTEIN", -1, "");
            Prot_3.FontSize = 10;
            Prot_3.ItemsSource = prot3.DisplayList;
            Prot_3.SelectedIndex = prot3.CurrentIndex;

            carb1 = new ListHelper("CARB", -1, "");
            Carb_1.FontSize = 10;
            Carb_1.ItemsSource = carb1.DisplayList;
            Carb_1.SelectedIndex = carb1.CurrentIndex;

            carb2 = new ListHelper("CARB", -1, "");
            Carb_2.FontSize = 10;
            Carb_2.ItemsSource = carb2.DisplayList;
            Carb_2.SelectedIndex = carb2.CurrentIndex;

            carb3 = new ListHelper("CARB", -1, "");
            Carb_3.FontSize = 10;
            Carb_3.ItemsSource = carb3.DisplayList;
            Carb_3.SelectedIndex = carb3.CurrentIndex;

            veggies1 = new ListHelper("VEGGIES", -1, "");
            Veggies_1.FontSize = 10;
            Veggies_1.ItemsSource = veggies1.DisplayList;
            Veggies_1.SelectedIndex = veggies1.CurrentIndex;

            veggies2 = new ListHelper("VEGGIES", -1, "");
            Veggies_2.FontSize = 10;
            Veggies_2.ItemsSource = veggies2.DisplayList;
            Veggies_2.SelectedIndex = veggies2.CurrentIndex;

            veggies3 = new ListHelper("VEGGIES", -1, "");
            Veggies_3.FontSize = 10;
            Veggies_3.ItemsSource = veggies3.DisplayList;
            Veggies_3.SelectedIndex = veggies3.CurrentIndex;
        }

        void OnToggled(object sender, ToggledEventArgs e)
        {
            toggled = !toggled;
        }

        public void OnButtonClicked(object sender, EventArgs args)

        {

            MyFoodWeek.UpdateFood(prot1.ListEntryList[Prot_1.SelectedIndex], prot2.ListEntryList[Prot_2.SelectedIndex],
                 prot3.ListEntryList[Prot_3.SelectedIndex], carb1.ListEntryList[Carb_1.SelectedIndex], carb2.ListEntryList[Carb_2.SelectedIndex],
                 carb3.ListEntryList[Carb_3.SelectedIndex], veggies1.ListEntryList[Veggies_1.SelectedIndex], veggies2.ListEntryList[Veggies_2.SelectedIndex],
                 veggies3.ListEntryList[Veggies_3.SelectedIndex]);

            if (toggled)
            {
                //Search s'ils ne sont pas déjà présent
                //bool NotalreadySavede = true;
                var col = Database.db.GetCollection<FoodItem>("FoodForShoppingList");

                //Results 
                //__________________________ Prot
                var resultprot1 = col.FindOne(Query.And(Query.EQ("Code", MyFoodWeek.thisweek.FoodCategoryCodeProt1), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeProt1)));
                bool prot1 = (resultprot1 == null);
                var resultprot2 = col.FindOne(Query.And(Query.EQ("Code", MyFoodWeek.thisweek.FoodCategoryCodeProt2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeProt2)));
                bool prot2 = (resultprot2 == null);
                var resultprot3 = col.FindOne(Query.And(Query.EQ("Code", MyFoodWeek.thisweek.FoodCategoryCodeProt3), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeProt3)));
                bool prot3 = (resultprot3 == null);


                //__________________________ Carb
                var resultcarb1 = col.FindOne(Query.And(Query.EQ("Code", MyFoodWeek.thisweek.FoodCategoryCodeCarb1), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeCarb1)));
                bool carb1 = (resultcarb1 == null);
                var resultcarb2 = col.FindOne(Query.And(Query.EQ("Code", MyFoodWeek.thisweek.FoodCategoryCodeCarb2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeCarb2)));
                bool carb2 = (resultcarb2 == null);
                var resultcarb3 = col.FindOne(Query.And(Query.EQ("Code", MyFoodWeek.thisweek.FoodCategoryCodeCarb3), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeCarb3)));
                bool carb3 = (resultcarb1 == null);

                //___________________________ Veggies

                var resultveggie1 = col.FindOne(Query.And(Query.EQ("Code", MyFoodWeek.thisweek.FoodCategoryCodeVeggies1), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeVeggies1)));
                bool veggie1 = (resultveggie1 == null);
                var resultveggie2 = col.FindOne(Query.And(Query.EQ("Code", MyFoodWeek.thisweek.FoodCategoryCodeVeggies2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeVeggies2)));
                bool veggie2 = (resultveggie2 == null);
                var resultveggie3 = col.FindOne(Query.And(Query.EQ("Code", MyFoodWeek.thisweek.FoodCategoryCodeVeggies3), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeVeggies3)));
                bool veggie3 = (resultveggie3 == null);


                GetShoppinForWeek();
               
            }

        }

        async void Add(object sender, EventArgs args)

        {
           
            await Navigation.PushAsync(new AddOneFood());
        }

        public static void GetShoppinForWeek()
        {
            var col = Database.db.GetCollection<FoodItem>("FoodForShoppingList");
            //INSERT FOOD ITEM FOR EACH FOOD OF THIS WEEK
            // for the dueDate the idea is that for the next Sunday the food must be eaten (new food plan after that) 
            //-> we need to add the possibility to change all due Dates

            DateTime res = GetNextSunday();

            //_______________________________________________________________
            //_____________________ Carb ____________________________________

            //________________________ all the info__________________________
            string typeForCarb1 = MyFoodWeek.thisweek.FoodCategoryTypeCarb1;
            string codeForCarb1 = MyFoodWeek.thisweek.FoodCategoryCodeCarb1;
            string descForCarb1 = MyFoodWeek.thisweek.FoodCategoryDescCarb1;

            string typeForCarb2 = MyFoodWeek.thisweek.FoodCategoryTypeCarb2;
            string codeForCarb2 = MyFoodWeek.thisweek.FoodCategoryCodeCarb2;
            string descForCarb2 = MyFoodWeek.thisweek.FoodCategoryDescCarb2;

            string typeForCarb3 = MyFoodWeek.thisweek.FoodCategoryTypeCarb3;
            string codeForCarb3 = MyFoodWeek.thisweek.FoodCategoryCodeCarb3;
            string descForCarb3 = MyFoodWeek.thisweek.FoodCategoryDescCarb2;

            //_______________________________________________________________________
            //_________________________ if result is not found than add with one else 
            //______________________________ update if result found

            //Si n'est pas présent dans food item
            var col2 = Database.db.GetCollection<FoodItem>("FoodItems");
            var resultcarb1 = col2.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeCarb1), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeCarb1)));
            bool carb1 = (resultcarb1.Count() == 0);
            if(carb1)
            {
                FoodItem.InsertFoodItem(typeForCarb1, codeForCarb1, descForCarb1, res,1);
            }
            
            //Si n'est pas présent dans food pou liste de courses
            var rescarb1 = col.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeCarb1), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeCarb1)));
            bool shcarb1 = (rescarb1.Count() == 0);
            if (shcarb1)
            {
                col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb1, codeForCarb1));
            }
            else
            {
                var resultforOnlyCarb1 = col.FindOne(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeCarb1), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeCarb1)));
                resultforOnlyCarb1.Amount += 1;
                col.Update(resultforOnlyCarb1);

            }


            var resultcarb2 = col2.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeCarb2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeCarb2)));
            bool car2 = (resultcarb2.Count() == 0);
            if (car2)
            {
                FoodItem.InsertFoodItem(typeForCarb2, codeForCarb2, descForCarb2, res,1);
            }


            //Si n'est pas présent dans food pou liste de courses
            var rescarb2 = col.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeCarb2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeCarb2)));
            bool shcarb2 = (rescarb2.Count() == 0);
            if (shcarb2)
            {
                col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb2, codeForCarb2));
            }
            else
            {
                var resultforOnlyCarb2 = col.FindOne(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeCarb2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeCarb2)));
                resultforOnlyCarb2.Amount += 1;
                col.Update(resultforOnlyCarb2);

            }




            //FoodItem.InsertFoodItem(typeForCarb3, codeForCarb3, descForCarb3, res);
            //col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb3, codeForCarb3));

            //Si n'est pas présent dans food item
            var resultcarb3 = col2.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeCarb3), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeCarb3)));
            bool car3 = (resultcarb3.Count() == 0);
            if (car3)
            {
                FoodItem.InsertFoodItem(typeForCarb3, codeForCarb3, descForCarb3, res,1);
            }
            //Si n'est pas présent dans food pou liste de courses
            var rescarb3 = col.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeCarb3), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeCarb3)));
            bool shcarb3 = (rescarb3.Count() == 0);
            if (shcarb3)
            {
                col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb3, codeForCarb3));
            }
            else
            {
               var resultforOnlyCarb3 = col.FindOne(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeCarb3), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeCarb3)));
                resultforOnlyCarb3.Amount += 1;
                col.Update(resultforOnlyCarb3);
            }

            //__________________________________________________________________
            //_____________________ Prot _______________________________________

            string typeForProt1 = MyFoodWeek.thisweek.FoodCategoryTypeProt1;
            string codeForProt1 = MyFoodWeek.thisweek.FoodCategoryCodeProt1;
            string descForProt1 = MyFoodWeek.thisweek.FoodCategoryDescProt1;
            //FoodItem.InsertFoodItem(typeForProt1, codeForProt1, descForProt1, res);
            //col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt1, codeForProt1));

            //Si n'est pas présent dans food item
            var resultprot1 = col2.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeProt1), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeProt1)));
            bool prot1 = (resultprot1.Count() ==0);
            if (prot1)
            {
                FoodItem.InsertFoodItem(typeForProt1, codeForProt1, descForProt1, res,1);
            }
            //Si n'est pas présent dans food pou liste de courses
            var resprot1 = col.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeProt1), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeProt1)));
            bool shprot1 = (resprot1.Count() == 0);
            if (shprot1)
            {
                col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt1, codeForProt1));
            }
            else
            {
                var updateprot1 = col.FindOne(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeProt1), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeProt1)));
                updateprot1.Amount += 1;
                col.Update(updateprot1);

            }

            string typeForProt2 = MyFoodWeek.thisweek.FoodCategoryTypeProt2;
            string codeForProt2 = MyFoodWeek.thisweek.FoodCategoryCodeProt2;
            string descForProt2 = MyFoodWeek.thisweek.FoodCategoryDescProt2;
            //FoodItem.InsertFoodItem(typeForProt2, codeForProt2, descForProt2, res);
            //col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt2, codeForProt2));

            //Si n'est pas présent dans food item
            var resultprot2 = col2.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeProt2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeProt2)));
            bool prot2 = (resultprot2.Count() == 0);
            if (prot2)
            {
                FoodItem.InsertFoodItem(typeForProt2, codeForProt2, descForProt2, res,1);
            }
            //Si n'est pas présent dans food pou liste de courses
            var resprot2 = col.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeProt2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeProt2)));
            bool shprot2 = (resprot2.Count() == 0);
            if (shprot2)
            {
                col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt2, codeForProt2));
            }
            else
            {
                var updateprot2 = col.FindOne(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeProt2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeProt2)));
                updateprot2.Amount += 1;
                col.Update(updateprot2);
            }


            string typeForProt3 = MyFoodWeek.thisweek.FoodCategoryTypeProt3;
            string codeForProt3 = MyFoodWeek.thisweek.FoodCategoryCodeProt3;
            string descForProt3 = MyFoodWeek.thisweek.FoodCategoryDescProt3;
            //FoodItem.InsertFoodItem(typeForProt3, codeForProt3, descForProt3, res);
            //col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt3, codeForProt3));

            //Si n'est pas présent dans food item
            var resultprot3 = col2.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeProt3), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeProt3)));
            bool prot3 = (resultprot3.Count() == 0);
            if (prot3)
            {
                FoodItem.InsertFoodItem(typeForProt3, codeForProt3, descForProt3, res,1);
            }
            //Si n'est pas présent dans food pou liste de courses
            var resprot3 = col.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeProt3), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeProt3)));
            bool shprot3 = (resprot3.Count() == 0);
            if (shprot3)
            {
                col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt3, codeForProt3));
            }
            else
            {
                var updateprot3 = col.FindOne(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeProt3), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeProt3)));
                updateprot3.Amount += 1;
                col.Update(updateprot3);
            }

            //_________________________________________________________________________________
            //_________________ Veggie ________________________________________________________

            string typeForVeggie1 = MyFoodWeek.thisweek.FoodCategoryTypeVeggies1;
            string codeForVeggie1 = MyFoodWeek.thisweek.FoodCategoryCodeVeggies1;
            string descForVeggie1 = MyFoodWeek.thisweek.FoodCategoryDescVeggies1;
            //FoodItem.InsertFoodItem(typeForVeggie1, codeForVeggie1, descForVeggie1, res);
            //col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie1, codeForVeggie1));

            //Si n'est pas présent dans food item
            var resultveggie1 = col2.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeVeggies1), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeVeggies1)));
            bool veggie1 = (resultveggie1.Count() == 0);
            if (veggie1)
            {
                FoodItem.InsertFoodItem(typeForVeggie1, codeForVeggie1, descForVeggie1, res,1);
            }
            //Si n'est pas présent dans food pou liste de courses
            var resveggie1 = col.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeVeggies1), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeVeggies1)));
            bool shveggie1 = (resveggie1.Count() == 0);
            if (shveggie1)
            {
                col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie1, codeForVeggie1));
            }
            else
            {
                var updateveggie1 = col.FindOne(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeVeggies1), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeVeggies1)));
                updateveggie1.Amount += 1;
                col.Update(updateveggie1);
            }


            string typeForVeggie2 = MyFoodWeek.thisweek.FoodCategoryTypeVeggies2;
            string codeForVeggie2 = MyFoodWeek.thisweek.FoodCategoryCodeVeggies2;
            string descForVeggie2 = MyFoodWeek.thisweek.FoodCategoryDescVeggies2;
            //FoodItem.InsertFoodItem(typeForVeggie2, codeForVeggie2, descForVeggie2, res);
            //col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie2, codeForVeggie2));
            //Si n'est pas présent dans food item
            var resultveggie2 = col2.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeVeggies2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeVeggies2)));
            bool veggie2 = (resultveggie2.Count() == 0);
            if (veggie2)
            {
                FoodItem.InsertFoodItem(typeForVeggie2, codeForVeggie2, descForVeggie2, res,1);
            }
            //Si n'est pas présent dans food pou liste de courses
            var resveggie2 = col.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeVeggies2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeVeggies2)));
            bool shveggie2 = (resveggie2.Count() == 0);
            if (shveggie2)
            {
                col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie2, codeForVeggie2));
            }
            else
            {
                var updateveggie2 = col.FindOne(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeVeggies2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeVeggies2)));
                updateveggie2.Amount += 1;
                col.Update(updateveggie2);
            }


            string typeForVeggie3 = MyFoodWeek.thisweek.FoodCategoryTypeVeggies3;
            string codeForVeggie3 = MyFoodWeek.thisweek.FoodCategoryCodeVeggies3;
            string descForVeggie3 = MyFoodWeek.thisweek.FoodCategoryDescVeggies3;
            //FoodItem.InsertFoodItem(typeForVeggie3, codeForVeggie3, descForVeggie3, res);
            //col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie3, codeForVeggie3));

            //Si n'est pas présent dans food item
            var resultveggie3 = col2.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeVeggies3), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeVeggies3)));
            bool veggie3 = (resultveggie3.Count() == 0);
            if (veggie3)
            {
                FoodItem.InsertFoodItem(typeForVeggie3, codeForVeggie3, descForVeggie3, res,1);
            }
            //Si n'est pas présent dans food pou liste de courses
            var resveggie3 = col.Find(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeVeggies3), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeVeggies3)));
            bool shveggie3 = (resveggie3.Count() == 0);
            if (shveggie3)
            {
                col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie3, codeForVeggie3));
            }
            else
            {
                var updateveggie3 = col.FindOne(Query.And(Query.EQ("NameCode", MyFoodWeek.thisweek.FoodCategoryCodeVeggies2), Query.EQ("Type", MyFoodWeek.thisweek.FoodCategoryTypeVeggies2)));
                updateveggie3.Amount += 1;
                col.Update(updateveggie3);
            }


        }

        public static DateTime GetNextSunday()
        {
            DateTime res = DateTime.Now;
            if (res.DayOfWeek != DayOfWeek.Sunday)
            {

                if (res.DayOfWeek == DayOfWeek.Monday)
                {
                    res = res.AddDays(6);
                }
                if (res.DayOfWeek == DayOfWeek.Tuesday)
                {
                    res = res.AddDays(5);
                }
                if (res.DayOfWeek == DayOfWeek.Wednesday)
                {
                    res = res.AddDays(4);
                }
                if (res.DayOfWeek == DayOfWeek.Thursday)
                {
                    res = res.AddDays(3);
                }
                if (res.DayOfWeek == DayOfWeek.Friday)
                {
                    res = res.AddDays(2);
                }
                if (res.DayOfWeek == DayOfWeek.Saturday)
                {
                    res = res.AddDays(1);
                }
            }
            return res;
        }

        /*public static void Update(
           string uName, string uEmailAddress, ListEntry uAccomodationType,
           string uShoppingDay, string uCleaningDay)

        {
            me.UpdateUser(uName, uEmailAddress, uAccomodationType, uShoppingDay, uCleaningDay);

            // Keep MyUser static variables up to date after this database update
            Initiate();
        } */
    }
}
