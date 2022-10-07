using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bettafish.Class
{
    public class ExchangeRate
    {
        public string Store_CD { get; set; }
        public string EX_From { get; set; }
        public string EX_To { get; set; }
        public decimal? Rate_AMT { get; set; }
        public DateTime Start_DT { get; set; }
        public DateTime End_DT { get; set; }
    }
}
