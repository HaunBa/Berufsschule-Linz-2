using System;
using System.Collections.Generic;
using System.IO;

namespace Aufgabe3
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

            if (File.Exists("artikellist.txt"))
            {
                Console.WriteLine("Die Datei existiert bereits. Soll die Datei überschrieben werden? Y/N");

                char input = Console.ReadKey().KeyChar;

                if (input.ToString().ToLower() == "y")
                {
                    Console.WriteLine("Die Datei artikelliste.txt wurde neu erstellt.");
                    using (StreamWriter writer = new StreamWriter(File.Create("artikellist.txt")))
                    {
                        foreach (var item in list)
                        {
                            writer.WriteLine($"{item.Key} : {item.Value}");                            
                        }
                    }
                    Console.WriteLine("Datei erfolgreich überschrieben.");
                }
                else
                {
                    return;
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(File.Create("artikellist.txt")))
                {
                    foreach (var item in list)
                    {
                        writer.WriteLine($"{item.Key} : {item.Value}");
                    }
                }
                Console.WriteLine("Datei erfolgreich überschrieben.");
            }
        }
    }
}