using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace KeepScore
{
    internal class Team
    {
        [JsonInclude]
        public string name;
        [JsonInclude]
        public List<Bowler> bowlers;
        public TextBox teamTotal = new TextBox();
        public TextBox teamTotalHDCP = new TextBox();
        public TextBox teamStringTotal = new TextBox();
        public TextBox teamStringTotalHDCP = new TextBox();
        [JsonInclude]
        public int teamNumber = 0;
        public Boolean scoreCorrect = false;
        [JsonInclude]
        public String printSummary = "None";

        [JsonConstructor]
        public Team(string name, List<Bowler> bowlers, int teamNumber, String printSummary) =>
            (this.name, this.bowlers, this.teamNumber, this.printSummary) = (name, bowlers, teamNumber, printSummary);

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
            //set default values
            this.name = name;
            this.bowlers = new List<Bowler>();
            this.teamTotal.Text = "0";

            //iterate through all the bowlers entered and create them for this team
            for (int x = 0; x < bowlers.Count; x++)
            {
                this.bowlers.Add(new Bowler(bowlers[x], numStrings));
            }
        }

        public void Team_CalcTotal(object sender, EventArgs e)
        {
            int temp_teamTotal = 0;
            int temp_teamTotalHDCP = 0;

            //iterate through all the bowlers match totals to get the team's total.
            for (int i = 0; i < bowlers.Count; i++)
            {
                if (this.bowlers[i].matchTotal.Text != "")
                {
                    temp_teamTotal += int.Parse(this.bowlers[i].matchTotal.Text);
                    temp_teamTotalHDCP += int.Parse(this.bowlers[i].matchTotalHDCP.Text);
                }
            }

            this.teamTotal.Text = temp_teamTotal.ToString();
            this.teamTotalHDCP.Text = temp_teamTotalHDCP.ToString();
        }

        public void Team_NextBowlersTurn(object sender, EventArgs e, int boxIndex, int bowlerIndex, int currentString, int boxesPerTurn)
        {
            int boxesToMove = 0;
            Boolean isDoubleStrike = false;

            //if boxes per turn is zero or we are in score correct mode or the event has been handled, then skip all this
            if (boxesPerTurn > 0 && (!this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].scoreCorrectMode) && !this.bowlers[bowlerIndex].strings[currentString].eventHandled && this.bowlers.Count() > 1)
            {
                //if this box is a mark and the next box is a mark, check to see if the next box would trigger the end of a turn.
                if ((boxIndex < 9) && boxesPerTurn > 1 &&
                     (this.bowlers[bowlerIndex].strings[currentString].game[boxIndex + 1].isSpare || this.bowlers[bowlerIndex].strings[currentString].game[boxIndex + 1].isStrike) &&
                     ((boxIndex + 2) % boxesPerTurn == 0)
                   )
                {
                    boxIndex++;
                    //if the next box is a strike and the last box was a strike then it's a double
                    if (this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].isStrike && this.bowlers[bowlerIndex].strings[currentString].game[boxIndex - 1].isStrike)
                    {
                        isDoubleStrike = true;
                    }
                }
                //special case for triple strike and end of turn
                else if (boxIndex < 8 && boxesPerTurn > 0 && !scoreCorrect && !this.bowlers[bowlerIndex].strings[currentString].eventHandled
                        && (this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].isStrike)
                        && (this.bowlers[bowlerIndex].strings[currentString].game[boxIndex + 1].isStrike)
                        && (this.bowlers[bowlerIndex].strings[currentString].game[boxIndex + 2].isStrike)
                        && ((boxIndex + 3) % boxesPerTurn == 0))
                {
                    boxIndex = boxIndex + 2;
                    isDoubleStrike = true;
                }

                //if this is the last box of this bowler's turn and it's a mark (strike or spare) and there's no load
                //  or this is the last box of the bowler's turn and it's not a mark (strike or spare)
                if ((((boxIndex + 1) % boxesPerTurn == 0) &&
                        ((this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].isSpare) || (this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].isStrike)) &&
                        (this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].DisplayBox.Text == "")) ||
                        (((boxIndex + 1) % boxesPerTurn == 0) &&
                        ((!this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].isSpare) && (!this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].isStrike)))
                )
                {
                    //is this the last box of the string?
                    if (boxIndex == 9)
                    {
                        //are they on a spare or strike?
                        if ((this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].isSpare || this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].isStrike) &&
                            this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].DisplayBox.Text != "")
                        {
                            if (bowlerIndex + 1 < this.bowlers.Count)
                            {
                                boxesToMove = Team_calcNumBoxesToMoveTo(boxIndex, bowlerIndex, currentString, boxesPerTurn);

                                if (!this.bowlers[bowlerIndex + 1].strings[currentString].game[(boxIndex + 1) - boxesToMove].isSpare &&
                                     !this.bowlers[bowlerIndex + 1].strings[currentString].game[(boxIndex + 1) - boxesToMove].isStrike &&
                                     this.bowlers[bowlerIndex + 1].strings[currentString].game[(boxIndex + 1) - boxesToMove].DisplayBox.Text == ""
                                   )
                                {
                                    this.bowlers[bowlerIndex + 1].strings[currentString].game[(boxIndex + 1) - boxesToMove].DisplayBox.Focus();
                                }
                            }
                        }
                        else
                        {
                            //if they aren't on a spare or strike
                            if (!this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].isSpare && !this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].isStrike)
                            {
                                //is this the last bowler on the team?
                                if (bowlerIndex + 1 < this.bowlers.Count)
                                {
                                    this.bowlers[bowlerIndex + 1].strings[currentString].game[(boxIndex + 1) - Team_calcNumBoxesToMoveTo(boxIndex, bowlerIndex, currentString, boxesPerTurn)].DisplayBox.Focus();
                                }
                                else
                                {
                                    Form form1 = Application.OpenForms["MatchForm"];
                                    foreach (Control control in form1.Controls)
                                    {
                                        foreach (Control control1 in control.Controls)
                                        {
                                            if (control1.GetType() == typeof(Button))
                                            {
                                                Button button = control1 as Button;
                                                if (button.Name == "NextStringBtn")
                                                {
                                                    button.Focus();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //is this the last bowler on the team?
                        //if not advance to next bowler
                        if (bowlerIndex + 1 < this.bowlers.Count)
                        {
                            //is this the end of this bowlers first turn?
                            if ((boxIndex + 1) - boxesPerTurn != 0)
                            {
                                boxesToMove = Team_calcNumBoxesToMoveTo(boxIndex, bowlerIndex, currentString, boxesPerTurn);

                                if (this.bowlers[bowlerIndex + 1].strings[currentString].game[(boxIndex + 1) - boxesToMove].boxTotal == 0)
                                {
                                    this.bowlers[bowlerIndex + 1].strings[currentString].game[(boxIndex + 1) - boxesToMove].DisplayBox.Focus();
                                }
                            }
                            else
                            {
                                //is this a triple strike?
                                if (isDoubleStrike && this.bowlers[bowlerIndex].strings[currentString].game[boxIndex - 1].isStrike
                                    && this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].isStrike && (boxIndex + 1) % boxesPerTurn == 0)
                                {
                                    //if the box we are supposed to be moving too already has a value in it, then are are starting the next turn, not finishing a turn
                                    if (this.bowlers[bowlerIndex + 1].strings[currentString].game[(boxIndex + 1) - boxesPerTurn].boxTotal == 0)
                                    {
                                        this.bowlers[bowlerIndex + 1].strings[currentString].game[(boxIndex + 1) - boxesPerTurn].DisplayBox.Focus();
                                    }
                                }
                                else if (isDoubleStrike && this.bowlers[bowlerIndex].strings[currentString].game[boxIndex - 1].DisplayBox.Text != "")
                                {
                                    this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].DisplayBox.Focus();
                                }
                                else
                                {
                                    this.bowlers[bowlerIndex + 1].strings[currentString].game[(boxIndex + 1) - boxesPerTurn].DisplayBox.Focus();
                                }
                            }
                        }
                        //if it is the last bowler we need to see if the first bowler was on a mark
                        else
                        {
                            //if it's a spare, put the focus on the same box we ended on
                            if (this.bowlers[0].strings[currentString].game[boxIndex].isSpare)
                            {
                                this.bowlers[0].strings[currentString].game[(boxIndex)].DisplayBox.Focus();
                            }
                            //if it's a strike, we need to know of the box before that was also a strike
                            else if (this.bowlers[0].strings[currentString].game[boxIndex].isStrike)
                            {
                                if (boxIndex - 1 > -1 && this.bowlers[0].strings[currentString].game[boxIndex - 1].isStrike)
                                {
                                    this.bowlers[0].strings[currentString].game[(boxIndex - 1)].DisplayBox.Focus();
                                }
                                else
                                {
                                    this.bowlers[0].strings[currentString].game[boxIndex].DisplayBox.Focus();
                                }
                            }
                            else
                            {
                                this.bowlers[0].strings[currentString].game[(boxIndex + 1)].DisplayBox.Focus();
                            }
                        }
                    }
                }
                //fail safe, if there is text in the box and this is the last box, we need to move onto the next bowler.
                else if (boxIndex == 9 && this.bowlers[bowlerIndex].strings[currentString].game[boxIndex].DisplayBox.Text != "")
                {
                    this.bowlers[bowlerIndex + 1].strings[currentString].game[(boxIndex + 1) - Team_calcNumBoxesToMoveTo(boxIndex, bowlerIndex, currentString, boxesPerTurn)].DisplayBox.Focus();
                }
            }
            //we only have one bowler
            else
            {
                //see if this is the last box
                if (boxIndex == 9 && this.bowlers[0].strings[currentString].game[boxIndex].boxTotal > 0 && this.bowlers[0].strings[currentString].game[boxIndex].DisplayBox.Text != "")
                {
                    Form form1 = Application.OpenForms["MatchForm"];
                    foreach (Control control in form1.Controls)
                    {
                        foreach (Control control1 in control.Controls)
                        {
                            if (control1.GetType() == typeof(Button))
                            {
                                Button button = control1 as Button;
                                if (button.Name == "NextStringBtn")
                                {
                                    button.BackColor = Color.Yellow;
                                    button.Focus();
                                }
                            }
                        }
                    }
                }
            }
        }

        private int Team_calcNumBoxesToMoveTo( int boxIndex, int bowlerIndex, int currentString, int boxesPerTurn)
        {
            int numBoxes = 0;

            if (this.bowlers[bowlerIndex + 1].strings[currentString].game[((boxIndex + 1) - boxesPerTurn) - 1].isSpare)
                {
                    numBoxes = boxesPerTurn + 1;
                }
            else if (this.bowlers[bowlerIndex + 1].strings[currentString].game[((boxIndex + 1) - boxesPerTurn) - 1].isStrike) {
                //is this a double strike
                if (boxIndex > 1 && this.bowlers[bowlerIndex + 1].strings[currentString].game[((boxIndex + 1) - boxesPerTurn) - 2].isStrike)
                {
                    numBoxes = boxesPerTurn + 2;
                }
                else
                {
                    numBoxes = boxesPerTurn + 1;
                }
            }
            else
            {
                numBoxes = boxesPerTurn;
            }

            return numBoxes;
        }

        public void handleArrowsToNav(object sender, KeyEventArgs e, int in_boxIndex, int in_bowlerIndex, int in_currentString)
        {
            if (in_bowlerIndex == this.bowlers.Count - 1 && e.KeyCode == Keys.Down)
            {
                this.bowlers[0].strings[in_currentString].game[in_boxIndex].DisplayBox.Focus();
            }
            else if (in_bowlerIndex == 0 && e.KeyCode == Keys.Up)
            {
                this.bowlers[this.bowlers.Count -1].strings[in_currentString].game[in_boxIndex].DisplayBox.Focus();
            }
            else if (in_boxIndex == 9 && e.KeyCode == Keys.Right)
            {
                this.bowlers[in_bowlerIndex].strings[in_currentString].game[0].DisplayBox.Focus();
            }
            else if (in_boxIndex == 0 && e.KeyCode == Keys.Left)
            {
                this.bowlers[in_bowlerIndex].strings[in_currentString].game[9].DisplayBox.Focus();
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Left: this.bowlers[in_bowlerIndex].strings[in_currentString].game[in_boxIndex - 1].DisplayBox.Focus();
                        break;
                    case Keys.Right: this.bowlers[in_bowlerIndex].strings[in_currentString].game[in_boxIndex + 1].DisplayBox.Focus();
                        break;
                    case Keys.Up: this.bowlers[in_bowlerIndex -1].strings[in_currentString].game[in_boxIndex].DisplayBox.Focus();
                        break;
                    case Keys.Down: this.bowlers[in_bowlerIndex + 1].strings[in_currentString].game[in_boxIndex].DisplayBox.Focus();
                        break;
                }
            }


        }

        public void saveTeamStats(object sender, EventArgs e)
        {
            String team_json = null;
            String stringPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "KeepScore");
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

            team_json = JsonSerializer.Serialize(this, options);

            if (!Directory.Exists(stringPath))
            {
                System.IO.Directory.CreateDirectory(stringPath);
            }

            stringPath = Path.Combine(stringPath, "Inprogress.json");
            File.WriteAllText(stringPath, team_json);
        }
    }
}
