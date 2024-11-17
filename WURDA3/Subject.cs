using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WURDA3
{
    public class Subject
    {
        public Subject(string name, int length) {
            this.name = name;
            this.length = length;
        }
        public int length { get; set; }
        public string name { get; set; }
    }
}
