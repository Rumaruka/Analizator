using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisatorPrices
{
   
    class SimpleDataBase
    {
        public SimpleDataBase()
        {
        }

        public SimpleDataBase(string tovar, string prices, string town)
        {
            this.tovar = tovar;
            this.prices = prices;
            this.town = town;
        }
        public string tovar { get; set; }
        public string prices { get; set; }
        public string town { get; set; }
    }
}
