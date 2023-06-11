using Raamen.Factory;
using Raamen.Model.Database;
using Raamen.Model.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Repository
{
    public class CartRepository
    {
        public static RaamenEntities1 db = new RaamenEntities1();
        public static CartResponse findRamen(int id)
        {
            return db.Ramen.Where(ramen => ramen.Id == id).Join(db.Meats,
                    ramen => ramen.MeatId,
                    meat => meat.Id,
                    CartFactory.cartMap).FirstOrDefault();
        }
    }
}