using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Bartolini.Liam._4H.OrdinamentoIndicizzato
{
    class ConsoleDataFormatter
    {
        const int TableWidth = 80;
        public static void PrintSeperatorLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        static public void PrintRows(params string[] columns)
        {
            int columnWidth = (TableWidth - columns.Length) / columns.Length;
            const string seed = "|";

            string row = columns.Aggregate("|", (separator, columnsText) => separator + GetCenterAllignedText(columnsText, columnWidth) + seed);
            Console.WriteLine(row);
        }

        static string GetCenterAllignedText(string columnText, int columnWidth)
        {
            columnText = columnText.Length > columnWidth ? columnText.Substring(0, columnWidth - 3) + "..." : columnText;

            return string.IsNullOrEmpty(columnText) ? new string(' ', columnWidth) : columnText.PadRight(columnWidth - ((columnWidth - columnText.Length) / 2)).PadLeft(columnWidth);
        }
    }

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