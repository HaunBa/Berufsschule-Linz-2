using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Aufgabe2
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, string> list = new SortedDictionary<int, string>();

            using (StreamReader read = new StreamReader(File.Open("artikel.txt", FileMode.Open)))
            {
                string line = "";
                while ((line = read.ReadLine()) != null)
                {
                    string[] cutstring = line.Split(" ");
                    list.Add(Convert.ToInt32(cutstring[0]), cutstring[1]);
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }
    }
}
