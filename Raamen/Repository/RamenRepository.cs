using Raamen.Factory;
using Raamen.Model.Database;
using Raamen.Model.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Repository
{
    public class RamenRepository
    {
        public static RaamenEntities1 db = new RaamenEntities1();
        public static List<RamenResponse> getAllRamen()
        {
            return db.Ramen.Join(db.Meats,
                    ramen => ramen.MeatId,
                    meat => meat.Id,
                    RamenFactory.ramenMap).ToList();
        }
      
        public static List<Raman> getAllRamen1()
        {
            return db.Ramen.ToList();
        }

        public static Raman findRamenWithId(int id)
        {
            return db.Ramen.Find(id);
        }

        //update ramen
        public static void updateRamen(int id, int meatid, string name, string broth, string price)
        {
            Raman ramen = db.Ramen.Find(id);
            ramen.MeatId = meatid;
            ramen.Name = name;
            ramen.Broth = broth;
            ramen.Price = price;
            db.SaveChanges();
        }

        //insert ramen
        public static void insertRamen(Raman ramen)
        {
            db.Ramen.Add(ramen);
            db.SaveChanges();
        }

        //delete ramen
        public static void deleteRamen(int id)
        {
            Raman ramen = db.Ramen.Find(id);
            db.Ramen.Remove(ramen);
            db.SaveChanges();
        }

        public static bool findMeatById(int id)
        {
            try
            {
                var output =  db.Meats.Where(meat => meat.Id == id).FirstOrDefault<object>();

                if(output == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }catch(Exception e)
            {
                throw e;
            }
        }

        public static List<Meat> getAllListMeat()
        {
            return db.Meats.ToList();
        }
    }
}