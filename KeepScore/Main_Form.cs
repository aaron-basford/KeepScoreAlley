namespace KeepScore
{
    using System.Collections.Generic;

    public partial class Main_Form : Form
    {
        private Team firstTeam;
        private Control teamOne = new Control();
        private Team secondTeam;
        private Control teamTwo = new Control();
        private Team thirdTeam;
        private Control teamThree = new Control();
        private Team fourthTeam;
        private Control teamFour = new Control();
        private int currentString;

        public Main_Form()
        {
            InitializeComponent();

            //Set up the form.
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new System.Drawing.Size(1300, 400);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;

            firstTeam = new Team();
            secondTeam = new Team();
            thirdTeam = new Team();
            fourthTeam = new Team();

            lblTeam1Bowlers.Hide();
            lblTeam2Bowlers.Hide();
            lblTeam3Bowlers.Hide();
            lblTeam4Bowlers.Hide();

            currentString = 0;

            //Hide the team name fields
            Team1.Enabled = false;
            Team1.Hide();
            lbl_Versus1.Enabled = false;
            lbl_Versus1.Hide();
            Team2.Enabled = false;
            Team2.Hide();
            Team3.Enabled = false;
            Team3.Hide();
            lbl_Versus2.Enabled = false;
            lbl_Versus2.Hide();
            Team4.Enabled = false;
            Team4.Hide();

            //Hide the bowler name fields.
            Team1_Bowler1.Enabled = false;
            Team1_Bowler1.Hide();
            Team1_Bowler2.Enabled = false;
            Team1_Bowler2.Hide();
            Team1_Bowler3.Enabled = false;
            Team1_Bowler3.Hide();
            Team1_Bowler4.Enabled = false;
            Team1_Bowler4.Hide();
            Team1_Bowler5.Enabled = false;
            Team1_Bowler5.Hide();

            Team2_Bowler1.Enabled = false;
            Team2_Bowler1.Hide();
            Team2_Bowler2.Enabled = false;
            Team2_Bowler2.Hide();
            Team2_Bowler3.Enabled = false;
            Team2_Bowler3.Hide();
            Team2_Bowler4.Enabled = false;
            Team2_Bowler4.Hide();
            Team2_Bowler5.Enabled = false;
            Team2_Bowler5.Hide();

            Team3_Bowler1.Enabled = false;
            Team3_Bowler1.Hide();
            Team3_Bowler2.Enabled = false;
            Team3_Bowler2.Hide();
            Team3_Bowler3.Enabled = false;
            Team3_Bowler3.Hide();
            Team3_Bowler4.Enabled = false;
            Team3_Bowler4.Hide();
            Team3_Bowler5.Enabled = false;
            Team3_Bowler5.Hide();

            Team4_Bowler1.Enabled = false;
            Team4_Bowler1.Hide();
            Team4_Bowler2.Enabled = false;
            Team4_Bowler2.Hide();
            Team4_Bowler3.Enabled = false;
            Team4_Bowler3.Hide();
            Team4_Bowler4.Enabled = false;
            Team4_Bowler4.Hide();
            Team4_Bowler5.Enabled = false;
            Team4_Bowler5.Hide();

            //firstString.Show();
        }

        private void NumBowlers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create field to enter bowlers names
            if (NumTeams.SelectedIndex >= 0)
            {
                lblTeam1Bowlers.Show();

                if (NumBowlers.SelectedIndex >= 0)
                {
                    Team1_Bowler1.Enabled = true;
                    Team1_Bowler1.Show();
                }
                else
                {
                    Team1_Bowler1.Enabled = false;
                    Team1_Bowler1.Hide();
                }

                if (NumBowlers.SelectedIndex >= 1)
                {
                    Team1_Bowler2.Enabled = true;
                    Team1_Bowler2.Show();
                }
                else
                {
                    Team1_Bowler2.Enabled = false;
                    Team1_Bowler2.Hide();
                }

                if (NumBowlers.SelectedIndex >= 2)
                {
                    Team1_Bowler3.Enabled = true;
                    Team1_Bowler3.Show();
                }
                else
                {
                    Team1_Bowler3.Enabled = false;
                    Team1_Bowler3.Hide();
                }

                if (NumBowlers.SelectedIndex >= 3)
                {
                    Team1_Bowler4.Enabled = true;
                    Team1_Bowler4.Show();
                }
                else
                {
                    Team1_Bowler4.Enabled = false;
                    Team1_Bowler4.Hide();
                }

                if (NumBowlers.SelectedIndex >= 4)
                {
                    Team1_Bowler5.Enabled = true;
                    Team1_Bowler5.Show();
                }
                else
                {
                    Team1_Bowler5.Enabled = false;
                    Team1_Bowler5.Hide();
                }
            }
            else
            {
                HideAllBowlersByTeam(0);
            }

            if (NumTeams.SelectedIndex > 0)
            {
                lblTeam2Bowlers.Show();

                if (NumBowlers.SelectedIndex >= 0)
                {
                    Team2_Bowler1.Enabled = true;
                    Team2_Bowler1.Show();
                }
                else
                {
                    Team2_Bowler1.Enabled = false;
                    Team2_Bowler1.Hide();
                }

                if (NumBowlers.SelectedIndex >= 1)
                {
                    Team2_Bowler2.Enabled = true;
                    Team2_Bowler2.Show();
                }
                else
                {
                    Team2_Bowler2.Enabled = false;
                    Team2_Bowler2.Hide();
                }

                if (NumBowlers.SelectedIndex >= 2)
                {
                    Team2_Bowler3.Enabled = true;
                    Team2_Bowler3.Show();
                }
                else
                {
                    Team2_Bowler3.Enabled = false;
                    Team2_Bowler3.Hide();
                }

                if (NumBowlers.SelectedIndex >= 3)
                {
                    Team2_Bowler4.Enabled = true;
                    Team2_Bowler4.Show();
                }
                else
                {
                    Team2_Bowler4.Enabled = false;
                    Team2_Bowler4.Hide();
                }

                if (NumBowlers.SelectedIndex >= 4)
                {
                    Team2_Bowler5.Enabled = true;
                    Team2_Bowler5.Show();
                }
                else
                {
                    Team2_Bowler5.Enabled = false;
                    Team2_Bowler5.Hide();
                }
            }
            else
            {
                HideAllBowlersByTeam(1);
            }

            if (NumTeams.SelectedIndex > 1)
            {
                lblTeam3Bowlers.Show();

                if (NumBowlers.SelectedIndex >= 0)
                {
                    Team3_Bowler1.Enabled = true;
                    Team3_Bowler1.Show();
                }
                else
                {
                    Team3_Bowler1.Enabled = false;
                    Team3_Bowler1.Hide();
                }

                if (NumBowlers.SelectedIndex >= 1)
                {
                    Team3_Bowler2.Enabled = true;
                    Team3_Bowler2.Show();
                }
                else
                {
                    Team3_Bowler2.Enabled = false;
                    Team3_Bowler2.Hide();
                }

                if (NumBowlers.SelectedIndex >= 2)
                {
                    Team3_Bowler3.Enabled = true;
                    Team3_Bowler3.Show();
                }
                else
                {
                    Team3_Bowler3.Enabled = false;
                    Team3_Bowler3.Hide();
                }

                if (NumBowlers.SelectedIndex >= 3)
                {
                    Team3_Bowler4.Enabled = true;
                    Team3_Bowler4.Show();
                }
                else
                {
                    Team3_Bowler4.Enabled = false;
                    Team3_Bowler4.Hide();
                }

                if (NumBowlers.SelectedIndex >= 4)
                {
                    Team3_Bowler5.Enabled = true;
                    Team3_Bowler5.Show();
                }
                else
                {
                    Team3_Bowler5.Enabled = false;
                    Team3_Bowler5.Hide();
                }
            }
            else
            {
                HideAllBowlersByTeam(2);
            }

            if (NumTeams.SelectedIndex == 3)
            {
                lblTeam4Bowlers.Show();

                if (NumBowlers.SelectedIndex >= 0)
                {
                    Team4_Bowler1.Enabled = true;
                    Team4_Bowler1.Show();
                }
                else
                {
                    Team4_Bowler1.Enabled = false;
                    Team4_Bowler1.Hide();
                }

                if (NumBowlers.SelectedIndex >= 1)
                {
                    Team4_Bowler2.Enabled = true;
                    Team4_Bowler2.Show();
                }
                else
                {
                    Team4_Bowler2.Enabled = false;
                    Team4_Bowler2.Hide();
                }

                if (NumBowlers.SelectedIndex >= 2)
                {
                    Team4_Bowler3.Enabled = true;
                    Team4_Bowler3.Show();
                }
                else
                {
                    Team4_Bowler3.Enabled = false;
                    Team4_Bowler3.Hide();
                }

                if (NumBowlers.SelectedIndex >= 3)
                {
                    Team4_Bowler4.Enabled = true;
                    Team4_Bowler4.Show();
                }
                else
                {
                    Team4_Bowler4.Enabled = false;
                    Team4_Bowler4.Hide();
                }

                if (NumBowlers.SelectedIndex >= 4)
                {
                    Team4_Bowler5.Enabled = true;
                    Team4_Bowler5.Show();
                }
                else
                {
                    Team4_Bowler5.Enabled = false;
                    Team4_Bowler5.Hide();
                }
            }
            else
            {
                HideAllBowlersByTeam(3);
            }
        }

        private void NumTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Show/Hide fields to enter team names
            switch (NumTeams.SelectedIndex)
            {
                case 0:
                    Team1.Enabled = true;
                    Team1.Show();
                    lbl_Versus1.Enabled = false;
                    lbl_Versus1.Hide();
                    Team2.ResetText();
                    Team2.Enabled = false;
                    Team2.Hide();
                    Team3.ResetText();
                    Team3.Enabled = false;
                    Team3.Hide();
                    lbl_Versus2.Enabled = false;
                    lbl_Versus2.Hide();
                    Team4.ResetText();
                    Team4.Enabled = false;
                    Team4.Hide();
                    break;
                case 1:
                    Team1.Enabled = true;
                    Team1.Show();
                    lbl_Versus1.Enabled = true;
                    lbl_Versus1.Show();
                    Team2.Enabled = true;
                    Team2.Show();
                    Team3.ResetText();
                    Team3.Enabled = false;
                    Team3.Hide();
                    lbl_Versus2.Enabled = false;
                    lbl_Versus2.Hide();
                    Team4.ResetText();
                    Team4.Enabled = false;
                    Team4.Hide();
                    break;
                case 2:
                    Team1.Enabled = true;
                    Team1.Show();
                    lbl_Versus1.Enabled = true;
                    lbl_Versus2.Show();
                    Team2.Enabled = true;
                    Team2.Show();
                    Team3.ResetText();
                    Team3.Enabled = false;
                    Team3.Hide();
                    lbl_Versus2.Enabled = true;
                    lbl_Versus2.Show();
                    Team4.Enabled = true;
                    Team4.Show();
                    break;
                case 3:
                    Team1.Enabled = true;
                    Team1.Show();
                    lbl_Versus1.Enabled = true;
                    lbl_Versus1.Show();
                    Team2.Enabled = true;
                    Team2.Show();
                    Team3.Enabled = true;
                    Team3.Show();
                    lbl_Versus2.Enabled = true;
                    lbl_Versus2.Show();
                    Team4.Enabled = true;
                    Team4.Show();
                    break;
                default:
                    Team1.ResetText();
                    Team1.Enabled = false;
                    Team1.Hide();
                    lbl_Versus1.Enabled = false;
                    lbl_Versus1.Hide();
                    Team2.ResetText();
                    Team2.Enabled = false;
                    Team2.Hide();
                    Team3.ResetText();
                    Team3.Enabled = false;
                    Team3.Hide();
                    lbl_Versus2.Enabled = false;
                    lbl_Versus2.Hide();
                    Team4.ResetText();
                    Team4.Enabled = false;
                    Team4.Hide();
                    break;
            }

            NumBowlers_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void HideAllBowlersByTeam(int in_SelectedIndex)
        {
            switch (in_SelectedIndex)
            {
                case 0:
                    Team1_Bowler1.Enabled = false;
                    Team1_Bowler1.Hide();
                    Team1_Bowler2.Enabled = false;
                    Team1_Bowler2.Hide();
                    Team1_Bowler3.Enabled = false;
                    Team1_Bowler3.Hide();
                    Team1_Bowler4.Enabled = false;
                    Team1_Bowler4.Hide();
                    Team1_Bowler5.Enabled = false;
                    Team1_Bowler5.Hide();
                    lblTeam1Bowlers.Hide();
                    break;
                case 1:
                    Team2_Bowler1.Enabled = false;
                    Team2_Bowler1.Hide();
                    Team2_Bowler2.Enabled = false;
                    Team2_Bowler2.Hide();
                    Team2_Bowler3.Enabled = false;
                    Team2_Bowler3.Hide();
                    Team2_Bowler4.Enabled = false;
                    Team2_Bowler4.Hide();
                    Team2_Bowler5.Enabled = false;
                    Team2_Bowler5.Hide();
                    lblTeam2Bowlers.Hide();
                    break;
                case 2:
                    Team3_Bowler1.Enabled = false;
                    Team3_Bowler1.Hide();
                    Team3_Bowler2.Enabled = false;
                    Team3_Bowler2.Hide();
                    Team3_Bowler3.Enabled = false;
                    Team3_Bowler3.Hide();
                    Team3_Bowler4.Enabled = false;
                    Team3_Bowler4.Hide();
                    Team3_Bowler5.Enabled = false;
                    Team3_Bowler5.Hide();
                    lblTeam3Bowlers.Hide();
                    break;
                case 3:
                    Team4_Bowler1.Enabled = false;
                    Team4_Bowler1.Hide();
                    Team4_Bowler2.Enabled = false;
                    Team4_Bowler2.Hide();
                    Team4_Bowler3.Enabled = false;
                    Team4_Bowler3.Hide();
                    Team4_Bowler4.Enabled = false;
                    Team4_Bowler4.Hide();
                    Team4_Bowler5.Enabled = false;
                    Team4_Bowler5.Hide();
                    lblTeam4Bowlers.Hide();
                    break;
            }
        }

        private void CreateButton_OnClick(object sender, EventArgs e)
        {
            string errMsg = "";
            List<string> bowlersNames = new List<string>();

            errMsg = validateMatchData();

            if (errMsg == "")
            {
                if (NumTeams.SelectedIndex >= 0)
                {
                    bowlersNames.Clear();

                    bowlersNames = populateBowlers(1);

                    if (bowlersNames.Count > 0)
                    {
                        firstTeam = new Team(Team1.Text, bowlersNames, NumStrings.SelectedIndex + 1);
                    }
                }

                if (NumTeams.SelectedIndex >= 1)
                {
                    bowlersNames.Clear();

                    bowlersNames = populateBowlers(2);

                    if (bowlersNames.Count > 0)
                    {
                        secondTeam = new Team(Team2.Text, bowlersNames, NumStrings.SelectedIndex + 1);
                    }
                }

                if (NumTeams.SelectedIndex >= 2)
                {
                    bowlersNames.Clear();

                    bowlersNames = populateBowlers(3);

                    if (bowlersNames.Count > 0)
                    {
                        if (NumTeams.SelectedIndex == 2)
                        {
                            thirdTeam = new Team(Team4.Text, bowlersNames, NumStrings.SelectedIndex + 1);
                        }
                        else
                        {
                            thirdTeam = new Team(Team3.Text, bowlersNames, NumStrings.SelectedIndex + 1);
                        }
                    }
                }

                if (NumTeams.SelectedIndex == 3)
                {
                    bowlersNames.Clear();

                    bowlersNames = populateBowlers(4);

                    if (bowlersNames.Count > 0)
                    {
                        fourthTeam = new Team(Team4.Text, bowlersNames, NumStrings.SelectedIndex + 1);
                    }
                }

                CreateMatchForm();
            }
            else
            {
                MessageBox.Show(errMsg, "Match Setup Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string validateMatchData()
        {
            string errMsg = "";
            string bowlerErrMsg = "";
            List<string> bowlersNames = new List<string>();
            TextBox tempTextBox = new TextBox();
            string controlName = "";

            if (NumTeams.SelectedIndex == -1)
            {
                errMsg += "Please select the number of teams in this match.\n";
            }

            if (NumBowlers.SelectedIndex == -1)
            {
                errMsg += "Please select the number of bowlers per team in this match.\n";
            }

            if (NumStrings.SelectedIndex == -1)
            {
                errMsg += "Please select the number of strings for this match.\n";
            }

            if (MatchTitle.Text == "")
            {
                errMsg += "Please enter a title for this match.\n";
            }

            for (int x = 1; x < 5; x++)
            {
                bowlerErrMsg = "";

                for (int y = 1; y < 6; y++)
                {
                    controlName = "Team" + x + "_Bowler" + y;
                    tempTextBox = (TextBox)this.Controls.Find(controlName, true)[0];

                    if (tempTextBox.Enabled)
                    {
                        if (tempTextBox.Text == "")
                        {
                            bowlerErrMsg = "Please enter all the bowler's names for team " + x + ".\n";
                        }
                    }
                }

                errMsg += bowlerErrMsg;
            }

            return errMsg;
        }

        private List<string> populateBowlers(int teamNum)
        {
            List<string> bowlers = new List<string>();
            TextBox tempTextBox = new TextBox();
            string controlName = "";

            for (int x = 1; x < 6; x++)
            {
                controlName = "Team" + teamNum + "_Bowler" + x;
                tempTextBox = (TextBox)this.Controls.Find(controlName, true)[0];

                if (tempTextBox.Enabled)
                {
                    bowlers.Add(tempTextBox.Text);
                }
            }

            return bowlers;
        }

        private void CreateMatchForm()
        {
            Match match = new Match();

            if (firstTeam.bowlers.Count > 0)
            {
                this.teamOne.Size = new Size(1200, 100 + (16 * firstTeam.bowlers.Count));
                this.teamOne.Location = new Point(20, 20);
                this.teamOne.BackColor = Color.Red;
                displayTeam(teamOne, firstTeam);
                match.Controls.Add(teamOne);
            }

            if (secondTeam.bowlers.Count > 0)
            {
                this.teamTwo.Size = new Size(1200, 100 + (16 * secondTeam.bowlers.Count));
                this.teamTwo.Location = new Point(20, 125 + (16 * firstTeam.bowlers.Count));
                this.teamTwo.BackColor = Color.Blue;
                displayTeam(teamTwo, secondTeam);
                match.Controls.Add(teamTwo);
            }

            if (thirdTeam.bowlers.Count > 0)
            {
                this.teamThree.Size = new Size(1200, 100 + (16 * thirdTeam.bowlers.Count));
                this.teamThree.Location = new Point(20, 263 + (16 * secondTeam.bowlers.Count));
                this.teamThree.BackColor = Color.Green;
                displayTeam(teamThree, thirdTeam);
                match.Controls.Add(teamThree);
            }

            if (fourthTeam.bowlers.Count > 0)
            {
                this.teamFour.Size = new Size(1200, 100 + (16 * fourthTeam.bowlers.Count));
                this.teamFour.Location = new Point(20, 400 + (16 * thirdTeam.bowlers.Count));
                this.teamFour.BackColor = Color.Purple;
                displayTeam(teamFour, fourthTeam);
                match.Controls.Add(teamFour);
            }

            match.Text = this.MatchTitle.Text;

            match.Show();

            foreach (Control c in this.Controls)
            {
                if (c.Name != "NextString")
                {
                    c.Enabled = false;
                }
            }
        }

        private void displayTeam(Control teamArea, Team team)
        {
            int bowlerCount = 0;

            if (currentString == 0)
            {
                Label teamName = new Label();
                teamName.Text = team.name.ToUpper();
                teamName.Location = new Point(10, 10);
                teamName.Size = new Size(300, 40);
                teamName.TextAlign = ContentAlignment.MiddleCenter;
                teamName.Enabled = false;
                teamName.Font = new Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold);
                teamArea.Controls.Add(teamName);

                Label stringTotalLabel = new Label();
                stringTotalLabel.Size = new Size(50, 20);
                stringTotalLabel.Location = new Point(598, 20);
                stringTotalLabel.Text = "Total";
                stringTotalLabel.TextAlign = ContentAlignment.MiddleLeft;
                stringTotalLabel.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                teamArea.Controls.Add(stringTotalLabel);

                Label prevStringsLabel = new Label();
                prevStringsLabel.Size = new Size(130, 20);
                prevStringsLabel.Location = new Point(750, 20);
                prevStringsLabel.Text = "Previous Strings";
                prevStringsLabel.TextAlign = ContentAlignment.MiddleCenter;
                prevStringsLabel.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                teamArea.Controls.Add(prevStringsLabel);

                Label bowlerTotalLabel = new Label();
                bowlerTotalLabel.Size = new Size(55, 20);
                bowlerTotalLabel.Location = new Point(1025, 20);
                bowlerTotalLabel.Text = "Match Total";
                bowlerTotalLabel.TextAlign = ContentAlignment.MiddleLeft;
                bowlerTotalLabel.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                teamArea.Controls.Add(bowlerTotalLabel);

                if (team.bowlers.Count > 1)
                {
                    Label teamTotalLabel = new Label();
                    if (team.bowlers.Count == 2)
                    {
                        teamTotalLabel.Size = new Size(100, 30);
                    }
                    else
                    {
                        teamTotalLabel.Size = new Size(100, 30 + (2 * team.bowlers.Count));
                    }
                    teamTotalLabel.Font = new Font(FontFamily.GenericSansSerif, (10 + (2 * (team.bowlers.Count * 0.62F))), FontStyle.Bold, GraphicsUnit.Pixel);
                    teamTotalLabel.Location = new Point(1070, 20 + (2 * team.bowlers.Count));
                    teamTotalLabel.Text = "Team Total";
                    teamTotalLabel.TextAlign = ContentAlignment.MiddleCenter;
                    teamArea.Controls.Add(teamTotalLabel);
                }
            }

            foreach (Bowler teamBowler in team.bowlers)
            {
                bowlerCount++;

                Label bowlerName = new Label();
                bowlerName.Text = teamBowler.name.ToUpper();

                if (bowlerCount == 1)
                {
                    bowlerName.Location = new Point(0, 50);
                }
                else
                {
                    bowlerName.Location = new Point(0, (25 + (25 * bowlerCount)));
                }

                bowlerName.Size = new Size(125, 25);
                bowlerName.TextAlign = ContentAlignment.MiddleCenter;
                bowlerName.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
                bowlerName.AutoSize = false;

                bowlerName.Enabled = false;

                teamArea.Controls.Add(bowlerName);

                teamBowler.matchTotal.Location = new Point(1030, (25 + (25 * bowlerCount)));
                teamBowler.matchTotal.LostFocus += new System.EventHandler(teamBowler.calcBowlerMatchTotal);

                teamArea.Controls.Add(teamBowler.matchTotal);

                if (team.bowlers.Count > 1)
                {
                    team.teamTotal.Size = new Size((40 + (10 * bowlerCount)), (35 + (5 * bowlerCount)));
                    team.teamTotal.TextAlign = HorizontalAlignment.Center;
                    team.teamTotal.Font = new Font(FontFamily.GenericSansSerif, (10 + (5 * bowlerCount)), FontStyle.Bold, GraphicsUnit.Pixel);
                    team.teamTotal.Location = new Point(1110 - (7 * bowlerCount), (25 + (13 * bowlerCount)));
                    team.teamTotal.LostFocus += new System.EventHandler(team.Team_CalcTotal);
                    teamArea.Controls.Add(team.teamTotal);
                }

            }

            //add the strings for all the bowlers on team to the team area
            showNextString(teamArea, team);
        }

        private void NextString_OnClick(object sender, EventArgs e)
        {
            if ((currentString) < NumStrings.SelectedIndex)
            {
                currentString++;

                if (firstTeam.bowlers.Count > 0)
                {
                    hidePreviousString(firstTeam);

                    showNextString(teamOne, firstTeam);
                }

                if (secondTeam.bowlers.Count > 0)
                {
                    hidePreviousString(secondTeam);

                    showNextString(teamTwo, secondTeam);
                }

                if (thirdTeam.bowlers.Count > 0)
                {
                    hidePreviousString(thirdTeam);

                    showNextString(teamThree, thirdTeam);
                }

                if (fourthTeam.bowlers.Count > 0)
                {
                    hidePreviousString(fourthTeam);

                    showNextString(teamFour, fourthTeam);
                }
            }
            else
            {
                MessageBox.Show("There are no more strings to bowl.", "Match Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hidePreviousString(Team in_team)
        {
            for (int i = 0; i < in_team.bowlers.Count; i++)
            {
                for (int y = 0; y < in_team.bowlers[i].strings[currentString - 1].game.Count; y++)
                {
                    in_team.bowlers[i].strings[currentString - 1].game[y].Hide();
                }

                in_team.bowlers[i].strings[currentString - 1].stringTotal.Location = new Point(620 + (40 * currentString), (49 + (25 * i + 1)));
            }
        }

        private void showNextString(Control in_control, Team in_team)
        {
            for (int i = 0; i < in_team.bowlers.Count; i++)
            {
                int bowlerIndex = i;

                for (int x = 0; x < in_team.bowlers[i].strings[currentString].game.Count; x++)
                {
                    int boxIndex = x;
                    in_team.bowlers[i].strings[currentString].game[boxIndex].Location = new Point(150 + (45 * x), (25 + (25 * (i + 1))));
                    in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler((s, e) => in_team.bowlers[bowlerIndex].strings[currentString].String_BoxTextChanged(s, e, in_team.bowlers[bowlerIndex].strings[currentString].game[boxIndex]));
                    in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.bowlers[bowlerIndex].strings[currentString].BowlingString_CalcTotal);
                    in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.bowlers[bowlerIndex].calcBowlerMatchTotal);
                    in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.Team_CalcTotal);

                    //in_team.bowlers[i].strings[currentString].game[x].KeyDown += new System.Windows.Forms.KeyEventHandler((s, e) => in_team.bowlers[bowlerIndex].strings[currentString].String_KeyPress(s, e, in_team.bowlers[bowlerIndex].strings[currentString].game[boxIndex]));
                    //in_team.bowlers[i].strings[currentString].game[x].KeyDown += new System.Windows.Forms.KeyEventHandler(in_team.bowlers[bowlerIndex].strings[currentString].BowlingString_CalcTotal);
                    //in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.bowlers[bowlerIndex].calcBowlerMatchTotal);
                    //in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.Team_CalcTotal);

                    in_control.Controls.Add(in_team.bowlers[i].strings[currentString].game[x]);
                }

                //use offset of 11 since we know that all strings have 10 boxes and this will be after that
                in_team.bowlers[i].strings[currentString].stringTotal.Location = new Point(600, (25 + (25 * (i + 1))));
                in_team.bowlers[i].strings[currentString].stringTotal.Validated += new System.EventHandler(in_team.bowlers[i].strings[currentString].BowlingString_CalcTotal);
                in_control.Controls.Add(in_team.bowlers[i].strings[currentString].stringTotal);
            }
        }

        private void Help_OnClick(object sender, EventArgs e)
        {
            string Message = "*   Select the number of teams bowling in the match. \n";
            Message += "*   The team names are optional, if no team names are needed, the fields can be left blank. \n";
            Message += "*   Select the number of bowlers per team. \n";
            Message += "*   Enter the names of the bowlers, these are required fields. \n";
            Message += "*   Select the number of strings to be bowled in the match. \n";
            Message += "*   Enter a match title, this is a required field. \n";
            Message += "*   When the information is correct, click the Create Match button. This will create the score sheet. \n";
            Message += "*   When done with each string, load the next string's score sheet using the Next String button. ";

            MessageBox.Show(Message, "How to keep score", MessageBoxButtons.OK);
        }
    }
}