using Raamen.Model.Database;
using Raamen.Model.Output;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Factory
{
    public class TransactionFactory
    {
        public static Header createHeader(int id)
        {
            return new Header
            {
                CustomerId = id,
                StaffId = -1,
                Date = DateTime.Now
                
            };
        }

        public static Detail createDetail(CartResponse cart, int headerId)
        {
            return new Detail
            {
                HeaderId = headerId,
                RamenId = cart.RamenId,
                Quantity = cart.Quantity, 
            };
        }

        public static TransactionResponse transactionMap(Header header, Detail detail, Raman ramen)
        {
            return new TransactionResponse
            {
                DetailId = detail.HeaderId,
                RamenId = ramen.Id,
                Date = (DateTime)header.Date,
                RamenName = ramen.Name,
                CustomerId = header.CustomerId,
                Quantity = detail.Quantity,
                Price = ramen.Price,
            };
        }
    }
}