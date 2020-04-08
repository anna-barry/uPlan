using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;
using System.Linq;

namespace UplanTest
{
    class ListHelper
    {
        public List<string> DisplayList;
        public List<string> CodeList;
        public List<int> IdList;
        public List<ListEntry> ListEntryList;

        public int CurrentID;
        public int CurrentIndex;
        public string CurrentCode;
        public string CurrentDesc;
        public ListEntry CurrentListEntry;

        public static List<string> DayCodeList = new List<string>() { "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN" };
        public static List<string> DayDescList = new List<string>() { "Monday", "Tuesday", "Wendesday", "Thursday", "Friday", "Saturday", "Sunday" };

        // Use: example for Picker:
        //
        //ListHelper lh = new ListHelper("ACCOMODATION_TYPES", MyUser.me.AccomodationType.Id, "");
        //Accomodation_type.ItemsSource = lh.DisplayList;
        //Accomodation_type.SelectedIndex = lh.CurrentIndex;
        //
        // When item selected in Picker list then can get details using:
        // int selectedId = lh.IdList(picker.SelectedIndex);
        // string selectedCode = lh.CodeList(picker.SelectedIndex);
        // string selectedDisplay = lh.DisplayList(picker.SelectedIndex);

        public ListHelper(string pListType, int pCurrentId, string pCurrentCode)
        {
           if (pListType == "DAYS")
           {
                DisplayList = DayDescList;
                CodeList = DayCodeList;
                IdList = new List<int>();

                CurrentCode = pCurrentCode;

                switch (pCurrentCode)
                {
                    case "MON": CurrentIndex = 0; break;
                    case "TUE": CurrentIndex = 1; break;
                    case "WED": CurrentIndex = 2; break;
                    case "THU": CurrentIndex = 3; break;
                    case "FRI": CurrentIndex = 4; break;
                    case "SAT": CurrentIndex = 5; break;
                    case "SUN": CurrentIndex = 6; break;
                    default: CurrentIndex = -1; break;
                }

                CurrentDesc = DayDescList [CurrentIndex];
            }
            else 
            {
                DisplayList = new List<string>();
                CodeList = new List<string>();
                IdList = new List<int>();
                ListEntryList = new List<ListEntry>();

                var col = Database.db.GetCollection<ListEntry>("ListEntries");
                var results = col.Find(Query.EQ("Type", pListType)).OrderBy(x => x.Description);
                int i = 0;

                foreach (var entry in results)
                {
                    if (!(CodeList.Contains(entry.Code)))
                    { CodeList.Add(entry.Code); }

                    if (!(DisplayList.Contains(entry.Description)))
                    { DisplayList.Add(entry.Description); }

                    if (!(ListEntryList.Contains(entry)))
                    { ListEntryList.Add(entry); }

                    if (entry.Id == pCurrentId)
                    {
                        CurrentIndex = i;
                        CurrentCode = entry.Code;
                        CurrentDesc = entry.Description;
                        CurrentListEntry = entry;
                    }

                    i++;
                }
            }

        }

    }
}
