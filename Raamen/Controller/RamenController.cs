using Raamen.Handler;
using Raamen.Model.Database;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Controller
{
    public class RamenController
    {
        public static List<Raman> getAllRamen1()
        {
            return RamenHandler.getAllRamen1();
        }

        public static Raman findRamenWithId(int id)
        {
            return RamenHandler.findRamenWithId(id);
        }

        public static string insertRamen(int meatid, string name, string broth, string price)
        {
            if (meatid < 0)
            {
                return "Meat type must be chosen!";
            }

            if (RamenRepository.findMeatById(meatid))
            {
                return "There is no meat with id " + meatid;
            }

            if (!name.Contains("Ramen"))
            {
                return "Name of the ramen must contain Ramen";
            }

            if (string.IsNullOrEmpty(broth))
            {
                return "Broth cannot be empty";
            }

            /*if(broth == "")
            {
                broth = null;
                if(broth == null)
                {
                    return "Broth cannot be empty";
                }
            }*/

            if (int.TryParse(price, out int parsedPrice))
            {
                if (parsedPrice < 3000)
                {
                    return "Ramen price must be atleast 3000";
                }
            }

            RamenHandler.insertRamen(meatid, name, broth, price);

            return "Ramen has been added";
        }

        public static string updateRamen(int id, int meatid, string name, string broth, string price)
        {
            if (meatid < 0)
            {
                return "Meat type must be chosen!";
            }

            if (!name.Contains("Ramen"))
            {
                return "Name of the ramen must contain Ramen";
            }

            if (string.IsNullOrEmpty(broth))
            {
                return "Broth cannot be empty";
            }

            /*if(broth == "")
            {
                broth = null;
                if(broth == null)
                {
                    return "Broth cannot be empty";
                }
            }*/

            if (int.TryParse(price, out int parsedPrice))
            {
                if (parsedPrice < 3000)
                {
                    return "Ramen price must be atleast 3000";
                }
            }

            RamenHandler.updateRamen(id, meatid, name, broth, price);

            return "Ramen has been updated";
        }

        public static void deleteRamen(int id)
        {
            RamenHandler.deleteRamen(id);
        }
    }
}