using System;
using System.IO;
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
            {
                while(reader.ReadLine() != null)
                    N++;
            }

            string[] strOriginali = new string[N];
            string[] strVal = new string[N];
            int[] indici = new int[N];
            
            using(var reader = new StreamReader("dati.dat"))
            {
                string row;
                for (int i = 0; i < N; i++)
                {
                    row = reader.ReadLine();
                    strVal[i] = row;
                    strOriginali[i] = row;

                    indici[i] = i;     
                }
            }

            // Sort degli indici
            for (int i = 0; i < N-1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (String.Compare(strVal[indici[i]], strVal[indici[j]]) > 0)
                    {
                        int tmp = indici[i];
                        indici[i] = indici[j];
                        indici[j] = tmp;
                    }
                }
            }
            ConsoleDataFormatter.PrintSeperatorLine();
            ConsoleDataFormatter.PrintRows("ORIGINAL STRING", "SORTED INDEX", "SORTED STRING");
            ConsoleDataFormatter.PrintSeperatorLine();

            for (int i = 0; i < N; i++)
            {
                ConsoleDataFormatter.PrintRows(strOriginali[i], indici[i].ToString(), strVal[indici[i]]);
            }

            ConsoleDataFormatter.PrintSeperatorLine();
        }
    }
}