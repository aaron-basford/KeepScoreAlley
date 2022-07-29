namespace KeepScore
{
    internal class Bowler
    {
        public string name;
        public List<BowlingString> strings = new List<BowlingString>();
        public TextBox matchTotal = new TextBox();

        public Bowler(string in_name, int numStrings)
        {
            this.name = in_name;

            //Create all the strings for this bowler and add them to the list.
            for (int i = 0; i < numStrings; i++)
            {
                this.strings.Add(new BowlingString());
            }

            //set the display info for this bowlers match total (the total of all their strings)
            matchTotal.Size = new Size(40, 35);
            matchTotal.TextAlign = HorizontalAlignment.Center;
            matchTotal.Text = "0";
            matchTotal.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
        }

        public void calcBowlerMatchTotal(object sender, EventArgs e)
        {
            int bowlerMatchTotal = 0;

            //iterate through all the strings to get this bowlers match total
            for (int i = 0; i < strings.Count; i++)
            {
                bowlerMatchTotal += int.Parse(strings[i].stringTotal.Text);
            }

            matchTotal.Text = bowlerMatchTotal.ToString();
        }
    }
}
