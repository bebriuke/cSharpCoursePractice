using System;


class Program
{
    static void Main()
    {



        findMagicNumber();

        printMineSweeperNumbers();

/*
        string[,] names;

        int[][] scores;

         = 8;

        Console.WriteLine(scores[0][2]);

        int[] numbers = new int[] { 12, 98, -12, 65, 12 };
        foreach (int item in numbers)
        {
            Console.Write(item + " ");
        }*/
        Console.WriteLine();
    }

    private static void findMagicNumber()
    {
        int sk = 0;
        for (sk = 100000; sk <= 999998; sk++)
        {
            int d4 = kiek(sk * 4);
            int d5 = kiek(sk * 5);
            int d6 = kiek(sk * 6);

            int[] MAS = new int[6];
            int[] MAS4 = new int[6] { 0, 0, 0, 0, 0, 0 };
            int[] MAS5 = new int[6] { 0, 0, 0, 0, 0, 0 };
            int[] MAS6 = new int[6] { 0, 0, 0, 0, 0, 0 };

            Versk(sk, MAS);

            if ((d4 == 6) && (d5 == 6) && (d6 == 6) && (Skirtingi(MAS)))
            {

                Versk(sk * 4, MAS4);
                Versk(sk * 5, MAS5);
                Versk(sk * 6, MAS6);
                if (Vienodi(MAS, MAS4) && Vienodi(MAS, MAS5) && Vienodi(MAS, MAS6))
                {
                    Console.WriteLine("Šešiaženklis skaičius: "+ sk);
                    Console.WriteLine("Šešiaženklis skaičius padaugintas iš 4: " + sk * 4);
                    Console.WriteLine("Šešiaženklis skaičius padaugintas iš 5: " + sk * 5);
                    Console.WriteLine("Šešiaženklis skaičius padaugintas iš 6: " + sk * 6);
                    Console.WriteLine("***********");
                }
            }

        }
        Console.WriteLine("Norėdami paleisti MineSweeper sustelėkite bet kurį klavišą");
        Console.ReadKey();
    }

    static int kiek(int laik)
    {
        int d = 0;
        while (laik > 0)
        {
            laik /= 10;
            d++;
        }
        return d;
    }


    static void Versk(int sk, int[] MAS)
    {
        int i = 0;
        int[] laik = new int[11];

        while (sk > 0)
        {
            laik[i] = sk % 10;
            sk = sk / 10;
            i++;
        }

        for (int j = 0; j < i; j++)
        {
            MAS[j] = laik[i - (1 + j)];
        }

    }

    static bool Skirtingi(int[] MAS)
    {
        bool rez = true;
        int ilg = MAS.Length;
        for (int i = 0; i < ilg - 1; i++)
        {
            for (int j = i + 1; j < ilg; j++)
                if (MAS[i] == MAS[j]) return false;
        }
        return rez;
    }


    static bool Vienodi(int[] MAS1, int[] MAS2)
    {

        int ilg = MAS1.Length;
        Array.Sort(MAS1);
        Array.Sort(MAS2);
        for (int i = 0; i < ilg; i++)
        {
            if (MAS1[i] != MAS2[i]) return false;
        }
        return true;
    }

    static void printMineSweeperNumbers()
    {
        int eilSk;
        int stulpSk;
        char[,] MAS = new char[100, 100]; // masyvo dydis???
        Ivedimas(MAS, out eilSk, out stulpSk);
        PrintTable(MAS, eilSk, stulpSk);
        Console.WriteLine();

        PrintTable(Skaiciavimai(MAS, eilSk, stulpSk), eilSk, stulpSk);

        Console.ReadKey();
        //throw new NotImplementedException("TODO: Sukurkite programą kuri liepia vartotojui įvesti MineSweeper žaidimo lauko duomenis. " +
       //     "Tada paskaičiuoja ir išspausdina lentelę su skaičiais kiek aplinkui(8 kryptyse įskaitant įstrižai) yra minų.");
    }

    static void Ivedimas(char[,] array, out int eilSk, out int stulpSk)
    {
        //1) Liept vartotojui įvest bet kokio ilgio MineSweeper lauko duomenis eilutę po eilutę, tokiu formatu:
        //2) *-mina.
        //3) . -nėra minos.
        //4)Pvz: ..*..* ..* *** ....*. *.*.*.
        Console.WriteLine();
        Console.WriteLine("Įveskite bet kokio ilgio MineSweeper lauko duomenis eilutę po eilutės, tokiu formatu:");
        Console.WriteLine("        *    - jeigu yra mina;");
        Console.WriteLine("        .    - jeigu nėra minos;");
        Console.WriteLine("    <tarpas> - prieš kiekvieną naują eilutę;");
        string input = Ismetam(Console.ReadLine());
        string[] lentele = input.Split(' ');
        eilSk = lentele.Length;
        stulpSk = StulpeliuSkaicius(lentele);

        for (int i = 0; i < eilSk; i++)
        {
            string eilute = lentele[i];
            for (int j = 0; j < stulpSk; j++)
                array[i, j] = eilute[j];
        }
        //PrintTable(MAS, eilSk, stulpSk); 
       
    }

    static int StulpeliuSkaicius(string[] input)
    {
        int minimum = input[0].Length;
        foreach(string s in input)
        {
            if(s.Length < minimum)
            {
                minimum = s.Length;
            }
        }
        return minimum;
    }


    static void PrintTable(char[,] array, int n, int m)
    {
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
                Console.Write(array[i, j]+" ");
            Console.WriteLine();
        }
    }

    static void PrintTableInt(int[,] array, int n, int m)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
                Console.Write(array[i, j] + " ");
            Console.WriteLine();
        }
    }

    static char[,] Skaiciavimai(char[,] array, int n, int m)
    {
        char[,] MAS = new char[n, m];
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                if (array[i, j] != '*') MAS[i, j] = Versk(Vienas(array, i, j, m, n));
                else MAS[i, j] = '#';
               // Console.Write(MAS[i, j]+ " ");
            }
            ///Console.WriteLine();
        }


        return MAS;
    }

    static int Vienas(char[,] array, int i, int j, int n, int m)
    {
        int kiek = 0;
        for (int a = i - 1; a <= i + 1; a++)
        {
            for (int b = j - 1; b <= j + 1; b++)
            {
                if ((a >= 0)&&(b >= 0)&&(a < m)&&(b < n)&&(array[a, b] == '*'))
                {
                    kiek++;
                }
            }
        }
        if (array[i, j] == '*') kiek--;
        //Console.WriteLine(kiek);
        return kiek; 
    }

    static char Versk (int x)
    {
        char[] a = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        return a[x];
    }

    static string Ismetam(string input)
    {
        string temp = "";
        for (int i = 0; i < input.Length; i++)
        {
            if ((input[i] == '-')||(input[i] == '*')||(input[i] == ' '))
            {
                temp += input[i];
            }
        }
        return temp;
    }


}

