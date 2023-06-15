using Raamen.Model.Database;
using Raamen.Model.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Factory
{
    public class CartFactory
    {
        public static CartResponse cartMap(Raman ramen, Meat meat)
        {
            return new CartResponse
            {
                RamenId = ramen.Id,
                Name = ramen.Name,
                MeatName = meat.Name,
                Broth =  ramen.Broth,
                Price = ramen.Price,
                Quantity = 1
            };
        }
    }
}