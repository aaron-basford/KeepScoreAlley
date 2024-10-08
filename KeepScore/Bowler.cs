﻿using System.Text.Json.Serialization;

namespace KeepScore
{
    internal class Bowler
    {
        [JsonInclude]
        public string name;
        [JsonInclude]
        public List<BowlingString> strings = new List<BowlingString>();
        [JsonInclude]
        public int int_handicap = 0;

        public TextBox matchTotal = new TextBox();
        public TextBox handicap = new TextBox();
        public TextBox matchTotalHDCP = new TextBox();

        [JsonConstructor]
        public Bowler(string name, List<BowlingString> strings, int int_handicap) =>
            (this.name, this.strings, this.int_handicap) = (name, strings, int_handicap);

        public Bowler(string in_name, int numStrings)
        {
            this.name = in_name;

            //Create all the strings for this bowler and add them to the list.
            for (int i = 0; i < numStrings; i++)
            {
                this.strings.Add(new BowlingString());
            }

            //set the display info for this bowlers match total (the total of all their strings)
            matchTotal.Size = new Size(100, 50);
            matchTotal.TextAlign = HorizontalAlignment.Center;
            matchTotal.Text = "0";
            matchTotal.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);

            matchTotalHDCP.Size = new Size(100, 50);
            matchTotalHDCP.TextAlign = HorizontalAlignment.Center;
            matchTotalHDCP.Text = "0";
            matchTotalHDCP.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);


            handicap.Size = new Size(100, 50);
            handicap.TextAlign = HorizontalAlignment.Center;
            handicap.Text = "0";
            handicap.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
        }

        public void calcBowlerMatchTotal(object sender, EventArgs e)
        {
            int bowlerMatchTotal = 0;
            int bowlerMatchTotalHdcp = 0;

            //iterate through all the strings to get this bowlers match total
            for (int i = 0; i < strings.Count; i++)
            {
                if (strings[i].stringTotal.Text != "")
                {
                    bowlerMatchTotal += int.Parse(strings[i].stringTotal.Text);
                    bowlerMatchTotalHdcp += int.Parse(strings[i].totalHDCP.Text);
                }
            }

            matchTotal.Text = bowlerMatchTotal.ToString();

            matchTotalHDCP.Text = bowlerMatchTotalHdcp.ToString();
        }
    }
}
