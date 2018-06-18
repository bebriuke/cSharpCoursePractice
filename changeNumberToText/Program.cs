using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skaičius_i_zodį
{
    class Program
    {
        static void Main(string[] args)
        {

            int skaitmenu_skaicius;
            int x;

            Console.WriteLine("Įvesk skaičių : ");
            string sk = Console.ReadLine();
            Console.WriteLine(ArSkaicius(sk));

            Tikrink(sk, out skaitmenu_skaicius, out x);
            Console.WriteLine(skaitmenu_skaicius + " skaitmenų yra skaičiuje " + x);

            Console.WriteLine(ChangeOnesToText(x, skaitmenu_skaicius));


            Console.ReadKey();
        }

        static bool ArSkaicius(string x)
        {
            foreach (char c in x)
                if (c < '0' || c > '9')
                    return false;
            return true;
        }

        static void Tikrink(string a, out int skaitmenu_skicius, out int x)
        {
            x = Convert.ToInt32(a);
            int laik = x;
            skaitmenu_skicius = 0;
            while(laik > 0)
            {
                laik /= 10;
                skaitmenu_skicius++;
            }
        }



        static string ChangeOnesToText(int x, int d)
        {
            string rez = "";
            string tuscia = "";
            string[] vienetai = new[] { "nulis", "vienas", "du", "trys", "keturi", "penki", "sesi", "septyni", "astuoni", "devyni" };
            string[] dvidesimt = new[] { "desimt", "vienualika", "dvylika", "trylika", "keturiolika", "penkiolika", "sesiolika", "septyniolika", "astuoniolika", "devyniolika" };
            string[] desimtys = new[] { "dvidesimt", "trisdesimt", "keturiasdesimt", "penkiasdesimt", "sesiasdesimt", "septyniasdesimt", "astuoniasdesimt", "devyniasdesimt" };
            string[] vienas = new[] { "simtas", "tukstantis", "milijonas", "milijardas" };
            string[] du = new[] { "simtai", "tukstanciai", "milijonai", "milijardai" };
            string[] kiek = new[] { "simtu", "tukstanciu", "milijonu", "milijardu" };

            switch (d)
            {
                case 1:
                    rez = rez + vienetai[x];
                    break;
                case 2:
                    if (x < 20) rez = rez + dvidesimt[x%10]; 
                    else
                    {
                        rez = rez + desimtys[x / 10 - 2] +  ((x % 10 != 0) ? " " + ChangeOnesToText(x % 10, d - 1) : "") ;
                    }
                    break;
                case 3:
                    rez = rez + ChangeOnesToText(x / 100, 1)+ " " + ((x / 100 == 1) ? vienas[0] : du[0]) +" " + ChangeOnesToText(x % 100, d - 1);
                    break;
                case 4:
                case 5:
                case 6:
                    Console.WriteLine(x / 1000 + " " + (d - 3));
                    rez = rez + ChangeOnesToText(x/1000, d-3)+" "+ parink(x, 1) + " " + ChangeOnesToText(x % 1000, 3); 
                    break;
                case 7:
                case 8:
                case 9:
                    Console.WriteLine(x / 1000000 + " " + (d - 6));
                    rez = rez + ChangeOnesToText(x / 1000000, d - 6) + " " + parink(x, 2) + " " + ChangeOnesToText(x % 1000000, 6);
                    break;
                default:
                    Console.WriteLine(x / 1000000000 + " " + (d - 9));
                    rez = rez + ChangeOnesToText(x / 1000000000, d - 9) + " " + parink(x, 3) + " " + ChangeOnesToText(x % 1000000000, 9);
                    break;
            }
            return rez;
        }

        static string parink(int x, int index)
        {
            string[] vienas = new[] { "simtas", "tukstantis", "milijonas", "milijardas" };
            string[] du = new[] { "simtai", "tukstanciai", "milijonai", "milijardai" };
            string[] kiek = new[] { "simtu", "tukstanciu", "milijonu", "milijardu" };

            int sk = x / 1000;
            if (index == 1) sk = x / 1000;
            if (index == 2) sk = x / 1000000;
            if (index == 3) sk = x / 1000000000;

            if (sk == 1) return vienas[index];
            else if ((sk > 20) && (sk % 10 == 1)) return vienas[index];
            else if (((sk > 9) && (sk  < 21))||(sk%10 == 0)) return kiek[index];
                 else return du[index];

        }
    }
}
