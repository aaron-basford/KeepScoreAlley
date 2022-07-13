namespace KeepScore
{
    internal class Team
    {
        public string name;
        public List<Bowler> bowlers;
        public TextBox teamTotal = new TextBox();
        public int teamNumber = 0;

        public Team()
        {
            this.name = "";
            this.bowlers = new List<Bowler>();
            this.teamTotal.Text = "0";
        }
        public Team(string in_name, List<Bowler> bowlers, string teamTotal)
        {
            this.name = in_name;
            this.bowlers = bowlers;
            this.teamTotal.Text = teamTotal;
        }

        public Team(string name, List<string> bowlers, int numStrings)
        {
            this.name = name;
            this.bowlers = new List<Bowler>();
            this.teamTotal.Text = "0";

            for (int x = 0; x < bowlers.Count; x++)
            {
                this.bowlers.Add(new Bowler(bowlers[x], numStrings));
            }
        }

        public void Team_CalcTotal(object sender, EventArgs e)
        {
            int temp_teamTotal = 0;

            for (int i = 0; i < bowlers.Count; i++)
            {
                temp_teamTotal += int.Parse(this.bowlers[i].matchTotal.Text);
            }

            this.teamTotal.Text = temp_teamTotal.ToString();
        }
    }
}
