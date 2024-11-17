using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WURDA3
{
    internal class First
    {
        Random r = new Random();
        DataPackage[] packages = new DataPackage[3];
        int choosenPackage;
        bool additionalData = false;
        public First()
        {
            packages[0] = new DataPackage("Mini", 4990, 25, 25, 1, 1250);
            packages[1] = new DataPackage("Normál", 8590, 0, 20, 6, 1050);
            packages[2] = new DataPackage("Fullos", 13990, 0, 0, 15, 900);
            Start();
        }
        void Start()
        {
            if (FirstQuestion())
            {
                if (BiggestPackage())
                    WritePackageRecommendation(2);
                else
                    WritePackageRecommendation(1);
            }
            else
                WritePackageRecommendation(0);
            if (choosenPackage < 2)
                additionalData = BonusData();
            GenerateRandomUser();
        }
        void WritePackageRecommendation(int num)
        {
            Console.WriteLine("Az ajánlott csomag: " + packages[num].name);
            choosenPackage = num;
        }
        bool FirstQuestion()
        {
            Console.WriteLine("Szeretne korlátlan hálózaton belüli és EU-s hívást? (igen / nem)");
            string temp = Console.ReadLine().Trim().ToLower();
            if (temp == "igen")
                return true;
            else if (temp == "nem")
                return false;
            else
                throw new NotSupportedException();
        }
        bool BiggestPackage()
        {
            int number = -1;
            try
            {
                do
                {
                    Console.WriteLine("Becslése szerint hány GB adatforgalomra lesz szüksége? (6GB vagy 15GB)");
                    string temp = Console.ReadLine().Trim();
                    number = int.Parse(temp);
                } while (number != 6 && number != 15);
            }
            catch (Exception e)
            {
                Console.WriteLine("Hibás adat bevitel!" + e.Message);
            }
            if (number == 6)
                return false;
            return true;
        }
        bool BonusData()
        {
            Console.WriteLine("Szeretne havi 1600 Ft-ért plusz 1,5GB adatforgalmat? (igen / nem)");
            string temp = Console.ReadLine().Trim().ToLower();
            if (temp == "igen")
                return true;
            else if (temp == "nem")
                return false;
            else
                throw new NotSupportedException();
        }
        void GenerateRandomUser()
        {
            int minutes = r.Next(0, 361);
            int sms = r.Next(0, 101);
            double data = (double)r.Next(0, 751) / 100;
            Console.WriteLine($"A felhasznált percek: {minutes}");
            Console.WriteLine($"A felhasznált smsek: {sms}");
            Console.WriteLine($"A felhasznált adat: {data}");
            int sum = packages[choosenPackage].monthlyPrice;
            sum += minutes * packages[choosenPackage].minutePrice;
            sum += sms * packages[choosenPackage].smsPrice;
            if (additionalData)
            { 
                sum += 1600;
                packages[choosenPackage].dataIncluded += 1.5;
            }
            if (data > packages[choosenPackage].dataIncluded)
                sum += (int)Math.Ceiling(data - packages[choosenPackage].dataIncluded) * packages[choosenPackage].additionalDataPrice;
            Console.WriteLine("Fizetendő összeg: " + sum);
        }
        
    }
}
