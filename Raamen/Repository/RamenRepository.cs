﻿using Raamen.Factory;
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
    }
}