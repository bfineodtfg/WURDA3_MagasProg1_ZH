using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WURDA3
{
    internal class Second
    {
        Subject[] subjects = new Subject[3];
        Day[] days = new Day[5];
        int currentDay = 0;
        int maxDays = 5;
        public Second()
        {
            subjects[0] = new Subject("Természettudományok", 60);
            subjects[1] = new Subject("Informatika", 90);
            subjects[2] = new Subject("Bölcsészettudomány", 45);
            days[0] = new Day();
            while (currentDay < 5)
            {
                UserInput();
            }
            int numberOfClasses = 0;
            int lengthOfClasses = 0;
            for (int i = 0; i < days.Length; i++)
            {
                lengthOfClasses += days[i].lengthOfDay;
                numberOfClasses += days[i].subjects.Length;
            }
            Console.WriteLine($"A heti órák hossza összesen : {lengthOfClasses/60}:{lengthOfClasses%60}, darabszáma: {numberOfClasses}");
            foreach (var item in days)
            {
                Console.WriteLine(item.lengthOfDay);
                foreach (var ez in item.subjects)
                {
                    Console.WriteLine("Óra: " +ez.name);
                }
            }
        }
        void UserInput()
        {
            Console.WriteLine($"Add meg milyen óra lesz a következő ezen a napon: {currentDay + 1}. nap");
            string temp = Console.ReadLine().Trim().ToLower();
            if (temp == "következő")
            {
                currentDay++;
                if (currentDay == maxDays)
                    return;
                days[currentDay] = new Day();
                return;
            }
            for (int i = 0; i < subjects.Length; i++)
            {
                if (temp == subjects[i].name.ToLower())
                {
                    if (!days[currentDay].addSubject(subjects[i]))
                    {
                        currentDay++;
                        if (currentDay == maxDays)
                            return;
                        days[currentDay] = new Day();
                        days[currentDay].addSubject(subjects[i]);
                    }
                    else
                    {
                        Console.WriteLine("A tárgy sikeresen hozzáadásra került");
                    }
                }

            }
        }
    }
}
