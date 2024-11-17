using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WURDA3
{
    internal class Third
    {
        Random r = new Random();
        int rollerPerCity = 50;
        double[] rollers;
        City[] cities;
        public Third()
        {
            int cityNumber = NumOfCities();
            rollers = new double[cityNumber * rollerPerCity];
            for (int i = 0; i < rollers.Length; i++)
                rollers[i] = (double)r.Next(301, 1001) / 10;
            getAverageUnder60();
            whichIsMore30Or100();
            MakeCities();
            LowestCity();
            if (IsOver80())
                Console.WriteLine("Volt olyan város ahol az összes roller töltöttségi szintje 80% felett volt");
            else
                Console.WriteLine("Volt olyan város ahol az összes roller töltöttségi szintje 80% felett volt");
            
        }
        bool IsOver80() {
            for (int i = 0; i < cities.Length; i++)
                if (cities[i].Over80())
                    return true;
            return false;
        }
        void LowestCity() {
            double[] averages = new double[cities.Length];
            for (int i = 0; i < cities.Length; i++)
                averages[i] = cities[i].AVG();
            double min = averages[0];
            int city = 0;
            for (int i = 0; i < averages.Length; i++)
                if (min > averages[i]) { 
                    min = averages[i];
                    city = i;
                }
            Console.WriteLine($"A legalacsonyabb átlag töltöttséggel rendelkező város a/az: {city+1}. város");
        }
        void MakeCities() {
            cities = new City[rollers.Length / rollerPerCity];
            for (int i = 0; i < cities.Length; i++)
            {
                cities[i] = new City(rollerPerCity);
                for (int j = 0; j < rollerPerCity; j++)
                {
                    cities[i].rollers[j] = rollers[j + i * rollerPerCity];
                }
            }
        }
        void whichIsMore30Or100() {
            int lower = 0;
            int higher = 0;
            for (int i = 0; i < rollers.Length; i++)
                if (rollers[i] == 30.1)
                    lower++;
                else
                    higher++;
            if (lower > higher)
                Console.WriteLine("30.1%-osból van több");
            else
                Console.WriteLine("100%-osból van több");
        }
        void getAverageUnder60() {
            int max60Count = 0;
            double max60Sum = 0;
            for (int i = 0; i < rollers.Length; i++)
            {
                if (rollers[i] < 60)
                {
                    max60Count++;
                    max60Sum += rollers[i];
                }
            }
            double avg = max60Sum / max60Count;
            Console.WriteLine($"Átlagos töltöttség 60% alatt: {avg.ToString("0.0")}");
        }
        int NumOfCities()
        {
            int number = -1;
            try
            {
                do
                {
                    Console.WriteLine("Hány városban üzemeltetnek rollereket? (10 <= x <= 45)");
                    string temp = Console.ReadLine().Trim();
                    number = int.Parse(temp);
                } while (number < 10 && number > 45);
            }
            catch (Exception e)
            {
                Console.WriteLine("Hibás adat bevitel!" + e.Message);
            }
            return number;
        }
    }
}
