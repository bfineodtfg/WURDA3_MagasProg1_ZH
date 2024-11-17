using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WURDA3
{
    internal class City
    {
        public double[] rollers { get; set; }
        public City(int rollerPerCity) {
            rollers = new double[rollerPerCity];
        }
        public bool Over80() {
            for (int i = 0; i < rollers.Length; i++)
                if (rollers[i] < 80)
                    return false;
            return true; 
        }
        public double AVG() {
            double sum = 0;
            for (int i = 0; i < rollers.Length; i++)
            {
                sum += rollers[i];
            }
            return sum / rollers.Length;
        }
    }
}
