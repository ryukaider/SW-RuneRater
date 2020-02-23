using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace SW_RuneRater
{
    class Rune
    {
        public string Id { get; set; }
        public string Set { get; set; }
        public bool Equipped { get; set; }
        public int Slot { get; set; }
        public int Stars { get; set; }
        public int Level { get; set; }

        public string PrimaryName { get; set; }
        public int PrimaryValue { get; set; }
        public string SecondaryName { get; set; }
        public int SecondaryValue { get; set; }
        public string Stat1Name { get; set; }
        public int Stat1Value { get; set; }
        public string Stat2Name { get; set; }
        public int Stat2Value { get; set; }
        public string Stat3Name { get; set; }
        public int Stat3Value { get; set; }
        public string Stat4Name { get; set; }
        public int Stat4Value { get; set; }

        public double Rating { get; set; }

        public Rune(JToken json)
        {
            Id = json["rune_id"].ToString();
            Equipped = (json["occupied_type"].ToString() == "2") ? false : true;
            Slot = Convert.ToInt16(json["slot_no"]);
            Stars = Convert.ToInt16(json["class"]);
            Set = Info.Sets[Convert.ToInt16(json["set_id"])];
            Level = Convert.ToInt16(json["upgrade_curr"]);

            PrimaryName = Info.StatNames[Convert.ToInt16(json["pri_eff"][0])];
            PrimaryValue = Convert.ToInt16(json["pri_eff"][1]);
            SecondaryName = Info.StatNames[Convert.ToInt16(json["prefix_eff"][0])];
            SecondaryValue = Convert.ToInt16(json["prefix_eff"][1]);

            SecondaryName = Info.StatNames[Convert.ToInt16(json["prefix_eff"][0])];
            SecondaryValue = Convert.ToInt16(json["prefix_eff"][1]);

            try
            {
                Stat1Name = Info.StatNames[Convert.ToInt16(json["sec_eff"][0][0])];
                Stat1Value = Convert.ToInt16(json["sec_eff"][0][1]);
                Stat2Name = Info.StatNames[Convert.ToInt16(json["sec_eff"][1][0])];
                Stat2Value = Convert.ToInt16(json["sec_eff"][1][1]);
                Stat3Name = Info.StatNames[Convert.ToInt16(json["sec_eff"][2][0])];
                Stat3Value = Convert.ToInt16(json["sec_eff"][2][1]);
                Stat4Name = Info.StatNames[Convert.ToInt16(json["sec_eff"][3][0])];
                Stat4Value = Convert.ToInt16(json["sec_eff"][3][1]);
            }
            catch { }

            Rating = CalculateRating();
        }

        private double CalculateRating()
        {
            // Calculate weighted sub-stats
            double weightedSecondary = GetWeightedValue(SecondaryName, SecondaryValue);
            double weightedStat1 = GetWeightedValue(Stat1Name, Stat1Value);
            double weightedStat2 = GetWeightedValue(Stat2Name, Stat2Value);
            double weightedStat3 = GetWeightedValue(Stat3Name, Stat3Value);
            double weightedStat4 = GetWeightedValue(Stat4Name, Stat4Value);
            double rating = weightedSecondary + weightedStat1 + weightedStat2 + weightedStat3 + weightedStat4;

            // Calculate primary stat weight

            // Calculate set weights
            rating = rating * Info.SetWeights[Set];

            // Calculate set-stat combo weight

            // Calculate slot weight
            if (Slot % 2 == 0)
            {
                rating = rating * 1.05;
            }

            // Calculate stars weight
            rating = rating * GetStarsWeight();

            rating = Math.Round(rating, 1);
            return rating;
        }

        private double GetWeightedValue(string stat, int value)
        {
            if (stat == null)
            {
                return 0;
            }

            double weightedValue = Info.StatWeights[stat] * value;
            return weightedValue;
        }

        private double GetStarsWeight()
        {
            if (Slot % 2 == 1 || PrimaryName == "SPD")
            {
                return 1 - ((6 - Stars) * .05);
            }
            else
            {
                return 1 - ((6 - Stars) * .1);
            }
        }

        public void Print()
        {
            try
            {
                Console.WriteLine("{0,8}{1,10}{2,7}{3,6}{4,7}{5,10}{6,10}{7,10}{8,10}{9,10}{10,10}{11,10}",
                    Equipped,
                    Set,
                    Stars,
                    Slot,
                    Level,
                    $"{PrimaryValue} {PrimaryName}",
                    $"{SecondaryValue} {SecondaryName}",
                    $"{Stat1Value} {Stat1Name}",
                    $"{Stat2Value} {Stat2Name}",
                    $"{Stat3Value} {Stat3Name}",
                    $"{Stat4Value} {Stat4Name}",
                    Rating
                    );
            }
            catch { }
        }
    }
}
