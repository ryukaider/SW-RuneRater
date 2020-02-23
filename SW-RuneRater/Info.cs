using System;
using System.Collections.Generic;

namespace SW_RuneRater
{
    class Info
    {
        public static Dictionary<int, string> Sets = new Dictionary<int, string>()
        {
            { 1, "Energy" },
            { 2, "Guard" },
            { 3, "Swift" },
            { 4, "Blade" },
            { 5, "Rage" },
            { 6, "Focus" },
            { 7, "Endure" },
            { 8, "Fatal" },
            { 9, "" },
            { 10, "Despair" },
            { 11, "Vampire" },
            { 12, "" },
            { 13, "Violent" },
            { 14, "Nemesis" },
            { 15, "Will" },
            { 16, "Shield" },
            { 17, "Revenge" },
            { 18, "" },
            { 19, "Fight" },
            { 20, "Determination" },
            { 21, "Enhance" },
            { 22, "Accuracy" },
            { 23, "Tolerance" }
        };

        public static Dictionary<string, double> SetWeights = new Dictionary<string, double>()
        {
            { "Energy", 1 },
            { "Guard", 1 },
            { "Swift", 1.02 },
            { "Blade", 1 },
            { "Rage", 1 },
            { "Focus", 1 },
            { "Endure", .95 },
            { "Fatal", 1 },
            { "", 1 },
            { "Despair", 1.03 },
            { "Vampire", 1 },
            //{ "" },
            { "Violent", 1.05 },
            { "Nemesis", 1.03 },
            { "Will", 1.04 },
            { "Shield", 1.03 },
            { "Revenge", 1.03 },
            //{ "" },
            { "Fight", 1.05 },
            { "Determination", 1.00 },
            { "Accuracy", 1.00 },
            { "Enhance", 1.00 },
            { "Tolerance", 1.05 }
        };

        public enum Stats { HP=1, PerHP=2, ATK=3, PerATK=4, DEF=5, PerDEF=6, SPD=8, CR=9, CD=10, RES=11, ACC=12 };

        public static Dictionary<int, string> StatNames = new Dictionary<int, string>()
        {
            { 0, "" },
            { 1, "HP" },
            { 2, "% HP" },
            { 3, "ATK" },
            { 4, "% ATK" },
            { 5, "DEF" },
            { 6, "% DEF" },
            { 7, "" },
            { 8, "SPD" },
            { 9, "CR" },
            { 10, "CD" },
            { 11, "RES" },
            { 12, "ACC" }
        };

        public static Dictionary<string, double> StatWeights = new Dictionary<string, double>()
        {
            { "", 0 },
            { "HP", .01 },
            { "% HP", 1.05 },
            { "ATK", .147 },
            { "% ATK", 1 },
            { "DEF", .173 },
            { "% DEF", 1 },
            { "SPD", 1.5 },
            { "CR", 1.35 },
            { "CD", 1.1 },
            { "RES", .85 },
            { "ACC", 1 }
        };
    }
}
