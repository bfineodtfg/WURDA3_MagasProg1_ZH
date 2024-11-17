using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WURDA3
{
    public class DataPackage
    {
        public DataPackage(string name, int monthlyPrice, int minutePrice, int smsPrice, int dataincluded, int additionalDataPrice) {
            this.name = name;
            this.monthlyPrice = monthlyPrice;
            this.minutePrice = minutePrice;
            this.smsPrice = smsPrice;
            this.dataIncluded = dataincluded;
            this.additionalDataPrice = additionalDataPrice;
        }
        public string name { get; set; }
        public int monthlyPrice { get; set; }
        public int minutePrice { get; set; }
        public int smsPrice { get; set; }
        public double dataIncluded { get; set; }
        public int additionalDataPrice { get; set; }
    }
}
