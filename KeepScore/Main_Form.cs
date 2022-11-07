namespace KeepScore
{
    using System.Collections.Generic;
    using System.Collections.Immutable;

    public partial class Main_Form : Form
    {
        private Team firstTeam;
        private Control teamOne;
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

            currentString = 0;

            this.numBoxesPerTurn.SelectedIndex = 0;
            this.NumStrings.SelectedIndex = 0;

            this.Show();

            Form startMenuInstructions = new startMenuInstr();
            startMenuInstructions.Show();

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
                if (Team1_Bowler1.Text != "")
                {
                    bowlersNames.Clear();

                    //get the list of names for team 1
                    bowlersNames = populateBowlers(1);

                    //if the first team has bowlers set up for it, then create the team
                    if (bowlersNames.Count > 0)
                    {
                        firstTeam = new Team("TeamName", bowlersNames, NumStrings.SelectedIndex + 1);
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
            int nameCount = 0;

            if (NumStrings.SelectedIndex == -1)
            {
                errMsg += "Please select the number of strings for this match.\n";
            }

            bowlerErrMsg = "";

            //check all the active bowler name fields
            for (int y = 1; y < 6; y++)
            {
                bowlerErrMsg = "";
                controlName = "Team1_Bowler" + y;
                tempTextBox = (TextBox)this.Controls.Find(controlName, true)[0];

                if (tempTextBox.Text != "")
                {
                    nameCount++;
                }

                if (nameCount == 0)
                {
                    bowlerErrMsg = "Please enter at least one bowler's name.\n";
                }

                try
                {
                    controlName = "Team2_Bowler" + y;
                    tempTextBox = (TextBox)this.Controls.Find(controlName, true)[0];

                    if (tempTextBox.Text != "") {
                        nameCount = int.Parse(tempTextBox.Text);

                        if (nameCount > 51 || nameCount < 0)
                        {
                            bowlerErrMsg = "Bowler " + y + " has a handicap that is out of bounds, please enter a value between 0 and 50.\n\n";
                        }
                    }
                }
                catch (Exception e)
                {
                    bowlerErrMsg = "Bowler " + y + " has a non numeric handicap.\n\n";
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

                if (tempTextBox.Text.Trim() != "")
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
            match.Name = "MatchForm";
            teamOne = new Control();
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            match.Location = new Point(0, 0);
            int w = screen.Width;
            int h = Convert.ToInt32(screen.Height * 0.96);
            match.Size = new Size(w, h);
            match.MaximizeBox = true;
            match.AutoScroll = true;

            match.FormClosed += resetMainForm;

            //if the first team has bowlers then set up the team name label and display the team on the match form we just created
            if (firstTeam.bowlers.Count > 0)
            {
                //depending on the number of bowlers, the size of the fields will change
                this.teamOne.Size = match.Size;
                this.teamOne.Location = new Point(0, 20);
                this.teamOne.BackColor = Color.Red;
                displayTeam(teamOne, firstTeam);
                match.Controls.Add(teamOne);
            }

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

            firstTeam.bowlers[0].strings[currentString].game[0].Focus();

            Form scoreSheetInstructions = new scoreSheetInstr();
            scoreSheetInstructions.Show();
        }

        private void displayTeam(Control teamArea, Team team)
        {
            int bowlerCount = 0;
            string controlName = "";
            TextBox tempTextBox = new TextBox();


            //is this the first string of the match?
            if (currentString == 0)
            {
                //set up the label for the bowler's handicap
                Label bowlerHDCP = new Label();
                bowlerHDCP.Size = new Size(300, 40);
                bowlerHDCP.Location = new Point(300, 10);
                bowlerHDCP.Text = "HDCP";
                bowlerHDCP.TextAlign = ContentAlignment.MiddleCenter;
                bowlerHDCP.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
                teamArea.Controls.Add(bowlerHDCP);
                bowlerHDCP.Enabled = false;

                //set up the label for the string total
                Label stringTotalLabel = new Label();
                stringTotalLabel.Size = new Size(120, 40);
                stringTotalLabel.Location = new Point(Convert.ToInt32(teamArea.Width * 0.825), 10);
                stringTotalLabel.Text = "Total";
                stringTotalLabel.TextAlign = ContentAlignment.MiddleLeft;
                stringTotalLabel.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
                teamArea.Controls.Add(stringTotalLabel);
                stringTotalLabel.Enabled = false;

                //set up the label for the string total w/hdcp
                Label stringTotalHDCPLabel = new Label();
                stringTotalHDCPLabel.Size = new Size(150, 40);
                stringTotalHDCPLabel.Location = new Point(Convert.ToInt32(teamArea.Width * 0.895), 10);
                stringTotalHDCPLabel.Text = "HDCP";
                stringTotalHDCPLabel.TextAlign = ContentAlignment.MiddleLeft;
                stringTotalHDCPLabel.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
                teamArea.Controls.Add(stringTotalHDCPLabel);
                stringTotalHDCPLabel.Enabled = false;

                //set up the label for the previous strings area
                Label prevStringsLabel = new Label();
                prevStringsLabel.Size = new Size(400, 60);
                prevStringsLabel.Location = new Point(10, Convert.ToInt32(teamArea.Height * 0.60));
                prevStringsLabel.Text = "Previous Strings";
                prevStringsLabel.TextAlign = ContentAlignment.MiddleCenter;
                prevStringsLabel.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
                teamArea.Controls.Add(prevStringsLabel);
                prevStringsLabel.Enabled = false;

                //set up the label for the bowler match total
                Label bowlerTotalLabel = new Label();
                bowlerTotalLabel.Size = new Size(400, 60);
                bowlerTotalLabel.Location = new Point(Convert.ToInt32(teamArea.Width * 0.83), Convert.ToInt32(teamArea.Height * 0.60));
                bowlerTotalLabel.Text = "Match Totals";
                bowlerTotalLabel.TextAlign = ContentAlignment.MiddleLeft;
                bowlerTotalLabel.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
                teamArea.Controls.Add(bowlerTotalLabel);
                bowlerTotalLabel.Enabled = false;

                //if the team has more than one bowler we need to change the size of the box and the font so it stands out
                if (team.bowlers.Count > 1)
                {
                    Label teamTotalLabel = new Label();
                    teamTotalLabel.Size = new Size(400, 60);
                    teamTotalLabel.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                    teamTotalLabel.Location = new Point(Convert.ToInt32(teamArea.Width * 0.60), Convert.ToInt32(teamArea.Height * 0.45));
                    teamTotalLabel.Text = "Team Match Totals";
                    teamTotalLabel.TextAlign = ContentAlignment.MiddleCenter;
                    teamArea.Controls.Add(teamTotalLabel);
                    teamTotalLabel.Enabled = false;

                    Label teamStringTotalLabel = new Label();
                    teamStringTotalLabel.Size = new Size(400, 60);
                    teamStringTotalLabel.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                    teamStringTotalLabel.Location = new Point(Convert.ToInt32(teamArea.Width * 0.60), Convert.ToInt32(teamArea.Height * 0.38));
                    teamStringTotalLabel.Text = "Team String Totals";
                    teamStringTotalLabel.TextAlign = ContentAlignment.MiddleCenter;
                    teamArea.Controls.Add(teamStringTotalLabel);
                    teamStringTotalLabel.Enabled = false;
                }
            }

            //show a string for every bowler on the team
            foreach (Bowler teamBowler in team.bowlers)
            {
                bowlerCount++;

                Label bowlerName = new Label();
                Label prevStringsBowlerName = new Label();

                bowlerName.Text = teamBowler.name.ToUpper();
                prevStringsBowlerName.Text = teamBowler.name.ToUpper();

                //if this is the first bowler on the team set the field at a static location
                if (bowlerCount == 1)
                {
                    bowlerName.Location = new Point(0, 70);
                    prevStringsBowlerName.Location = new Point(20, (Convert.ToInt32(teamOne.Height * 0.60) + (60 * bowlerCount)));
                    teamBowler.handicap.Text = Team2_Bowler1.Text;

                    //set the display of the bowler's handicap
                    teamBowler.handicap.Location = new Point(400, 85);
                    teamBowler.handicap.Enabled = false;
                }
                //if this an additional bowler we need to calculate where in the control to display the information
                else
                {
                    bowlerName.Location = new Point(0, (15 + (60 * bowlerCount)));
                    prevStringsBowlerName.Location = new Point(20, (Convert.ToInt32(teamOne.Height * 0.60) + (60 * bowlerCount)));

                    controlName = "Team2_Bowler" + bowlerCount;
                    tempTextBox = (TextBox)this.Controls.Find(controlName, true)[0];
                    teamBowler.handicap.Text = tempTextBox.Text;

                    //set the display of the bowler's handicap
                    teamBowler.handicap.Location = new Point(400, (25 + (60 * bowlerCount)));
                    teamBowler.handicap.Enabled = false;
                }

                teamArea.Controls.Add(teamBowler.handicap);

                //set up the label for the bowlers name
                bowlerName.Size = new Size(300, 70);
                prevStringsBowlerName.Size = new Size(300, 75);
                bowlerName.TextAlign = ContentAlignment.MiddleLeft;
                prevStringsBowlerName.TextAlign = ContentAlignment.MiddleLeft;
                bowlerName.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold);
                prevStringsBowlerName.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold);
                bowlerName.AutoSize = false;
                prevStringsBowlerName.AutoSize = false;

                bowlerName.Enabled = false;
                prevStringsBowlerName.Enabled = false;

                //add the label to the team control.
                teamArea.Controls.Add(bowlerName);
                teamArea.Controls.Add(prevStringsBowlerName);

                //set the display location of the bowler's match total
                teamBowler.matchTotal.Location = new Point(Convert.ToInt32(teamArea.Width * 0.83), (Convert.ToInt32(teamArea.Height * 0.61) + (60 * bowlerCount)));
                teamBowler.matchTotal.LostFocus += new System.EventHandler(teamBowler.calcBowlerMatchTotal);
                teamBowler.matchTotal.Enabled = false;

                teamBowler.matchTotalHDCP.Location = new Point(Convert.ToInt32(teamArea.Width * 0.90), (Convert.ToInt32(teamArea.Height * 0.61) + (60 * bowlerCount)));
                teamBowler.matchTotalHDCP.Enabled = false;

                //add the bowler's match total to the team control
                teamArea.Controls.Add(teamBowler.matchTotal);
                teamArea.Controls.Add(teamBowler.matchTotalHDCP);

                //if the team has more than one bowler we need to setup the text box for the team total to be larger to hold more digits and to stand out
                if (team.bowlers.Count > 1)
                {
                    team.teamTotal.Size = new Size(100, 100);
                    team.teamTotal.TextAlign = HorizontalAlignment.Center;
                    team.teamTotal.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                    team.teamTotal.Location = new Point(Convert.ToInt32(teamArea.Width * 0.83), Convert.ToInt32(teamArea.Height * 0.45));
                    team.teamTotal.LostFocus += new System.EventHandler(team.Team_CalcTotal);
                    teamArea.Controls.Add(team.teamTotal);
                    team.teamTotal.Enabled = false;

                    team.teamTotalHDCP.Size = new Size(100, 100);
                    team.teamTotalHDCP.TextAlign = HorizontalAlignment.Center;
                    team.teamTotalHDCP.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                    team.teamTotalHDCP.Location = new Point(Convert.ToInt32(teamArea.Width * 0.90), Convert.ToInt32(teamArea.Height * 0.45));
                    team.teamTotalHDCP.LostFocus += new System.EventHandler(team.Team_CalcTotal);
                    team.teamTotalHDCP.Text = "0";
                    teamArea.Controls.Add(team.teamTotalHDCP);
                    team.teamTotalHDCP.Enabled = false;

                    team.teamStringTotal.TextAlign = HorizontalAlignment.Center;
                    team.teamStringTotal.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                    team.teamStringTotal.Location = new Point(Convert.ToInt32(teamArea.Width * 0.83), Convert.ToInt32(teamArea.Height * 0.38));
                    team.teamStringTotal.LostFocus += new System.EventHandler(team.Team_CalcTotal);
                    team.teamStringTotal.Size = new Size(100, 100);
                    team.teamStringTotal.Text = "0";
                    teamArea.Controls.Add(team.teamStringTotal);
                    team.teamStringTotal.Enabled = false;

                    team.teamStringTotalHDCP.Size = new Size(100, 100);
                    team.teamStringTotalHDCP.TextAlign = HorizontalAlignment.Center;
                    team.teamStringTotalHDCP.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                    team.teamStringTotalHDCP.Location = new Point(Convert.ToInt32(teamArea.Width * 0.90), Convert.ToInt32(teamArea.Height * 0.38));
                    team.teamStringTotalHDCP.Text = "0";
                    team.teamStringTotalHDCP.LostFocus += new System.EventHandler(team.Team_CalcTotal);
                    teamArea.Controls.Add(team.teamStringTotalHDCP);
                    team.teamStringTotalHDCP.Enabled = false;
                }

            }

            //add a button to show the next string.
            Button nextString = new Button();
            nextString.Name = "NextStringBtn";
            nextString.Size = new Size(300, 50);
            nextString.BackColor = Color.White;
            nextString.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold, GraphicsUnit.Pixel);
            nextString.Location = new Point(20, Convert.ToInt32(teamArea.Height * 0.55));
            nextString.Text = "Next String";
            nextString.TextAlign = ContentAlignment.MiddleCenter;
            nextString.Click += new System.EventHandler(NextString_OnClick);
            nextString.Show();
            teamArea.Controls.Add(nextString);

            //add the strings for all the bowlers on team to the team area
            showNextString(teamArea, team);

            team.bowlers[0].strings[currentString].game[0].Focus();
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
                in_team.bowlers[i].strings[currentString - 1].stringTotal.Location = new Point(400 + (108 * currentString), (Convert.ToInt32(teamOne.Height * 0.665) + (60 * i + 1)));
                in_team.bowlers[i].strings[currentString - 1].totalHDCP.Hide();
                in_team.teamStringTotalHDCP.Text = "0";
                in_team.teamStringTotal.Text = "0";
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
                    in_team.bowlers[i].strings[currentString].game[boxIndex].Location = new Point(510 + (108 * x), (25 + (60 * (i + 1))));

                    //set up the call backs for each box so we can validate and calculate the boxes score, the string total, bowler's match total and the team's match total
                    //in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler((s, e) => in_team.bowlers[bowlerIndex].strings[currentString].String_BoxTextChanged(s, e, in_team.bowlers[bowlerIndex].strings[currentString].game[boxIndex]));
                    //in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.bowlers[bowlerIndex].strings[currentString].BowlingString_CalcTotal);
                    //in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.bowlers[bowlerIndex].calcBowlerMatchTotal);
                    //in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(in_team.Team_CalcTotal);
                    //in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler(this.Team_CalcStringTotal);
                    //in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler((s, e) => in_team.toggleScoreCorrectMode(s, e, in_team.bowlers[bowlerIndex].strings[currentString].game[boxIndex]));
                    //in_team.bowlers[i].strings[currentString].game[x].Validated += new System.EventHandler((s, e) => in_team.Team_NextBowlersTurn(s, e, boxIndex, bowlerIndex, currentString, int.Parse(this.numBoxesPerTurn.Text)));

                    in_team.bowlers[i].strings[currentString].game[x].TextChanged += new System.EventHandler((s, e) => in_team.bowlers[bowlerIndex].strings[currentString].String_KeyPress(s, e, in_team.bowlers[bowlerIndex].strings[currentString].game[boxIndex]));
                    in_team.bowlers[i].strings[currentString].game[x].TextChanged += new System.EventHandler(in_team.bowlers[bowlerIndex].strings[currentString].BowlingString_CalcTotal);
                    in_team.bowlers[i].strings[currentString].game[x].TextChanged += new System.EventHandler(in_team.bowlers[bowlerIndex].calcBowlerMatchTotal);
                    in_team.bowlers[i].strings[currentString].game[x].TextChanged += new System.EventHandler(in_team.Team_CalcTotal);
                    in_team.bowlers[i].strings[currentString].game[x].TextChanged += new System.EventHandler(this.Team_CalcStringTotal);
                    in_team.bowlers[i].strings[currentString].game[x].TextChanged += new System.EventHandler((s, e) => in_team.toggleScoreCorrectMode(s, e, in_team.bowlers[bowlerIndex].strings[currentString].game[boxIndex]));
                    in_team.bowlers[i].strings[currentString].game[x].TextChanged += new System.EventHandler((s, e) => in_team.Team_NextBowlersTurn(s, e, boxIndex, bowlerIndex, currentString, int.Parse(this.numBoxesPerTurn.Text)));
                    in_team.bowlers[i].strings[currentString].game[x].KeyDown += new System.Windows.Forms.KeyEventHandler((s, e) => in_team.handleArrowsToNav(s, e, boxIndex, bowlerIndex, currentString));

                    //add the box to the team control
                    in_control.Controls.Add(in_team.bowlers[i].strings[currentString].game[x]);

                    in_team.bowlers[i].strings[currentString].boxesPerTurn = int.Parse(this.numBoxesPerTurn.Text);
                }

                //set up the display information for the string total of the new string.
                //use offset of 11 since we know that all strings have 10 boxes and this will be after that
                in_team.bowlers[i].strings[currentString].stringTotal.Location = new Point(Convert.ToInt32(in_control.Width * 0.83), (25 + (60 * (i + 1))));
                //in_team.bowlers[i].strings[currentString].stringTotal.Validated += new System.EventHandler(in_team.bowlers[i].strings[currentString].BowlingString_CalcTotal);
                //in_team.bowlers[i].strings[currentString].stringTotal.Validated += new System.EventHandler(this.Team_CalcStringTotal);
                in_control.Controls.Add(in_team.bowlers[i].strings[currentString].stringTotal);
                in_team.bowlers[i].strings[currentString].stringTotal.Enabled = false;

                in_team.bowlers[i].strings[currentString].totalHDCP.Location = new Point(Convert.ToInt32(in_control.Width * 0.90), (25 + (60 * (i + 1))));
                //in_team.bowlers[i].strings[currentString].totalHDCP.Validated += new System.EventHandler(in_team.bowlers[i].strings[currentString].BowlingString_CalcTotal);
                in_team.bowlers[i].strings[currentString].totalHDCP.Enabled = false;

                //in_team.boxesPerTurn = int.Parse(this.numBoxesPerTurn.Text);
                in_control.Controls.Add(in_team.bowlers[i].strings[currentString].totalHDCP);

                if (in_team.bowlers[i].handicap.Text != "")
                {
                    in_team.bowlers[i].strings[currentString].HDCP = Convert.ToInt32(in_team.bowlers[i].handicap.Text);
                    in_team.bowlers[i].strings[currentString].BowlingString_CalcTotal(new Object(), new EventArgs());
                    in_team.bowlers[i].calcBowlerMatchTotal(new Object(), new EventArgs());
                    in_team.Team_CalcTotal(new Object(), new EventArgs());
                    this.Team_CalcStringTotal(new Object(), new EventArgs());
                }

                in_team.bowlers[in_team.bowlers.Count - 1].strings[currentString].game[9].Validated += new System.EventHandler(this.Activate_NextStringButton);
            }

            Team_CalcStringTotal(new object(), new EventArgs());
            in_team.bowlers[0].strings[currentString].game[0].Focus();
        }

        public void Team_CalcStringTotal(object sender, EventArgs e)
        {
            int temp_teamStringTotal = 0;
            int temp_teamStringTotalHDCP = 0;

            //iterate through all the bowlers match totals to get the team's total.
            for (int i = 0; i < firstTeam.bowlers.Count; i++)
            {
                temp_teamStringTotal += int.Parse(firstTeam.bowlers[i].strings[currentString].stringTotal.Text);
                temp_teamStringTotalHDCP += int.Parse(firstTeam.bowlers[i].strings[currentString].totalHDCP.Text);
            }

            firstTeam.teamStringTotal.Text = temp_teamStringTotal.ToString();
            firstTeam.teamStringTotalHDCP.Text = temp_teamStringTotalHDCP.ToString();

        }

        public void Activate_NextStringButton(object sender, EventArgs e)
        {
            if (firstTeam.bowlers[firstTeam.bowlers.Count - 1].strings[currentString].game[9].Text != "") {
                string controlName = "NextStringBtn";
                Button tempButton = (Button)teamOne.Controls.Find(controlName, false)[0];
                tempButton.Focus();
            }
        }

        private void Help_OnClick(object sender, EventArgs e)
        {
            string Message = "*   Use the TAB key to go to the next field. Up and down arrows can be used in drop down fields. \n";
            Message += "*   Enter the names of the bowlers, if fewer than 5, leave fields blank. \n";
            Message += "*   Enter the handicap for each bowler bowling, if this is open bowling, you can leave them blank. \n";
            Message += "*   Select the number of strings to be bowled in the match. \n";
            Message += "*   Select the number of boxes each bowler will bowl during their turn. \n";
            Message += "*   When the information is correct, click/press enter on the Create Score Sheet button. \n";
            Message += "*   When done with each string, load the next string's score sheet using the Next String button. ";

            MessageBox.Show(Message, "How to keep score", MessageBoxButtons.OK);
        }

        public void resetMainForm(object sender, FormClosedEventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                    c.Enabled = true;

                    if (c.Name == "Team1_Bowler1")
                    {
                        c.Focus();
                    }
                }

                if (c is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)c;

                    comboBox.SelectedIndex = 0;
                    comboBox.Enabled = true;
                }

                if (c is Button)
                {
                    c.Enabled = true;
                }

                if (c is Label)
                {
                    c.Enabled = true;
                }
            }

            Form startMenuInstructions = new startMenuInstr();
            startMenuInstructions.Show();
        }
    }
}