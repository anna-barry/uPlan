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
    public partial class WellBeing : ContentPage
    {
        public WellBeing()
        {
            InitializeComponent();
            //la faire un random pour trouver la quote du jour et la mettre a quote !;text breffff
            //var col= Database.db.GetCollection<ListEntry>("ListEntries");
            //var quotes = col.FindAll(Query.EQ("DueDate", Monday.Date));

        }
    }
}