using Raamen.Model.Output;
using Raamen.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raamen.Repository;
using Raamen.Factory;

namespace Raamen.Handler
{
    public class RamenHandler
    {
        public static List<RamenResponse> getAllRamen()
        {
            return RamenRepository.getAllRamen();
        }

        public static List<Raman> getAllRamen1()
        {
            return RamenRepository.getAllRamen1();
        }

        public static Raman findRamenWithId(int id)
        {
            return RamenRepository.findRamenWithId(id);
        }

        public static Raman insertRamen(int meatid, string name, string broth, string price)
        {

            Raman ramen = RamenFactory.createRamen(meatid, name, broth, price);

            RamenRepository.insertRamen(ramen);
            return ramen;
        }

        public static void updateRamen(int id, int meatid, string name, string broth, string price)
        {
            RamenRepository.updateRamen(id, meatid, name, broth, price);
        }

        public static void deleteRamen(int id)
        {
            RamenRepository.deleteRamen(id);
        }
    }
}