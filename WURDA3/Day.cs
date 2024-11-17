using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WURDA3
{
    public class Day
    {
        public int lengthOfDay { get; set; }
        public Subject[] subjects { get; set; }
        const int maxLength = 240;
        public Day()
        {
            subjects = new Subject[0];
        }
        public bool addSubject(Subject subject) {
            if (lengthOfDay + subject.length > maxLength)
                return false;
            Subject[] temp = new Subject[subjects.Length+1];
            for (int i = 0; i < subjects.Length; i++)
            {
                temp[i] = subjects[i];
            }
            temp[subjects.Length] = subject;
            lengthOfDay += subject.length;
            return true;
        }
    }
}
