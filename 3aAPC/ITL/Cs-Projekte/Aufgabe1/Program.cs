using System;
using System.Collections.Generic;

namespace Aufgabe1
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<string, int> list = new SortedList<string, int>();

            for (int i = 0; i < args.Length; i++)
            {
                list.Add(args[i], i);
            }

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }
        }
    }
}
