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
    public partial class AboutMe : ContentPage
    {
        public AboutMe()
        {
            InitializeComponent();

            info.Text = User.GetInfoForMe();
            //POUR CHACUNE DES COULEURS METTRE UN LABEL AVEC LE NOM DE LA COULEUR
            White.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "WHITE").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "WHITE").Description = White.Text;

            Blue.Text= ListEntry.getEntryfromTypeAndCode("COLOURS", "BLUE").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "BLUE").Description = Blue.Text;

            Green.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "GREEN").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "GREEN").Description = Green.Text;

            Red.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "RED").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "RED").Description = Red.Text;

            Purple.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "PURPLE").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "PURPLE").Description = Purple.Text;

            Beige.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "BEIGE").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "BEIGE").Description = Beige.Text;

            Blue_Violet.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "BLUEVIOLET").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "BLUEVIOLET").Description = Blue_Violet.Text;

            Brown.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "BROWN").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "BROWN").Description = Brown.Text;

            Coral.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "CORAL").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "CORAL").Description = Coral.Text;

            Dark_blue.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "DARKBLUE").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "DARKBLUE").Description = Dark_blue.Text;

            Dark_Magenta.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "DARKMAGERNTA").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "DARKMAGERNTA").Description = Dark_Magenta.Text;

            Forest_Green.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "FORESTGREEN").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "FORESTGREEN").Description = Forest_Green.Text;

            Fuchsia.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "FUCHSIA").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "FUCHSIA").Description = Fuchsia.Text;

            Gold.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "GOLD").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "GOLD").Description = Gold.Text;

            Gray.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "GRAY").Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", "GRAY").Description = Gray.Text;

           
        }

        /*
         * var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");
              tasksonMon = col.Find(Query.EQ("DueDate", Monday.Date));
         */
        async void OnButtonClicked(object sender, EventArgs args)
        {
            
            var col = Database.db.GetCollection<ListEntry>("ListEntries");
            // Use FindOne and not Find as we should have only one
            var resultWhite = col.FindOne(Query.And(Query.EQ("Code", "WHITE"), Query.EQ("Type", "COLOURS")));
            resultWhite.Description= White.Text;
            col.Update(resultWhite);


            ListEntry.getEntryfromTypeAndCode("COLOURS", "BLUE").Description = Blue.Text;
            var resultBlue = col.FindOne(Query.And(Query.EQ("Code", "BLUE"), Query.EQ("Type", "COLOURS")));
            resultBlue.Description = Blue.Text;
            col.Update(resultBlue);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "GREEN").Description = Green.Text;
            var resultGreen = col.FindOne(Query.And(Query.EQ("Code", "GREEN"), Query.EQ("Type", "COLOURS")));
            resultGreen.Description = Green.Text;
            col.Update(resultGreen);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "RED").Description = Red.Text;
            var resultRed = col.FindOne(Query.And(Query.EQ("Code", "RED"), Query.EQ("Type", "COLOURS")));
            resultRed.Description = Red.Text;
            col.Update(resultRed);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "PURPLE").Description = Purple.Text;
            var resultPurple = col.FindOne(Query.And(Query.EQ("Code", "PURPLE"), Query.EQ("Type", "COLOURS")));
            resultPurple.Description = Purple.Text;
            col.Update(resultPurple);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "BEIGE").Description = Beige.Text;
            var resultBeige = col.FindOne(Query.And(Query.EQ("Code", "BEIGE"), Query.EQ("Type", "COLOURS")));
            resultBeige.Description = Beige.Text;
            col.Update(resultBeige);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "BLUEVIOLET").Description = Blue_Violet.Text;
            var resultBlueViolet = col.FindOne(Query.And(Query.EQ("Code", "BLUEVIOLET"), Query.EQ("Type", "COLOURS")));
            resultBlueViolet.Description = Blue_Violet.Text;
            col.Update(resultBlueViolet);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "BROWN").Description = Brown.Text;
            var resultBrown = col.FindOne(Query.And(Query.EQ("Code", "BROWN"), Query.EQ("Type", "COLOURS")));
            resultBrown.Description = Brown.Text;
            col.Update(resultBrown);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "CORAL").Description = Coral.Text;
            var resultCoral = col.FindOne(Query.And(Query.EQ("Code", "CORAL"), Query.EQ("Type", "COLOURS")));
            resultCoral.Description = Coral.Text;
            col.Update(resultCoral);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "DARKBLUE").Description = Dark_blue.Text;
            var resultDarkBlue = col.FindOne(Query.And(Query.EQ("Code", "DARKBLUE"), Query.EQ("Type", "COLOURS")));
            resultDarkBlue.Description = Dark_blue.Text;
            col.Update(resultDarkBlue);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "DARKMAGERNTA").Description = Dark_Magenta.Text;
            var resultDarkMagenta = col.FindOne(Query.And(Query.EQ("Code", "DARKMAGERNTA"), Query.EQ("Type", "COLOURS")));
            resultDarkMagenta.Description = Dark_Magenta.Text;
            col.Update(resultDarkMagenta);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "FORESTGREEN").Description = Forest_Green.Text;
            var resultForestGreen = col.FindOne(Query.And(Query.EQ("Code", "FORESTGREEN"), Query.EQ("Type", "COLOURS")));
            resultForestGreen.Description = Forest_Green.Text;
            col.Update(resultForestGreen);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "FUCHSIA").Description = Fuchsia.Text;
            var resultFuschia = col.FindOne(Query.And(Query.EQ("Code", "FUCHSIA"), Query.EQ("Type", "COLOURS")));
            resultFuschia.Description = Fuchsia.Text;
            col.Update(resultFuschia);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "GOLD").Description = Gold.Text;
            var resultGold = col.FindOne(Query.And(Query.EQ("Code", "GOLD"), Query.EQ("Type", "COLOURS")));
            resultGold.Description = Gold.Text;
            col.Update(resultGold);

            ListEntry.getEntryfromTypeAndCode("COLOURS", "GRAY").Description = Gray.Text;
            var resultGray = col.FindOne(Query.And(Query.EQ("Code", "GRAY"), Query.EQ("Type", "COLOURS")));
            resultGray.Description = Gray.Text;
            col.Update(resultGray);


        }
    }
}