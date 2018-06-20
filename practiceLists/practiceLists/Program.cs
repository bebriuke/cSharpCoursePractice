using System;
using System.Collections.Generic;
using System.IO;

class Program
{

    static void Main()
    {

        


        const string f = "bandymas.txt";
        List<string> lines = new List<string>(); // klasė turi turėti (), tai juk yra funkcija
        List<string> tekstas = new List<string>(); // list sąrašo dydis didėja kas 16, galima į sklaiustus įrašyti pradinį listo dydį
        // StreamReader for disposing.
        using (StreamReader r = new StreamReader(f))
        {
            // Use while != null pattern for loop
            string line;
            while ((line = r.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }

        for (int i = 0; i < lines.Count; i++)
        {
            string[] laikinas = Sutvarkytas(AtskirtiZodiai(lines[i]));
            tekstas.AddRange (AddArray(laikinas));
            
        }

        PrintList(tekstas);
        Console.WriteLine();
        
        PrintListIlgiausi(tekstas, IlgiausiasIlgis(tekstas));

        Console.WriteLine(Yra(tekstas, "atlikti"));

        Console.WriteLine("**************");

        PrintListEilute(Straipsnis(tekstas));

        Console.WriteLine();
        Console.WriteLine();

        PrintListEilute(StraipsnisSuTaskais(tekstas));

        Console.ReadKey();


        


    }

    static List <string> StraipsnisSuTaskais(List<string> input)
    {
        Random rnd = new Random();
        int ilgis = input.Count;
        Console.WriteLine(ilgis);
        List<string> laikinas = new List<string>();
        int i = 0;
        while (i < ilgis)
        {
            int KurTaskas = rnd.Next(2, 13);
            Console.WriteLine(KurTaskas);
            if (i + KurTaskas - 1 >= ilgis) break;
            for(int j = i; j < (i+KurTaskas-1); j++)
            {
                laikinas.Add(input[j]);
            }

            
            laikinas.Add(input[KurTaskas-1]+".");
            i = KurTaskas + i;
        }
        return laikinas;
    }

    static List<string> Straipsnis(List <string> input)
    {
        Random rnd = new Random();
        int sk = 0;
        int ZodziuSk = rnd.Next(1, 100);
        int ilgis = input.Count;
        //Console.WriteLine(input[ilgis-1]);
        List<string> laikinas = new List<string>();
        
        for (int i=0; i<ZodziuSk; i++)
        {
            sk = rnd.Next(0, ilgis-1);
            laikinas.Add(input[sk]);
        }
        return laikinas;
    }

    static bool Yra (List <string> input, string zodis)
    {
        foreach (string s in input)
        {
            if(s == zodis)
            {
                return true;
            }
        }
        return false;
    }

    static List <string> AddArray(string[] input)
    {
        List<string> laikinas = new List<string>();
        int i = 0;
        foreach (string x in input)
        {
            laikinas.Add(x);
            i++;
        }
        return laikinas;

    }

    static string VienasZodis (string input)
     {
        char[] MAS = { ',' , '.', ':', ';', '„', '“', '\t', '(', ')', '?' };
        string temp = input;
        //Console.Write(temp+" ");

        //temp = temp.Trim(new Char[] { ',', '.', ':', ';', '„', '“', '\t', '(', ')', '?' });

        for (int i = 0; i < MAS.Length; i++)
        {
            while (temp.Contains(MAS[i].ToString()))
            {
                int x1 = temp.IndexOf(MAS[i]);
                temp = temp.Remove(x1, 1);
               // Console.Write(" " + MAS[i] + " " + temp);
            }
                  
        }
        //Console.WriteLine(temp);
        return temp;       
     }

      static string[] Sutvarkytas (string [] MAS)
      {
          string[] laikinas = new string[MAS.Length];
          for (int i = 0; i < MAS.Length; i++)
          {
              string laik = VienasZodis(MAS[i]);
              
              laikinas[i] = laik;
          }
          return laikinas;
      }

    static string[] AtskirtiZodiai(string input)  // funkcija nesuveikė :(
    {
        return input.Split(' ');
    }
    

    static void PrintList(List<string> tekstas)
    {
        tekstas.ForEach(Console.WriteLine);
    }

    static void PrintListEilute(List<string> tekstas)
    {
        foreach(string s in tekstas)
        {
            Console.Write(s + " ");
        }
    }

    static int IlgiausiasIlgis (List <string> input)
    {
        int maxim = 0;
        for (int i = 0; i < input.Count; i++)
        {
            if (maxim < input[i].Length)
            {
                maxim = input[i].Length;
            }
        }
        return maxim;
    }

    static void PrintListIlgiausi(List<string> tekstas, int ilgis)
    {
        Console.WriteLine("***  Ilgiausi žodžiai  ***");
        foreach (string s in tekstas)
        {
            if (s.Length >= ilgis)
            {
                Console.WriteLine(s);
            }
        }
    }

}