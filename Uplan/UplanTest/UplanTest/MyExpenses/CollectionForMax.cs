using System;
using System.Collections.Generic;
using System.Text;

namespace UplanTest
{
    class CollectionForMax
    {

        public int Id { get; set; }

        public float MaxForFood { get; set; }

        public float MaxForGoingOut { get; set; }

        public float MaxForClothes { get; set; }
        public float MaxForHealth { get; set; }
        public float MaxForHobbies { get; set; }
        public float MaxForOthers { get; set; }

        public static void Initiate()
        {
            var col = Database.db.GetCollection<CollectionForMax>("MaxMoney");

            col.EnsureIndex(x => x.MaxForFood);
            col.EnsureIndex(x => x.MaxForGoingOut);
            col.EnsureIndex(x => x.MaxForHealth);
            col.EnsureIndex(x => x.MaxForHobbies);
            col.EnsureIndex(x => x.MaxForOthers);
            col.EnsureIndex(x => x.MaxForClothes);

            col.Insert(
                new CollectionForMax
                {
                    MaxForFood = 0,
                    MaxForGoingOut = 0,
                    MaxForHealth = 0,
                    MaxForClothes = 0,
                    MaxForHobbies = 0,
                    MaxForOthers = 0,
                }); ;

        }

        public void Update(float newMaxForFood,float newMaxForGoingOut, float NewMaxForHealth,float NewMaxForHobbies, float NewMaxForOthers, float NewMaxForClothes)
        {
            var col = Database.db.GetCollection<CollectionForMax>("MaxMoney");
            CollectionForMax thisMax = col.FindById(Id);
            thisMax.MaxForFood = newMaxForFood;
            thisMax.MaxForGoingOut = newMaxForGoingOut;
            thisMax.MaxForHealth = NewMaxForHealth;
            thisMax.MaxForHobbies = NewMaxForHobbies;
            thisMax.MaxForOthers = NewMaxForOthers;
            thisMax.MaxForClothes = NewMaxForClothes;

            col.Update(thisMax);
            
        }

        public CollectionForMax()     
        {
            }
        }
}
