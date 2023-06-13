using Raamen.Handler;
using Raamen.Model.Database;
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

        public static void insertRamen(int meatid, string name, string broth, string price)
        {
            RamenHandler.insertRamen(meatid, name, broth, price);
        }

        public static void updateRamen(int id, int meatid, string name, string broth, string price)
        {
            RamenHandler.updateRamen(id, meatid, name, broth, price);
        }

        public static void deleteRamen(int id)
        {
            RamenHandler.deleteRamen(id);
        }
    }
}