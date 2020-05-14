using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace UplanTest
{
    static class ListEntryYOGA
    {
        public static void Initiate()
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<ListEntry>("ListEntries");

            // Create initial data

            //QUOTES
            col.Insert(new ListEntry { Type = "QUOTES", Code = "0", Description = "Remember where do you come from" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "1", Description = "Take a warm bath" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "2", Description = "Have a break to take care of yourself" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "3", Description = "Read a book" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "4", Description = "Connect with your spiritual self" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "5", Description = "Do crafts" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "6", Description = "Clear your space" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "7", Description = "Cook a good meal" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "8", Description = "Light candles" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "9", Description = "Spray essential oils" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "10", Description = "Go outside" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "11", Description = "Put positive notes around your home (ex:i am worthy)" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "12", Description = "You have the power to shape your reality" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "13", Description = "Color or draw" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "14", Description = "Make out a gratitude master list" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "15", Description = "Put away your to do list" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "16", Description = "Visualize your highest self and start showing up as her/his" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "17", Description = "Life is tought but so are you" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "18", Description = "If you get tired, learn to rest not to quit" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "19", Description = "Trust the timing of your life" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "20", Description = "Drink some water" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "21", Description = "Take a breath" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "22", Description = "If it doesn't challenge you, it wont whange you" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "23", Description = "Hard work will never disapoint you" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "24", Description = "A mistake is success in progress" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "25", Description = "You got this" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "26", Description = "Don't stop until you are proud" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "27", Description = "You are going to make you so proud" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "28", Description = "Massage your face" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "29", Description = "Release body tension" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "30", Description = "Make exercises" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "31", Description = "Take a walk" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "32", Description = "Do a self massage" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "33", Description = "Listen to calm music" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "34", Description = "Have company/ Enjoy solitude" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "35", Description = "Be thankfull" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "36", Description = "Have a good sleep" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "37", Description = "Make a vision board" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "38", Description = "Take time to think" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "39", Description = "Be mindful" });
            col.Insert(new ListEntry { Type = "QUOTES", Code = "40", Description = "Identify your values" });

            //MUSIC-> pense coder directement la fonction mais pas ici :
            /*System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"C:\MyFolder\MyFile.wav");
            sp.Play(); */

        }
    }
}
