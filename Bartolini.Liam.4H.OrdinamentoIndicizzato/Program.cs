using System;
using System.IO;
using System.Collections.Generic;
using Bartolini.Liam._4H.OrdinamentoIndicizzato.Models;

namespace Bartolini.Liam._4H.OrdinamentoIndicizzato
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bartolini Liam Ordinamento indicizzato 18/12/2020\n");
            
            int N = 0;
            using (var reader = new StreamReader("dati.dat"))
                while(reader.ReadLine() != null)
                    N++;

            List<string> strOriginali = new List<string>();
            List<string> strVal = new List<string>();
            List<int> indici= new List<int>();

            using(var reader = new StreamReader("dati.dat"))
                for (int i = 0; i < N; i++)
                {
                    string row = reader.ReadLine();
                    strVal.Add(row);
                    strOriginali.Add(row);
                    indici.Add(i);     
                }

            // Sort degli indici
            for (int i = 0; i < N-1; i++)
                for (int j = i + 1; j < N; j++)
                    if(strVal[indici[i]].CompareTo(strVal[indici[j]]) > 0)
                    {
                        int tmp = indici[i];
                        indici[i] = indici[j];
                        indici[j] = tmp;
                    }

            ConsoleDataFormatter.PrintSeperatorLine();
            ConsoleDataFormatter.PrintRows("ORIGINAL STRING", "SORTED INDEX", "SORTED STRING");
            ConsoleDataFormatter.PrintSeperatorLine();

            for (int i = 0; i < N; i++)
                ConsoleDataFormatter.PrintRows(strOriginali[i], indici[i].ToString(), strVal[indici[i]]);
            
            ConsoleDataFormatter.PrintSeperatorLine();
        }
    }
}