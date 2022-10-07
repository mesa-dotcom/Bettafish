using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bettafish.Class
{
    public class ExchangeRatePos
    {
        public string Store_ID { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public decimal Exchange_Rate { get; set; }
        public DateTime Effective_Datetime { get; set; }
        public DateTime Expired_Datetime { get; set; }
        public DateTime Create_Datetime { get; set; }
    }
}
