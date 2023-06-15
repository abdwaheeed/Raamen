using Raamen.Factory;
using Raamen.Model.Database;
using Raamen.Model.Output;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Handler
{
    public class TransactionHandler
    {
        public static void createOrder(CartResponse cart, int id)
        {

            Header h = TransactionFactory.createHeader(id);
            TransactionRepository.addHeader(h);

            Detail d = TransactionFactory.createDetail(cart, h.Id);
            TransactionRepository.addDetail(d);
        }

        public static void handleOrder(int idRow, int idUser)
        {
            Header h = TransactionRepository.getHandle(idRow);
            TransactionRepository.handleOrder(h, idUser);
        }

        public static List<Header> getTransactionHeader()
        {
            return TransactionRepository.getTransactionHeader();
        }
    }
}