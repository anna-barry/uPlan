﻿using System;
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
            /*POUR CHACUNE DES COULEURS METTRE UN LABEL AVEC LE NOM DE LA COULEUR
             *  White.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", "WHITE").Description;
                ListEntry.getEntryfromTypeAndCode("COLOURS", "WHITE").Description = White.Text;
             */
            GetDescAndColour(White, "WHITE");
            GetDescAndColour(Blue, "BLUE");
            GetDescAndColour(Green, "GREEN");
            GetDescAndColour(Red, "RED");
            GetDescAndColour(Purple, "PURPLE");
            GetDescAndColour(Beige, "BEIGE");
            GetDescAndColour(Blue_Violet, "BLUEVIOLET");
            GetDescAndColour(Brown, "BROWN");
            GetDescAndColour(Coral, "CORAL");
            GetDescAndColour(Dark_blue, "DARKBLUE");
            GetDescAndColour(Blue_Violet, "BLUEVIOLET");
            GetDescAndColour(Dark_Magenta, "DARKMAGERNTA");
            GetDescAndColour(Forest_Green, "FORESTGREEN");
            GetDescAndColour(Fuchsia, "FUCHSIA");
            GetDescAndColour(Gold, "GOLD");
            GetDescAndColour(Gray, "GRAY");
           

           
        }

        /*
         * var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");
              tasksonMon = col.Find(Query.EQ("DueDate", Monday.Date));
         */
        async void OnButtonClicked(object sender, EventArgs args)
        {

            /*var col = Database.db.GetCollection<ListEntry>("ListEntries");
            var resultWhite = col.FindOne(Query.And(Query.EQ("Code", "WHITE"), Query.EQ("Type", "COLOURS")));
            resultWhite.Description= White.Text;
            col.Update(resultWhite);*/

            UpdateInLiteDB("WHITE", White);
            UpdateInLiteDB("BLUE", Blue);
            UpdateInLiteDB("GREEN", Green);
            UpdateInLiteDB("RED", Red);
            UpdateInLiteDB("PURPLE", Purple);
            UpdateInLiteDB("BEIGE", Beige);
            UpdateInLiteDB("BLUEVIOLET", Blue_Violet);
            UpdateInLiteDB("BROWN", Brown);
            UpdateInLiteDB("CORAL", Coral);
            UpdateInLiteDB("DARKBLUE", Dark_blue);
            UpdateInLiteDB("DARKMAGERNTA", Dark_Magenta);
            UpdateInLiteDB("FORESTGREEN", Forest_Green);
            UpdateInLiteDB("FUCHSIA", Fuchsia);
            UpdateInLiteDB("GOLD", Gold);
            UpdateInLiteDB("GRAY", Gray);


        }


        public void GetDescAndColour(Entry Name, String CodeForEntry)
        {
            Name.Text = ListEntry.getEntryfromTypeAndCode("COLOURS", CodeForEntry).Description;
            ListEntry.getEntryfromTypeAndCode("COLOURS", CodeForEntry).Description = Name.Text;
        }

        public void UpdateInLiteDB(String CodeForEntry, Entry Name)
        {
            var col = Database.db.GetCollection<ListEntry>("ListEntries");

            ListEntry.getEntryfromTypeAndCode("COLOURS", CodeForEntry).Description = Name.Text;
            var result = col.FindOne(Query.And(Query.EQ("Code", CodeForEntry), Query.EQ("Type", "COLOURS")));
            result.Description = Name.Text;
            col.Update(result);
        }
    }
}