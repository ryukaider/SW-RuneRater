using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SW_RuneRater
{
    class Program
    {
        private static string filename = "Ryukaider-19745703.json";
        private static List<Rune> runes = new List<Rune>();
        private static List<int> slotCounts = new List<int>() { 0, 0, 0, 0, 0, 0, 0 };

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                filename = args[0];
            }

            string jsonString = File.ReadAllText(filename);
            var json = JObject.Parse(jsonString);

            var jsonRunes = json["runes"];

            foreach (var jsonRune in jsonRunes)
            {
                var rune = new Rune(jsonRune);

                if (rune.Level > 0)
                {
                    runes.Add(rune);
                }

                slotCounts[rune.Slot]++;
            }

            Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}{6,10}{7,10}",
                "Slot", "1", "2", "3", "4", "5", "6", "Total");
            Console.WriteLine("{0,10}{1,10}{2,10}{3,10}{4,10}{5,10}{6,10}{7,10}",
                "# of Runes", slotCounts[1], slotCounts[2], slotCounts[3], slotCounts[4], slotCounts[5], slotCounts[6], jsonRunes.Count());

            runes = runes.OrderByDescending(o => o.Rating).ToList();

            // Print runes by slot
            for (int slot = 1; slot <= 6; slot++)
            {
                PrintHeader();

                foreach (var rune in runes)
                {
                    if (rune.Slot == slot)
                    {
                        rune.Print();
                    }
                }
            }

            // Print all runes
            PrintHeader();
            foreach (var rune in runes)
            {
                rune.Print();
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static void PrintHeader()
        {
            Console.WriteLine();
            Console.WriteLine("{0,8}{1,10}{2,7}{3,6}{4,7}{5,10}{6,10}{7,40}{8,10}",
                "Equipped",
                "Set",
                "Stars",
                "Slot",
                "Level",
                "Pimary",
                "Secondary",
                "Stats",
                "Rating"
                );
        }
    }
}
