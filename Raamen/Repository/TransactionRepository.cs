using Raamen.Factory;
using Raamen.Model.Database;
using Raamen.Model.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Repository
{
    public class TransactionRepository
    {
        public static RaamenEntities1 db = new RaamenEntities1();
        public static int getMeatId(string name)
        {
            return db.Meats.Where(t => t.Name == name).Select(t => t.Id).FirstOrDefault();
        }

        public static void addHeader(Header h)
        {
            db.Headers.Add(h);
            db.SaveChanges();
        }

        public static void addDetail(Detail d)
        {
            db.Details.Add(d);
            db.SaveChanges();
        }

        public static List<TransactionResponse> getUnhandleOrder()
        {
            var query = db.Headers
                .Where(t => t.StaffId == -1)
                .Join(
                    db.Details,
                    header => header.Id,
                    detail => detail.HeaderId,
                    (header, detail) => new
                    {
                        Header = header,
                        Detail = detail
                    })
                .Join(
                    db.Ramen,
                    details => details.Detail.RamenId,
                    ramen => ramen.Id,
                    (details, ramen) => new
                    {
                        Header = details.Header,
                        Detail = details.Detail,
                        Ramen = ramen
                    });

            var result = query.AsEnumerable()
                .Select(details => TransactionFactory.transactionMap(details.Header, details.Detail, details.Ramen))
                .ToList();

            return result;
        }

        public static List<TransactionResponse> getHandleOrder()
        {
            var query = db.Headers
                .Where(t => t.StaffId != -1)
                .Join(
                    db.Details,
                    header => header.Id,
                    detail => detail.HeaderId,
                    (header, detail) => new
                    {
                        Header = header,
                        Detail = detail
                    })
                .Join(
                    db.Ramen,
                    details => details.Detail.RamenId,
                    ramen => ramen.Id,
                    (details, ramen) => new
                    {
                        Header = details.Header,
                        Detail = details.Detail,
                        Ramen = ramen
                    });

            var result = query.AsEnumerable()
                .Select(details => TransactionFactory.transactionMap(details.Header, details.Detail, details.Ramen))
                .ToList();

            return result;
        }

        public static List<TransactionResponse> getHandleOrderById(int id)
        {
            var query = db.Headers
                .Where(t => t.Id == id && t.StaffId != -1)
                .Join(
                    db.Details,
                    header => header.Id,
                    detail => detail.HeaderId,
                    (header, detail) => new
                    {
                        Header = header,
                        Detail = detail
                    })
                .Join(
                    db.Ramen,
                    details => details.Detail.RamenId,
                    ramen => ramen.Id,
                    (details, ramen) => new
                    {
                        Header = details.Header,
                        Detail = details.Detail,
                        Ramen = ramen
                    });

            var result = query.AsEnumerable()
                .Select(details => TransactionFactory.transactionMap(details.Header, details.Detail, details.Ramen))
                .ToList();

            return result;
        }

        public static List<Header> getTransactionHeader()
        {
            return db.Headers.Where(t => t.StaffId != -1).ToList();
        }
        public static Header getHandle(int id)
        {
            return db.Headers.Where(t => t.Id == id).FirstOrDefault();
        }
        public static void handleOrder(Header h, int id)
        {
            h.StaffId = id;
            db.SaveChanges();
        }
    }
}