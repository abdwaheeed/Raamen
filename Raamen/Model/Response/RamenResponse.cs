using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raamen.Model.Output
{
    public class RamenResponse
    {
        public int RamenId { get; set; }
        public string MeatName { get; set; }
        public string Name { get; set; }
        public string Broth { get; set; }
        public string Price { get; set; }
    }
}