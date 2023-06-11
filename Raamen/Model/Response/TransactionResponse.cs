using Raamen.Model.Database;
using Raamen.View.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Model.Output
{
    public class TransactionResponse
    {
        public int DetailId { get; set; }
        public int RamenId { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string RamenName { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
    }
}