using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VSeSharpSamplesExplorer
{
    public static class ConsoleUtilities
    {
        public static void PrintLine(char character = '-', int length = 10)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(character);
            }
            Console.WriteLine(sb.ToString());
        }
        public static void Print(string value, bool pl = true)
        {
            Console.WriteLine(value);
            if(pl)
            {
                PrintLine();
            }
        }
        public static void Print(double value)
        {
            Print(value.ToString());
        }
        public static void Print(IEnumerable<dynamic> q)
        {
            foreach (var item in q)
            {
                Print($"{item.Developer} knows {item.Language}", false);
            }
            PrintLine();
        }
        public static void Print(IEnumerable<int> q)
        {
            Print(string.Join(",", q.ToArray()));
        }
    }
}
