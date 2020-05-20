using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace UplanTest
{
    class ThisMaxMoney
    {
        public static CollectionForMax CurrentMax;

        public static void Initiate()
        {
            var col = Database.db.GetCollection<CollectionForMax>("MaxMoney");
            CurrentMax = col.FindOne(Query.All());
        }
        public static void UpdateAllMax(float newMaxForFood, float newMaxForGoingOut, float NewMaxForHealth, float NewMaxForHobbies, float NewMaxForOthers, float NewMaxForClothes)
        {
            CurrentMax.Update(newMaxForFood, newMaxForGoingOut, NewMaxForHealth, NewMaxForHobbies, NewMaxForOthers, NewMaxForClothes);
            Initiate();
        }
        public static void UpdateForFood(float newMaxForFood)
        {
            CurrentMax.Update(newMaxForFood, CurrentMax.MaxForGoingOut, CurrentMax.MaxForHealth, CurrentMax.MaxForHobbies, CurrentMax.MaxForOthers, CurrentMax.MaxForClothes);
            Initiate();
        }

        public static void UpdateForGoingOut(float newMax)
        {
            CurrentMax.Update(CurrentMax.MaxForFood, newMax, CurrentMax.MaxForHealth, CurrentMax.MaxForHobbies, CurrentMax.MaxForOthers, CurrentMax.MaxForClothes) ;
            Initiate();
        }

        public static void UpdateForHealth(float newMax)
        {
            CurrentMax.Update(CurrentMax.MaxForFood, CurrentMax.MaxForGoingOut, newMax, CurrentMax.MaxForHobbies, CurrentMax.MaxForOthers, CurrentMax.MaxForClothes);
            Initiate();
        }

        public static void UpdateForHobbies(float newMax)
        {
            CurrentMax.Update(CurrentMax.MaxForFood, CurrentMax.MaxForGoingOut, CurrentMax.MaxForHealth, newMax, CurrentMax.MaxForOthers, CurrentMax.MaxForClothes);
            Initiate();
        }

        public static void UpdateForOthers(float newMax)
        {
            CurrentMax.Update(CurrentMax.MaxForFood, CurrentMax.MaxForGoingOut, CurrentMax.MaxForHealth, CurrentMax.MaxForHobbies, newMax, CurrentMax.MaxForClothes);
            Initiate();
        }

        public static void UpdateForClothes(float newClothes)
        {
            CurrentMax.Update(CurrentMax.MaxForFood, CurrentMax.MaxForGoingOut, CurrentMax.MaxForHealth, CurrentMax.MaxForHobbies, CurrentMax.MaxForOthers, newClothes);
            Initiate();
        }
    }
}
