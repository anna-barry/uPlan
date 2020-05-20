using LiteDB;
using System;

namespace UplanTest
{
    public class FrigoBaseDeDonnée
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public float Sucre { get; set; }

        public float Sel { get; set; }

        public float Proteine { get; set; }

        public float Matiere_grasse { get; set; }
        public string GommetesSel { get; set; }

        public string GommetesSucre { get; set; }

        public string GommetesMG { get; set; }


        public string Ingrédients { get; set; }

        public DateTime Peremption { get; set; }


        public static void Initiate()
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");

            col.EnsureIndex(x => x.Url);
            col.EnsureIndex(x => x.Name);
            col.EnsureIndex(x => x.Sucre);
            col.EnsureIndex(x => x.Sel);
            col.EnsureIndex(x => x.Matiere_grasse);
            col.EnsureIndex(x => x.GommetesSucre);
            col.EnsureIndex(x => x.GommetesSel);
            col.EnsureIndex(x => x.GommetesMG);
            col.EnsureIndex(x => x.Proteine);
            col.EnsureIndex(x => x.Ingrédients);

            col.EnsureIndex(x => x.Peremption);

            /* col.Insert(
                 new FrigoBaseDeDonnée
                 {
                     Url = "",
                     Name = "",
                     Nutriments = "",
                     Gommetes = -1,
                     Ingrédients = "",
                     Pourcentage = -1,
                     Peremption = DateTime.Now.AddDays(-1)
                 }
                 ); */

        }

        public static void InsertProduct(string url, string name, float sucre, float sel, float matieregrasses,string gommetessel, string gommetesucre, string gommetemg, float proteine, string ingredients, DateTime peremption)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            col.EnsureIndex(x => x.Url);
            col.EnsureIndex(x => x.Name);
            col.EnsureIndex(x => x.Sucre);
            col.EnsureIndex(x => x.Sel);
            col.EnsureIndex(x => x.Matiere_grasse);
            col.EnsureIndex(x => x.GommetesSucre);
            col.EnsureIndex(x => x.GommetesSel);
            col.EnsureIndex(x => x.GommetesMG);
            col.EnsureIndex(x => x.Proteine);
            col.EnsureIndex(x => x.Ingrédients);
            col.EnsureIndex(x => x.Peremption);

            col.Insert(
                new FrigoBaseDeDonnée
                {
                    Url = url,
                    Name = name,
                    Sucre = sucre,
                    Sel = sel,
                    Matiere_grasse = matieregrasses,
                    GommetesSel = gommetessel,
                    GommetesSucre = gommetesucre,
                    GommetesMG = gommetemg,
                    Proteine = proteine,
                    Ingrédients = ingredients,
                    Peremption = peremption,



                });
            ;




        }
        public static FrigoBaseDeDonnée getEntryFromUrl(string url)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            var result = col.FindOne(Query.EQ("Url", url));
            return result;


        }




    }
}

