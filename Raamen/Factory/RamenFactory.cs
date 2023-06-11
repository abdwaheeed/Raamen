using Raamen.Model.Database;
using Raamen.Model.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Factory
{
    public class RamenFactory
    {
        public static RamenResponse ramenMap(Raman ramen, Meat meat)
        {
            return new RamenResponse
            {
                RamenId = ramen.Id,
                MeatName = meat.Name,
                Name = ramen.Name,
                Broth = ramen.Broth,
                Price = ramen.Price
            };
        }
    }
}