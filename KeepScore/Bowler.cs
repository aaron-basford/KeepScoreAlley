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

            for (int i = 0; i < numStrings; i++)
            {
                this.strings.Add(new BowlingString());
            }

            matchTotal.Size = new Size(40, 35);
            matchTotal.TextAlign = HorizontalAlignment.Center;
            matchTotal.Text = "0";
            matchTotal.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
        }

        public void calcBowlerMatchTotal(object sender, EventArgs e)
        {
            int bowlerMatchTotal = 0;

            for (int i = 0; i < strings.Count; i++)
            {
                bowlerMatchTotal += int.Parse(strings[i].stringTotal.Text);
            }

            matchTotal.Text = bowlerMatchTotal.ToString();
        }
    }
}
