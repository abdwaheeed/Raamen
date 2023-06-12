using Raamen.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Repository
{
    public class HistoryRepository
    {
        public static RaamenEntities1 db = new RaamenEntities1();
        
        public static List<Header> getHistory(int id)
        {
            return db.Headers.Where(t => t.CustomerId == id).ToList();
        }

        public static List<Header> getAllHistory()
        {
            return db.Headers.ToList();
        }
    }
}