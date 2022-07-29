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
            //Create field to enter the bowlers names for all the teams
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

        //call back function for when the user chooses a new value from the Number of teams drop down.
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

            //since the number of teams has changed, we need to update which bowlers' names fields are shown
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

        //call back for when the create match button is clicked.
        private void CreateButton_OnClick(object sender, EventArgs e)
        {
            //set default values
            string errMsg = "";
            List<string> bowlersNames = new List<string>();

            //call the validation method
            errMsg = validateMatchData();

            //if there were no errors then create the match form and add the appropriate fields to it
            if (errMsg == "")
            {
                if (NumTeams.SelectedIndex >= 0)
                {
                    bowlersNames.Clear();

                    //get the list of names for team 1
                    bowlersNames = populateBowlers(1);

                    //if the first team has bowlers set up for it, then create the team
                    if (bowlersNames.Count > 0)
                    {
                        firstTeam = new Team(Team1.Text, bowlersNames, NumStrings.SelectedIndex + 1);
                    }
                }

                if (NumTeams.SelectedIndex >= 1)
                {
                    bowlersNames.Clear();

                    //get the list of bowlers for team 2
                    bowlersNames = populateBowlers(2);

                    //if there are bowlers set up for it, then create the team
                    if (bowlersNames.Count > 0)
                    {
                        secondTeam = new Team(Team2.Text, bowlersNames, NumStrings.SelectedIndex + 1);
                    }
                }

                if (NumTeams.SelectedIndex >= 2)
                {
                    bowlersNames.Clear();

                    //get the list of bowlers for team 3
                    bowlersNames = populateBowlers(3);

                    //if there are bowlers set up for it, then create the team
                    if (bowlersNames.Count > 0)
                    {
                        //if the user set up 3 teams then the team name for the third team will come from the team 4 field
                        //and use that to create the team
                        if (NumTeams.SelectedIndex == 2)
                        {
                            thirdTeam = new Team(Team4.Text, bowlersNames, NumStrings.SelectedIndex + 1);
                        }
                        //get the team name from the team 3 field and use that to create the team
                        else
                        {
                            thirdTeam = new Team(Team3.Text, bowlersNames, NumStrings.SelectedIndex + 1);
                        }
                    }
                }

                if (NumTeams.SelectedIndex == 3)
                {
                    bowlersNames.Clear();

                    //get the list of bowlers for team 4
                    bowlersNames = populateBowlers(4);

                    //if there are bowlers set up for it, then create the team
                    if (bowlersNames.Count > 0)
                    {
                        fourthTeam = new Team(Team4.Text, bowlersNames, NumStrings.SelectedIndex + 1);
                    }
                }

                //now that we have all our teams set up, create the match form
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

                //check all the active bowler name fields
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

            //iterate through the active fields of bowler names and add them to the list.
            for (int x = 1; x < 6; x++)
            {
                controlName = "Team" + teamNum + "_Bowler" + x;
                tempTextBox = (TextBox)this.Controls.Find(controlName, true)[0];

                if (tempTextBox.Enabled)
                {
                    bowlers.Add(tempTextBox.Text);
                }
            }

            //return the list of bowler's names
            return bowlers;
        }

        private void CreateMatchForm()
        {
            //create a new match form
            Match match = new Match();

            //if the first team has bowlers then set up the team name label and display the team on the match form we just created
            if (firstTeam.bowlers.Count > 0)
            {
                //depending on the number of bowlers, the size of the fields will change
                this.teamOne.Size = new Size(1200, 100 + (16 * firstTeam.bowlers.Count));
                this.teamOne.Location = new Point(20, 20);
                this.teamOne.BackColor = Color.Red;
                displayTeam(teamOne, firstTeam);
                match.Controls.Add(teamOne);
            }

            //if the second team has bowlers then set up the team name label and display the team on the match form we just created
            if (secondTeam.bowlers.Count > 0)
            {
                //depending on the number of bowlers, the size of the fields will change
                this.teamTwo.Size = new Size(1200, 100 + (16 * secondTeam.bowlers.Count));
                this.teamTwo.Location = new Point(20, 125 + (16 * firstTeam.bowlers.Count));
                this.teamTwo.BackColor = Color.Blue;
                displayTeam(teamTwo, secondTeam);
                match.Controls.Add(teamTwo);
            }

            //if the third team has bowlers then set up the team name label and display the team on the match form we just created
            if (thirdTeam.bowlers.Count > 0)
            {
                //depending on the number of bowlers, the size of the fields will change
                this.teamThree.Size = new Size(1200, 100 + (16 * thirdTeam.bowlers.Count));
                this.teamThree.Location = new Point(20, 263 + (16 * secondTeam.bowlers.Count));
                this.teamThree.BackColor = Color.Green;
                displayTeam(teamThree, thirdTeam);
                match.Controls.Add(teamThree);
            }

            //if the fourth team has bowlers then set up the team name label and display the team on the match form we just created
            if (fourthTeam.bowlers.Count > 0)
            {
                //depending on the number of bowlers, the size of the fields will change
                this.teamFour.Size = new Size(1200, 100 + (16 * fourthTeam.bowlers.Count));
                this.teamFour.Location = new Point(20, 400 + (16 * thirdTeam.bowlers.Count));
                this.teamFour.BackColor = Color.Purple;
                displayTeam(teamFour, fourthTeam);
                match.Controls.Add(teamFour);
            }

            //set the form title to the match title entered on the main form
            match.Text = this.MatchTitle.Text;

            //show the form
            match.Show();

            //disable all the controls on the form except the next string button
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

            //is this the first string of the match?
            if (currentString == 0)
            {
                //set up the label for the team name
                Label teamName = new Label();
                teamName.Text = team.name.ToUpper();
                teamName.Location = new Point(10, 10);
                teamName.Size = new Size(300, 40);
                teamName.TextAlign = ContentAlignment.MiddleCenter;
                teamName.Enabled = false;
                teamName.Font = new Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold);
                teamArea.Controls.Add(teamName);

                //set up the label for the string total
                Label stringTotalLabel = new Label();
                stringTotalLabel.Size = new Size(50, 20);
                stringTotalLabel.Location = new Point(598, 20);
                stringTotalLabel.Text = "Total";
                stringTotalLabel.TextAlign = ContentAlignment.MiddleLeft;
                stringTotalLabel.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                teamArea.Controls.Add(stringTotalLabel);

                //set up the label for the previous strings area
                Label prevStringsLabel = new Label();
                prevStringsLabel.Size = new Size(130, 20);
                prevStringsLabel.Location = new Point(750, 20);
                prevStringsLabel.Text = "Previous Strings";
                prevStringsLabel.TextAlign = ContentAlignment.MiddleCenter;
                prevStringsLabel.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                teamArea.Controls.Add(prevStringsLabel);

                //set up the label for the bowler match total
                Label bowlerTotalLabel = new Label();
                bowlerTotalLabel.Size = new Size(55, 20);
                bowlerTotalLabel.Location = new Point(1025, 20);
                bowlerTotalLabel.Text = "Match Total";
                bowlerTotalLabel.TextAlign = ContentAlignment.MiddleLeft;
                bowlerTotalLabel.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                teamArea.Controls.Add(bowlerTotalLabel);

                //if the team has more than one bowler we need to change the size of the box and the font so it stands out
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
                    //because c# is stupid, you have to specify a float by using a trailing f
                    teamTotalLabel.Font = new Font(FontFamily.GenericSansSerif, (10 + (2 * (team.bowlers.Count * 0.62F))), FontStyle.Bold, GraphicsUnit.Pixel);
                    teamTotalLabel.Location = new Point(1070, 20 + (2 * team.bowlers.Count));
                    teamTotalLabel.Text = "Team Total";
                    teamTotalLabel.TextAlign = ContentAlignment.MiddleCenter;
                    teamArea.Controls.Add(teamTotalLabel);
                }
            }

            //show a string for every bowler on the team
            foreach (Bowler teamBowler in team.bowlers)
            {
                bowlerCount++;

                Label bowlerName = new Label();
                bowlerName.Text = teamBowler.name.ToUpper();

                //if this is the first bowler on the team set the field at a static location
                if (bowlerCount == 1)
                {
                    bowlerName.Location = new Point(0, 50);
                }
                //if this an additional bowler we need to calculate where in the control to display the information
                else
                {
                    bowlerName.Location = new Point(0, (25 + (25 * bowlerCount)));
                }

                //set up the label for the bowlers name
                bowlerName.Size = new Size(125, 25);
                bowlerName.TextAlign = ContentAlignment.MiddleCenter;
                bowlerName.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
                bowlerName.AutoSize = false;

                bowlerName.Enabled = false;

                //add the label to the team control.
                teamArea.Controls.Add(bowlerName);

                //set the display location of the bowler's match total
                teamBowler.matchTotal.Location = new Point(1030, (25 + (25 * bowlerCount)));
                teamBowler.matchTotal.LostFocus += new System.EventHandler(teamBowler.calcBowlerMatchTotal);

                //add the bowler's match total to the team control
                teamArea.Controls.Add(teamBowler.matchTotal);

                //if the team has more than one bowler we need to setup the text box for the team total to be larger to hold more digits and to stand out
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

        //call back for the next string button
        private void NextString_OnClick(object sender, EventArgs e)
        {
            //validate that we aren't on the last string
            if ((currentString) < NumStrings.SelectedIndex)
            {
                currentString++;

                //if there are bowlers on the first team, hide the string we just finished and show the next string
                if (firstTeam.bowlers.Count > 0)
                {
                    hidePreviousString(firstTeam);

                    showNextString(teamOne, firstTeam);
                }

                //if there are bowlers on the second team, hide the string we just finished and show the next string
                if (secondTeam.bowlers.Count > 0)
                {
                    hidePreviousString(secondTeam);

                    showNextString(teamTwo, secondTeam);
                }

                //if there are bowlers on the third team, hide the string we just finished and show the next string
                if (thirdTeam.bowlers.Count > 0)
                {
                    hidePreviousString(thirdTeam);

                    showNextString(teamThree, thirdTeam);
                }

                //if there are bowlers on the fourth team, hide the string we just finished and show the next string
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
            //iterate through the bowlers of the team
            for (int i = 0; i < in_team.bowlers.Count; i++)
            {
                //iterate through the boxes of the string just finished for the bowler and hide them
                for (int y = 0; y < in_team.bowlers[i].strings[currentString - 1].game.Count; y++)
                {
                    in_team.bowlers[i].strings[currentString - 1].game[y].Hide();
                }

                //move the string total for the bowler to the previous string area
                in_team.bowlers[i].strings[currentString - 1].stringTotal.Location = new Point(620 + (40 * currentString), (49 + (25 * i + 1)));
            }
        }

        private void showNextString(Control in_control, Team in_team)
        {
            //iterate through all the bowlers
            for (int i = 0; i < in_team.bowlers.Count; i++)
            {
                int bowlerIndex = i;

                //iterate through all the boxes for this bowlers next string and show them
                for (int x = 0; x < in_team.bowlers[i].strings[currentString].game.Count; x++)
                {
                    int boxIndex = x;
                    //we need to calculate where the location of each box will be displayed on the control.
                    //we will use the the bowlers number (i) and the box number (x) to calculate the offset we need
                    in_team.bowlers[i].strings[currentString].game[boxIndex].Location = new Point(150 + (45 * x), (25 + (25 * (i + 1))));
                    
                    //set up the call backs for each box so we can validate and calculate the boxes score, the string total, bowler's match total and the team's match total
                    in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler((s, e) => in_team.bowlers[bowlerIndex].strings[currentString].String_BoxTextChanged(s, e, in_team.bowlers[bowlerIndex].strings[currentString].game[boxIndex]));
                    in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.bowlers[bowlerIndex].strings[currentString].BowlingString_CalcTotal);
                    in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.bowlers[bowlerIndex].calcBowlerMatchTotal);
                    in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.Team_CalcTotal);

                    //eventually when I get the key press functionality working I'll need to register the callbacks differently.
                    //in_team.bowlers[i].strings[currentString].game[x].KeyDown += new System.Windows.Forms.KeyEventHandler((s, e) => in_team.bowlers[bowlerIndex].strings[currentString].String_KeyPress(s, e, in_team.bowlers[bowlerIndex].strings[currentString].game[boxIndex]));
                    //in_team.bowlers[i].strings[currentString].game[x].KeyDown += new System.Windows.Forms.KeyEventHandler(in_team.bowlers[bowlerIndex].strings[currentString].BowlingString_CalcTotal);
                    //in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.bowlers[bowlerIndex].calcBowlerMatchTotal);
                    //in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.Team_CalcTotal);

                    //add the box to the team control
                    in_control.Controls.Add(in_team.bowlers[i].strings[currentString].game[x]);
                }

                //set up the display information for the string total of the new string.
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