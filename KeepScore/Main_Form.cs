namespace KeepScore
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Drawing.Printing;
    using System.IO;
    using System.Linq.Expressions;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Permissions;
    using System.Text.Json;
    using System.Transactions;
    using System.Windows.Forms.VisualStyles;

    public partial class Main_Form : Form
    {
        //used for printing only
        private Font printFont;
        private StreamReader streamToPrint;

        private Team firstTeam;
        private Control teamOne;
        private int currentString;
        private Boolean foundJson;
        private int laneNumber;
        private string welcomeStr;
        private string numBoxesTurn;

        private Match match;
        private AdminLogin adminLogin;
        private int offset_instructions = 0;
        //private int orig_form_hieght = 0;
        public Main_Form()
        {
            string fileName = "";
            string fileLine = "";
            string[] strArray = { };

            InitializeComponent();

            checkDirectories();

            //Set up the form.
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.CadetBlue;
            this.ForeColor = Color.Black;
            this.Size = new System.Drawing.Size(1300, 400);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.WindowState = FormWindowState.Maximized;

            fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore", "keepscore.ini");

            if (File.Exists(fileName))
            {
                FileStream myFileStream = File.Open(fileName, FileMode.Open);
                StreamReader file = new System.IO.StreamReader(myFileStream, System.Text.Encoding.UTF8, true, 128);

                while ((fileLine = file.ReadLine()) != null)
                {
                    strArray = fileLine.Split("::");

                    if (strArray[0] == "Welcome")
                    {
                        this.Welcome.Text = strArray[1];
                        this.welcomeStr = strArray[1];
                    }
                    else if (strArray[0] == "BoxesPerTurn")
                    {
                        this.numBoxesTurn = strArray[1];
                        this.numBoxesPerTurn.SelectedItem = strArray[1];
                    }
                    else if (strArray[0] == "PrintSummary")
                    {
                        this.printSummary.SelectedItem = strArray[1];
                    }
                    else if (strArray[0] == "LaneNumber")
                    {
                        try
                        {
                            this.laneNumber = Int32.Parse(strArray[1]);
                            this.laneNumberTxt.Text = strArray[1];
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("The lane number found is not valid, please correct it.", "Error", MessageBoxButtons.OK);
                        }
                    }
                }

                file.Close();
            }

            if (this.Welcome.Text == "")
            {
                this.Welcome.Text = "Welcome to Our Bowling Center";
            }

            if (this.numBoxesPerTurn.SelectedItem == null)
            {
                this.numBoxesPerTurn.SelectedIndex = 0;
            }

            if (this.printSummary.SelectedItem == null)
            {
                this.printSummary.SelectedIndex = 0;
            }

            this.NumStrings.SelectedIndex = 0;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(Panel))
                {
                    foreach (Control ctrl1 in ctrl.Controls)
                    {
                        ctrl1.GotFocus += highLightField;
                        ctrl1.LostFocus += unHighLightField;
                    }
                }
            }

            foundJson = false;

            int bowler_count = -1;
            int string_count = -1;
            int stringInProg = -1;

            fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore", "Inprogress.json");

            if (File.Exists(fileName))
            {
                foundJson = true;
                string jsonString = File.ReadAllText(fileName);
                firstTeam = new Team();
                firstTeam = JsonSerializer.Deserialize<Team>(jsonString)!;

                this.numBoxesPerTurn.Text = firstTeam.bowlers[0].strings[0].boxesPerTurn.ToString();
                this.NumStrings.Text = firstTeam.bowlers[0].strings.Count.ToString();

                if (this.numBoxesPerTurn.Text == "")
                {
                    this.numBoxesPerTurn.Text = "1";
                }

                //now that we have all our teams set up, create the match form
                CreateMatchForm();

                if (foundJson)
                {
                    foreach (Bowler teamBowler in firstTeam.bowlers)
                    {
                        bowler_count++;
                        string_count = -1;

                        teamBowler.matchTotal.Size = new Size(100, 50);
                        teamBowler.matchTotal.TextAlign = HorizontalAlignment.Center;
                        teamBowler.matchTotal.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);

                        teamBowler.matchTotalHDCP.Size = new Size(100, 50);
                        teamBowler.matchTotalHDCP.TextAlign = HorizontalAlignment.Center;
                        teamBowler.matchTotalHDCP.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);

                        teamBowler.handicap.Size = new Size(100, 50);
                        teamBowler.handicap.TextAlign = HorizontalAlignment.Center;
                        teamBowler.handicap.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
                        teamBowler.handicap.Text = teamBowler.int_handicap.ToString();

                        foreach (BowlingString strings in teamBowler.strings)
                        {
                            string_count++;

                            strings.stringTotal.Size = new Size(100, 50);
                            strings.stringTotal.TextAlign = HorizontalAlignment.Center;
                            strings.stringTotal.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);

                            strings.totalHDCP.Size = new Size(100, 50);
                            strings.totalHDCP.TextAlign = HorizontalAlignment.Center;
                            strings.totalHDCP.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);

                            foreach (Box box in strings.game)
                            {
                                box.formatBox();

                                if (box.baseScore > 0 || box.boxTotal > 0)
                                {
                                    if (stringInProg < string_count)
                                    {
                                        stringInProg = string_count;
                                    }
                                    //if the last bowler has completed the string, then the next string is the one in progress
                                    else if (firstTeam.bowlers.Count - 1 == bowler_count && box.boxNumber == 9)
                                    {
                                        //if we are in the last string, don't advance count beyond the array bounds
                                        if (string_count < teamBowler.strings.Count - 1 && string_count >= stringInProg)
                                        {
                                            stringInProg++;
                                        }
                                    }

                                    if (box.isSpare)
                                    {
                                        box.spareImgLabel.Show();
                                        box.DisplayBox.Text = box.markLoad.ToString();
                                    }
                                    else if (box.isStrike)
                                    {
                                        box.spareImgLabel.Show();
                                        box.strikeImgLabel.Show();
                                        box.DisplayBox.Text = box.markLoad.ToString();
                                    }
                                    else
                                    {
                                        box.DisplayBox.Text = box.boxTotal.ToString();
                                    }

                                    box.DisplayBox.Show();
                                    box.DisplayBox.Focus();
                                }
                            }

                            strings.stringTotal.Text = strings.Calc_Total().ToString();
                            strings.totalHDCP.Text = (strings.Calc_Total() + teamBowler.int_handicap).ToString();
                            strings.eventHandled = false;

                        }
                    }
                }

                if (stringInProg > 0)
                {
                    while (currentString <= stringInProg && firstTeam.bowlers[0].strings.Count - 1 >= currentString)
                    {
                        if (currentString == 0)
                        {
                            showNextString(teamOne, firstTeam);
                        }
                        else
                        {
                            hidePreviousString(firstTeam);
                            showNextString(teamOne, firstTeam);
                        }

                        currentString++;
                    }
                }
                else
                {
                    showNextString(teamOne, firstTeam);
                    currentString++;
                }

                //reset current string to the actual current string. We actually advanced it beyond the current string in the while loop, so fix it.
                currentString--;

                foreach (Control c in this.Controls)
                {
                    if (c.Name == "NextString")
                    {
                        c.BackColor = Color.White;
                    }

                    if (c.Name == "panel1")
                    {
                        c.BackColor = Color.CadetBlue;
                    }
                }

                foundJson = false;
            }
            else
            {

                firstTeam = new Team();

                currentString = 0;

                this.Show();
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

                    if (tempTextBox.Text != "")
                    {
                        nameCount = int.Parse(tempTextBox.Text);

                        if (nameCount > 91 || nameCount < 0)
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
            for (int x = 1; x < 8; x++)
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
            this.match = new Match();
            this.match.Name = "MatchForm";
            teamOne = new Control();
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            this.match.Location = new Point(0, 0);
            int w = screen.Width;
            int h = Convert.ToInt32(screen.Height * 0.96);
            //orig_form_hieght = h;

            if (firstTeam.bowlers.Count > 5)
            {
                this.match.Size = new Size(w, h + (2 * (15 + (60 * (firstTeam.bowlers.Count - 5)))));
                this.match.AutoScroll = true;
            }
            else
            {
                this.match.Size = new Size(w, h);
                this.match.AutoScroll = false;
            }

            this.match.MaximizeBox = false;
            this.match.MinimizeBox = false;

            this.match.FormClosed += PrintSummary;
            this.match.FormClosed += resetMainForm;

            //if the first team has bowlers then set up the team name label and display the team on the match form we just created
            if (firstTeam.bowlers.Count > 0)
            {
                //depending on the number of bowlers, the size of the fields will change
                this.teamOne.Size = match.Size;
                this.teamOne.Location = new Point(0, 20);
                this.teamOne.BackColor = Color.CadetBlue;
                displayTeam(teamOne, firstTeam);
                this.match.Controls.Add(teamOne);

                if (foundJson)
                {
                    if (firstTeam.printSummary == "League Summary")
                    {
                        printSummary.Text = "League Summary";
                    }
                    else if (firstTeam.printSummary == "Detailed (Strings)")
                    {
                        printSummary.Text = "Detailed (Strings)";
                    }
                    else
                    {
                        printSummary.Text = "None";
                    }
                }
                else
                {
                    if (printSummary.Text == "None")
                    {
                        firstTeam.printSummary = "None";
                    }
                    else if (printSummary.Text == "Detailed (Strings)")
                    {
                        firstTeam.printSummary = "Detailed (Strings)";
                    }
                    else
                    {
                        firstTeam.printSummary = "League Summary";
                    }
                }
            }

            //show the form
            this.match.Show();

            //disable all the controls on the form except the next string button
            foreach (Control c in this.Controls)
            {
                if (c.Name != "NextString")
                {
                    c.Enabled = false;
                }
            }

            firstTeam.bowlers[0].strings[currentString].game[0].DisplayBox.Focus();

            if (!foundJson)
            {
                Form scoreSheetInstructions = new scoreSheetInstr();
                scoreSheetInstructions.WindowState = FormWindowState.Maximized;
                scoreSheetInstructions.Show();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                this.match.BringToFront();
            }
        }

        private void displayTeam(Control teamArea, Team team)
        {
            int bowlerCount = 0;
            string controlName = "";
            TextBox tempTextBox = new TextBox();
            Label scoreInstructions = new Label();
            String scoreInstructionsText = "";

            if (firstTeam.bowlers.Count > 5)
            {
                offset_instructions = (15 + (60 * (firstTeam.bowlers.Count - 5)));
            }

            //is this the first string of the match?
            if (currentString == 0)
            {
                //set up the label for the bowler's handicap
                Label bowlerHDCP = new Label();
                bowlerHDCP.Size = new Size(200, 40);
                bowlerHDCP.Location = new Point(355, 10);
                bowlerHDCP.Text = "HDCP";
                bowlerHDCP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                bowlerHDCP.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
                teamArea.Controls.Add(bowlerHDCP);

                for (int x = 0; x < 10; x++)
                {
                    Label BoxNumLbl = new Label();
                    BoxNumLbl.Size = new Size(70, 40);
                    BoxNumLbl.Location = new Point((535 + (x * 106)), 10);
                    BoxNumLbl.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
                    BoxNumLbl.Text = (x + 1).ToString();
                    BoxNumLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    teamArea.Controls.Add(BoxNumLbl);
                }

                //set up the label for the string total
                Label stringTotalLabel = new Label();
                stringTotalLabel.Size = new Size(120, 40);
                stringTotalLabel.Location = new Point(1584, 10);
                stringTotalLabel.Text = "Total";
                stringTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                stringTotalLabel.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
                teamArea.Controls.Add(stringTotalLabel);
                
                //set up the label for the string total w/hdcp
                Label stringTotalHDCPLabel = new Label();
                stringTotalHDCPLabel.Size = new Size(150, 40);
                stringTotalHDCPLabel.Location = new Point(1718, 10);
                stringTotalHDCPLabel.Text = "HDCP";
                stringTotalHDCPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                stringTotalHDCPLabel.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
                teamArea.Controls.Add(stringTotalHDCPLabel);
                
                //set up the label for the previous strings area
                Label prevStringsLabel = new Label();
                prevStringsLabel.Size = new Size(350, 60);
                prevStringsLabel.Location = new Point(5, 622 + offset_instructions);
                prevStringsLabel.Text = "Previous Strings";
                prevStringsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                prevStringsLabel.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
                teamArea.Controls.Add(prevStringsLabel);

                //set up the label for the bowler match total
                Label bowlerTotalLabel = new Label();
                bowlerTotalLabel.Size = new Size(400, 60);
                bowlerTotalLabel.Location = new Point(1578, Convert.ToInt32(622 + offset_instructions));
                bowlerTotalLabel.Text = "Match Totals";
                bowlerTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                bowlerTotalLabel.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
                teamArea.Controls.Add(bowlerTotalLabel);

                //set up the label for how to view previous strings
                Label viewPreviousStrings = new Label();
                viewPreviousStrings.Size = new Size(1100, 60);
                viewPreviousStrings.Location = new Point(400, Convert.ToInt32(622 + offset_instructions));
                viewPreviousStrings.Text = "To view previous strings, use the page up and down keys.";
                viewPreviousStrings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                viewPreviousStrings.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);

                if (team.bowlers.Count > 5)
                {
                    viewPreviousStrings.Visible = true;
                }
                else
                {
                    viewPreviousStrings.Visible = false;
                }

                teamArea.Controls.Add(viewPreviousStrings);

                //if the team has more than one bowler we need to change the size of the box and the font so it stands out
                if (team.bowlers.Count > 1)
                {
                    Label teamTotalLabel = new Label();
                    teamTotalLabel.Size = new Size(400, 60);
                    teamTotalLabel.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                    teamTotalLabel.Location = new Point(1152, 465 + offset_instructions);
                    teamTotalLabel.Text = "Team Match Totals";
                    teamTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    teamArea.Controls.Add(teamTotalLabel);

                    Label teamStringTotalLabel = new Label();
                    teamStringTotalLabel.Size = new Size(400, 60);
                    teamStringTotalLabel.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                    teamStringTotalLabel.Location = new Point(1152, 394 + offset_instructions);
                    teamStringTotalLabel.Text = "Team String Totals";
                    teamStringTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    teamArea.Controls.Add(teamStringTotalLabel);
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
                    bowlerName.Location = new Point(10, 70);
                    prevStringsBowlerName.Location = new Point(10, (622 + (60 * bowlerCount) + offset_instructions));
                    if (!foundJson)
                    {
                        teamBowler.handicap.Text = Team2_Bowler1.Text;

                        try
                        {
                            teamBowler.int_handicap = int.Parse(Team2_Bowler1.Text);
                        }
                        catch
                        {
                            teamBowler.int_handicap = 0;
                        }
                    }

                    //set the display of the bowler's handicap
                    teamBowler.handicap.Location = new Point(400, 85);
                    teamBowler.handicap.Enabled = false;
                }
                //if this an additional bowler we need to calculate where in the control to display the information
                else
                {
                    bowlerName.Location = new Point(10, (15 + (60 * bowlerCount)));
                    prevStringsBowlerName.Location = new Point(10, (622 + (60 * bowlerCount) + offset_instructions));

                    controlName = "Team2_Bowler" + bowlerCount;
                    tempTextBox = (TextBox)this.Controls.Find(controlName, true)[0];

                    if (!foundJson)
                    {
                        teamBowler.handicap.Text = tempTextBox.Text;

                        try
                        {
                            teamBowler.int_handicap = int.Parse(tempTextBox.Text);
                        }
                        catch
                        {
                            teamBowler.int_handicap = 0;
                        }
                    }

                    //set the display of the bowler's handicap
                    teamBowler.handicap.Location = new Point(400, (25 + (60 * bowlerCount)));
                    teamBowler.handicap.Enabled = false;
                }

                teamArea.Controls.Add(teamBowler.handicap);

                //set up the label for the bowlers name
                bowlerName.Size = new Size(300, 70);
                prevStringsBowlerName.Size = new Size(300, 70);
                bowlerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                prevStringsBowlerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                bowlerName.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold);
                prevStringsBowlerName.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold);
                bowlerName.AutoSize = false;
                prevStringsBowlerName.AutoSize = false;

                //add the label to the team control.
                teamArea.Controls.Add(bowlerName);
                teamArea.Controls.Add(prevStringsBowlerName);

                //set the display location of the bowler's match total
                teamBowler.matchTotal.Location = new Point(1594, (632 + (60 * bowlerCount) + offset_instructions));
                teamBowler.matchTotal.LostFocus += new System.EventHandler(teamBowler.calcBowlerMatchTotal);
                teamBowler.matchTotal.TabStop = false;

                //teamBowler.matchTotalHDCP.Location = new Point(Convert.ToInt32(teamArea.Width * 0.90), (Convert.ToInt32(orig_form_hieght * 0.61) + (60 * bowlerCount) + offset_instructions));
                teamBowler.matchTotalHDCP.Location = new Point(1728, (632 + (60 * bowlerCount) + offset_instructions));
                teamBowler.matchTotalHDCP.TabStop = false;

                //add the bowler's match total to the team control
                teamArea.Controls.Add(teamBowler.matchTotal);
                teamArea.Controls.Add(teamBowler.matchTotalHDCP);

                //if the team has more than one bowler we need to setup the text box for the team total to be larger to hold more digits and to stand out
                if (team.bowlers.Count > 1)
                {
                    team.teamTotal.Size = new Size(100, 100);
                    team.teamTotal.TextAlign = HorizontalAlignment.Center;
                    team.teamTotal.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                    team.teamTotal.Location = new Point(1594, 465 + offset_instructions);
                    team.teamTotal.LostFocus += new System.EventHandler(team.Team_CalcTotal);
                    teamArea.Controls.Add(team.teamTotal);
                    team.teamTotal.TabStop = false;

                    team.teamTotalHDCP.Size = new Size(100, 100);
                    team.teamTotalHDCP.TextAlign = HorizontalAlignment.Center;
                    team.teamTotalHDCP.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                    team.teamTotalHDCP.Location = new Point(1728, 465 + offset_instructions);
                    team.teamTotalHDCP.LostFocus += new System.EventHandler(team.Team_CalcTotal);
                    team.teamTotalHDCP.Text = "0";
                    teamArea.Controls.Add(team.teamTotalHDCP);
                    team.teamTotalHDCP.TabStop = false;

                    team.teamStringTotal.TextAlign = HorizontalAlignment.Center;
                    team.teamStringTotal.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                    team.teamStringTotal.Location = new Point(1594, 394 + offset_instructions);
                    team.teamStringTotal.LostFocus += new System.EventHandler(team.Team_CalcTotal);
                    team.teamStringTotal.Size = new Size(100, 100);
                    team.teamStringTotal.Text = "0";
                    teamArea.Controls.Add(team.teamStringTotal);
                    team.teamStringTotal.TabStop = false;

                    team.teamStringTotalHDCP.Size = new Size(100, 100);
                    team.teamStringTotalHDCP.TextAlign = HorizontalAlignment.Center;
                    team.teamStringTotalHDCP.Font = new Font(FontFamily.GenericSansSerif, 40, FontStyle.Bold, GraphicsUnit.Pixel);
                    team.teamStringTotalHDCP.Location = new Point(1728, 394 + offset_instructions);
                    team.teamStringTotalHDCP.Text = "0";
                    team.teamStringTotalHDCP.LostFocus += new System.EventHandler(team.Team_CalcTotal);
                    teamArea.Controls.Add(team.teamStringTotalHDCP);
                    team.teamStringTotalHDCP.TabStop = false;
                }

            }

            //add instructions
            scoreInstructionsText = "If all pins are knocked down with one ball, enter a strike using 'x'.\n";
            scoreInstructionsText += "If all pins are knocked down with two balls, enter a spare using '/'.\n";
            scoreInstructionsText += "If three balls were thrown enter the score 0 - 9, '*' for a ten.\n";
            scoreInstructionsText += "Use arrows to navigate to frames needing score correcting.\n";
            scoreInstructionsText += "To correct a spare or strike, enter an 'r' in that frame to reset.\n";
            scoreInstructions.Visible = true;
            scoreInstructions.Text = scoreInstructionsText;
            scoreInstructions.Location = new Point(15, 394 + offset_instructions);
            scoreInstructions.Size = new Size(1100, 255);
            scoreInstructions.Font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold);
            teamArea.Controls.Add(scoreInstructions);

            //add a button to show the next string.
            Button nextString = new Button();
            nextString.Name = "NextStringBtn";
            nextString.Size = new Size(235, 50);
            nextString.BackColor = Color.White;
            nextString.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold, GraphicsUnit.Pixel);
            nextString.Location = new Point(1594, 540 + offset_instructions);
            nextString.Text = "Next String";
            nextString.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            nextString.Click += new System.EventHandler(NextString_OnClick);
            nextString.GotFocus += new System.EventHandler(NextString_GotFocus);
            nextString.LostFocus += new System.EventHandler(NextString_LostFocus);
            nextString.Show();
            teamArea.Controls.Add(nextString);

            //add a button to show the close the form when done bowling.
            Button doneBowling = new Button();
            doneBowling.Name = "DoneBowlingBtn";
            doneBowling.Size = new Size(235, 50);
            doneBowling.BackColor = Color.Yellow;
            doneBowling.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold, GraphicsUnit.Pixel);
            doneBowling.Location = new Point(1594, 540 + offset_instructions);
            doneBowling.Text = "Done Bowling";
            doneBowling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            doneBowling.Click += new System.EventHandler(CloseMatchForm_Onclick);
            doneBowling.GotFocus += new System.EventHandler(DoneBowling_GotFocus);
            doneBowling.LostFocus += new System.EventHandler(DoneBowling_LostFocus);
            doneBowling.Hide();
            teamArea.Controls.Add(doneBowling);

            if (!foundJson)
            {
                //add the strings for all the bowlers on team to the team area
                showNextString(teamArea, team);

                team.bowlers[0].strings[currentString].game[0].DisplayBox.Focus();
            }
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

        //close the form from a button.
        private void CloseMatchForm_Onclick(object sender, EventArgs e)
        {
            this.match.Close();
        }

        private void hidePreviousString(Team in_team)
        {
            //iterate through the bowlers of the team
            for (int i = 0; i < in_team.bowlers.Count; i++)
            {
                //iterate through the boxes of the string just finished for the bowler and hide them
                for (int y = 0; y < in_team.bowlers[i].strings[currentString - 1].game.Count; y++)
                {
                    in_team.bowlers[i].strings[currentString - 1].game[y].DisplayBox.Hide();
                }

                //move the string total for the bowler to the previous string area
                in_team.bowlers[i].strings[currentString - 1].stringTotal.Location = new Point(400 + (108 * currentString), (690 + (60 * i + 1) + offset_instructions));
                in_team.bowlers[i].strings[currentString - 1].totalHDCP.Hide();
                in_team.teamStringTotalHDCP.Text = "0";
                in_team.teamStringTotal.Text = "0";

                in_team.bowlers[i].strings[currentString - 1].stringTotal.Show();
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
                    in_team.bowlers[i].strings[currentString].game[boxIndex].DisplayBox.Location = new Point(510 + (108 * x), (25 + (60 * (i + 1))));

                    in_team.bowlers[i].strings[currentString].game[x].DisplayBox.TextChanged += new System.EventHandler((s, e) => in_team.bowlers[bowlerIndex].strings[currentString].String_KeyPress(s, e, in_team.bowlers[bowlerIndex].strings[currentString].game[boxIndex]));
                    in_team.bowlers[i].strings[currentString].game[x].DisplayBox.TextChanged += new System.EventHandler(in_team.bowlers[bowlerIndex].strings[currentString].BowlingString_CalcTotal);
                    in_team.bowlers[i].strings[currentString].game[x].DisplayBox.TextChanged += new System.EventHandler(in_team.bowlers[bowlerIndex].calcBowlerMatchTotal);
                    in_team.bowlers[i].strings[currentString].game[x].DisplayBox.TextChanged += new System.EventHandler(in_team.Team_CalcTotal);
                    in_team.bowlers[i].strings[currentString].game[x].DisplayBox.TextChanged += new System.EventHandler(this.Team_CalcStringTotal);
                    in_team.bowlers[i].strings[currentString].game[x].DisplayBox.TextChanged += new System.EventHandler((s, e) => in_team.Team_NextBowlersTurn(s, e, boxIndex, bowlerIndex, currentString, int.Parse(this.numBoxesPerTurn.Text)));
                    in_team.bowlers[i].strings[currentString].game[x].DisplayBox.KeyDown += new System.Windows.Forms.KeyEventHandler((s, e) => in_team.handleArrowsToNav(s, e, boxIndex, bowlerIndex, currentString));
                    in_team.bowlers[i].strings[currentString].game[x].DisplayBox.KeyDown += new System.Windows.Forms.KeyEventHandler(match.handlePageUpPageDown);
                    in_team.bowlers[i].strings[currentString].game[x].DisplayBox.TextChanged += new System.EventHandler(in_team.saveTeamStats);
                    in_team.bowlers[i].strings[currentString].game[x].DisplayBox.GotFocus += new System.EventHandler(highLightField);
                    in_team.bowlers[i].strings[currentString].game[x].DisplayBox.LostFocus += new System.EventHandler(unHighLightField);

                    //add the box to the team control
                    in_control.Controls.Add(in_team.bowlers[i].strings[currentString].game[x].DisplayBox);

                    if (!foundJson)
                    {
                        in_team.bowlers[i].strings[currentString].boxesPerTurn = int.Parse(this.numBoxesPerTurn.Text);
                    }
                }

                //set up the display information for the string total of the new string.
                //use offset of 11 since we know that all strings have 10 boxes and this will be after that
                in_team.bowlers[i].strings[currentString].stringTotal.Location = new Point(Convert.ToInt32(in_control.Width * 0.83), (25 + (60 * (i + 1))));
                in_team.bowlers[i].strings[currentString].stringTotal.Validated += new System.EventHandler(in_team.bowlers[i].strings[currentString].BowlingString_CalcTotal);
                in_team.bowlers[i].strings[currentString].stringTotal.Validated += new System.EventHandler(this.Team_CalcStringTotal);
                in_control.Controls.Add(in_team.bowlers[i].strings[currentString].stringTotal);
                in_team.bowlers[i].strings[currentString].stringTotal.TabStop = false;

                in_team.bowlers[i].strings[currentString].totalHDCP.Location = new Point(Convert.ToInt32(in_control.Width * 0.90), (25 + (60 * (i + 1))));
                in_team.bowlers[i].strings[currentString].totalHDCP.Validated += new System.EventHandler(in_team.bowlers[i].strings[currentString].BowlingString_CalcTotal);
                in_team.bowlers[i].strings[currentString].totalHDCP.Validated += new System.EventHandler(this.Team_CalcStringTotal);
                in_team.bowlers[i].strings[currentString].totalHDCP.TabStop = false;

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

                in_team.bowlers[in_team.bowlers.Count - 1].strings[currentString].game[9].DisplayBox.Validated += new System.EventHandler(this.Activate_NextStringButton);
            }

            Team_CalcStringTotal(new object(), new EventArgs());
            in_team.bowlers[0].strings[currentString].game[0].DisplayBox.Focus();
        }

        public void Team_CalcStringTotal(object sender, EventArgs e)
        {
            int temp_teamStringTotal = 0;
            int temp_teamStringTotalHDCP = 0;

            //iterate through all the bowlers match totals to get the team's total.
            for (int i = 0; i < firstTeam.bowlers.Count; i++)
            {
                if (firstTeam.bowlers[i].strings[currentString].stringTotal.Text != "")
                {
                    temp_teamStringTotal += int.Parse(firstTeam.bowlers[i].strings[currentString].stringTotal.Text);
                    temp_teamStringTotalHDCP += int.Parse(firstTeam.bowlers[i].strings[currentString].totalHDCP.Text);
                }
            }

            firstTeam.teamStringTotal.Text = temp_teamStringTotal.ToString();
            firstTeam.teamStringTotalHDCP.Text = temp_teamStringTotalHDCP.ToString();

        }

        public void Activate_NextStringButton(object sender, EventArgs e)
        {
            if (firstTeam.bowlers[firstTeam.bowlers.Count - 1].strings[currentString].game[9].DisplayBox.Text != "")
            {
                if (currentString < NumStrings.SelectedIndex)
                {
                    string controlName = "NextStringBtn";
                    Button tempButton = (Button)teamOne.Controls.Find(controlName, false)[0];
                    tempButton.Focus();
                    //tempButton.BackColor = Color.Yellow;
                }
                else
                {
                    string controlName = "NextStringBtn";
                    Button tempButton = (Button)teamOne.Controls.Find(controlName, false)[0];
                    tempButton.Hide();

                    controlName = "DoneBowlingBtn";
                    tempButton = (Button)teamOne.Controls.Find(controlName, false)[0];
                    tempButton.Show();
                    tempButton.Focus();
                }
            }
        }

        private void Help_OnClick(object sender, EventArgs e)
        {
            string Message = "*   Use the TAB key to go to the next field. Up and down arrows can be used in drop down fields. \n";
            Message += "*   Enter the names of the bowlers, if fewer than 7, leave fields blank. \n";
            Message += "*   Enter the handicap for each bowler bowling, if this is open bowling, you can leave them blank. \n";
            Message += "*   Select the number of strings to be bowled in the match. \n";
            Message += "*   Select the number of boxes each bowler will bowl during their turn. \n";
            Message += "*   When the information is correct, click/press enter on the Create Score Sheet button. \n";
            Message += "*   When done with each string, load the next string's score sheet using the Next String button. ";

            MessageBox.Show(Message, "How to keep score", MessageBoxButtons.OK);
        }

        public void resetMainForm(object sender, FormClosedEventArgs e)
        {

            string InprogressFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore", "Inprogress.json"); ;
            string fileName = "MatchComplete_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + ".json";

            string DoneFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore", "CompletedMatches", fileName);

            this.currentString = 0;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(Panel))
                {
                    ctrl.Enabled = true;

                    foreach (Control c in ctrl.Controls)
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
                }
            }

            this.Welcome.Text = this.welcomeStr;
            this.laneNumberTxt.Text = this.laneNumber.ToString();
            this.numBoxesPerTurn.SelectedItem = this.numBoxesTurn;

            try
            {
                if (File.Exists(InprogressFile))
                {
                    File.Copy(InprogressFile, DoneFile);
                    File.Delete(InprogressFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File clean up failed, please notify front desk: \n" + ex.Message);
            }

            this.WindowState = FormWindowState.Maximized;

            //Form startMenuInstructions = new startMenuInstr();
            //startMenuInstructions.Show();
        }

        public void highLightField(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl is TextBox || ctrl is Button)
            {
                ctrl.BackColor = Color.Yellow;
            }
            else
            {
                ComboBox tempDropDown = new ComboBox();
                tempDropDown = ctrl as ComboBox;
                tempDropDown.DroppedDown = true;
            }

        }

        public void unHighLightField(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            if (ctrl is TextBox || ctrl is Button)
            {
                ctrl.BackColor = Color.White;
            }
        }

        public void PrintSummary(object sender, FormClosedEventArgs e)
        {

            int stringTotal = 0;
            int bowlerMatchTotal = 0;
            int[] teamStringTotal = new int[7];
            int teamMatchTotal = 0;
            int fieldTarget = 11;
            int teamHDCP = 0;

            int stringCount = 0;
            int bowlerCount = 0;

            string teamScratchLine = "Team Total Scr.";
            string teamHDCPLine = "Team Total HDCP";
            string currentLine = "";

            string fileName = "BowlingMatch_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + ".txt";

            String stringPath = "";

            string output = "NAME\tHDCP\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\tTOTAL\tHDCP\n";
            output = output + "======================================================================================================================\n";

            if (firstTeam.printSummary == "League Summary")
            {
                stringPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore", "SummaryFiles", fileName);

                foreach (Bowler bowler in firstTeam.bowlers)
                {
                    stringCount = 0;

                    currentLine = currentLine + bowler.name;
                    currentLine = currentLine + "\t";
                    //currentLine = padString(currentLine, fieldTarget);
                    currentLine = currentLine + bowler.int_handicap.ToString();

                    teamHDCP = teamHDCP + bowler.int_handicap;

                    //advance the field target by 7 to set the place for the first string total
                    //fieldTarget = fieldTarget + 7;
                    //currentLine = padString(currentLine, fieldTarget);
                    currentLine = currentLine + "\t";

                    foreach (BowlingString strings in bowler.strings)
                    {
                        foreach (Box box in strings.game)
                        {
                            stringTotal = stringTotal + box.boxTotal;
                        }

                        bowlerMatchTotal = bowlerMatchTotal + stringTotal;
                        teamMatchTotal = teamMatchTotal + stringTotal;
                        teamStringTotal[stringCount] = teamStringTotal[stringCount] + stringTotal;

                        //write out the string total for this bowler's stringCount string.
                        currentLine = currentLine + stringTotal.ToString();

                        //advance the output field by 5 spaces for the next string
                        //fieldTarget = fieldTarget + 5;

                        //currentLine = padString(currentLine, fieldTarget);
                        currentLine = currentLine + "\t";

                        stringCount++;
                        stringTotal = 0;
                    }

                    //write out the scratch total for the bowler's match
                    //fieldTarget = fieldTarget + (((10 - bowler.strings.Count) * 5) + 3);
                    //currentLine = padString(currentLine, fieldTarget);
                    for (int x = stringCount; x < 10; x++)
                    {
                        currentLine = currentLine + "\t";
                    }
                    currentLine = currentLine + bowlerMatchTotal.ToString();

                    //write out the handicapped total for the bowler's match
                    //fieldTarget = fieldTarget + 8;
                    //currentLine = padString(currentLine, fieldTarget);
                    currentLine = currentLine + "\t";
                    bowlerMatchTotal = bowlerMatchTotal + (bowler.strings.Count * bowler.int_handicap);
                    currentLine = currentLine + bowlerMatchTotal.ToString();

                    currentLine = currentLine + "\n";

                    //Add current line to the output
                    output = output + currentLine;

                    //reinit vars to the starting values
                    stringTotal = 0;
                    bowlerMatchTotal = 0;
                    fieldTarget = 11;
                    currentLine = "";
                }

                output = output + "======================================================================================================================\n";

                //fieldTarget = 18;
                //teamScratchLine = padString(teamScratchLine, fieldTarget);
                //teamHDCPLine = padString(teamHDCPLine, fieldTarget);
                teamScratchLine = "Total Scratch\t\t";
                teamHDCPLine = "Total HDCP\t\t";

                for (int x = 0; x < teamStringTotal.Length; x++)
                {
                    if (teamStringTotal[x] > 0) { 
                        teamScratchLine = teamScratchLine + teamStringTotal[x].ToString();
                        teamHDCPLine = teamHDCPLine + (teamStringTotal[x] + teamHDCP).ToString();
                    }

                    //fieldTarget = fieldTarget + 5;
                    teamScratchLine = teamScratchLine + "\t";
                    teamHDCPLine = teamHDCPLine + "\t";

                    //teamScratchLine = padString(teamScratchLine, fieldTarget);
                    //teamHDCPLine = padString(teamHDCPLine, fieldTarget);
                }

                //write out the scrarch total for the team's match
                //fieldTarget = fieldTarget + (((10 - teamStringTotal.Length) * 5) + 3);
                //teamScratchLine = padString(teamScratchLine, fieldTarget);
                for (int x = teamStringTotal.Length; x < 10; x++)
                {
                    teamScratchLine = teamScratchLine + "\t";
                    teamHDCPLine = teamHDCPLine + "\t";
                }
                teamScratchLine = teamScratchLine + teamMatchTotal.ToString();
                teamScratchLine = teamScratchLine + "\n";

                //write out the handicapped total for the teams match
                //fieldTarget = fieldTarget + 8;
                //teamHDCPLine = padString(teamHDCPLine, fieldTarget);
                teamHDCPLine = teamHDCPLine + "\t";
                teamHDCPLine = teamHDCPLine + (teamMatchTotal + (teamHDCP * stringCount)).ToString();
                teamHDCPLine = teamHDCPLine + "\n";

                output = output + teamScratchLine;
                output = output + teamHDCPLine;

                output = output + "Mark points won \n";
                output = output + "with an X\t\t__\t__\t__\t__\t__\t__\t__\t__\t__\t__\t__\t__";

                File.WriteAllText(stringPath, output);
            }
            else if (firstTeam.printSummary == "Detailed (Strings)")
            {
                stringPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore", "DetailedFiles", fileName);

                foreach (Bowler bowler in firstTeam.bowlers)
                {
                    currentLine = currentLine + bowler.name;
                    currentLine = currentLine + "\t";
                    //currentLine = padString(currentLine, fieldTarget);
                    currentLine = currentLine + bowler.int_handicap.ToString();

                    teamHDCP = teamHDCP + bowler.int_handicap;

                    //advance the field target by 7 to set the place for the first string total
                    //fieldTarget = fieldTarget + 7;
                    //currentLine = padString(currentLine, fieldTarget);
                    currentLine = currentLine + "\t";

                    foreach (BowlingString strings in bowler.strings)
                    {
                        //write out each box of the string
                        foreach (Box box in strings.game)
                        {
                            currentLine = currentLine + "|";
                            if (box.isSpare)
                            {
                                currentLine = currentLine + "/";

                                if (box.markLoad < 10)
                                {
                                    currentLine = currentLine + "     " + box.markLoad;
                                }
                                else
                                {
                                    currentLine = currentLine + "    " + box.markLoad;
                                }
                            }
                            else if (box.isStrike)
                            {
                                currentLine = currentLine + "X";

                                if (box.markLoad < 10)
                                {
                                    currentLine = currentLine + "     " + box.markLoad;
                                }
                                else
                                {
                                    currentLine = currentLine + "    " + box.markLoad;
                                }
                            }
                            else
                            {
                                currentLine = currentLine + " ";

                                if (box.baseScore < 10)
                                {
                                    currentLine = currentLine + "     " + box.baseScore;
                                }
                                else
                                {
                                    currentLine = currentLine + "    " + box.baseScore;
                                }
                            }



                            if (box.boxNumber == 9)
                            {
                                currentLine = currentLine + "|";
                            }

                            stringTotal = stringTotal + box.boxTotal;
                        }

                        //write out the string total for this bowler's stringCount string.
                        currentLine = currentLine + "  " + stringTotal.ToString();

                        //write out the bowler's HDCP string total
                        currentLine = currentLine + "\t";
                        bowlerMatchTotal = bowlerMatchTotal + stringTotal;
                        currentLine = currentLine + (bowler.int_handicap + stringTotal).ToString();

                        stringCount++;
                        stringTotal = 0;

                        if (bowler.strings.Count != stringCount)
                        {
                            currentLine = currentLine + "\t\n\t\t";
                        }
                        else
                        {
                            currentLine = currentLine + "\n";
                        }
                    }

                    currentLine = currentLine + "======================================================================================================================\n";
                    currentLine = currentLine + "\t\t\t\t\t\t\t\t\t\t\t\t  ";
                    //write out the scratch total for the bowler's match
                    currentLine = currentLine + bowlerMatchTotal.ToString();

                    //write out the handicapped total for the bowler's match
                    currentLine = currentLine + "\t";
                    bowlerMatchTotal = bowlerMatchTotal + (bowler.strings.Count * bowler.int_handicap);
                    currentLine = currentLine + bowlerMatchTotal.ToString();

                    currentLine = currentLine + "\n\n\n";

                    //Add current line to the output
                    output = output + currentLine;

                    bowlerCount++;

                    if (firstTeam.bowlers.Count > bowlerCount)
                    {
                        output = output + "NAME\tHDCP\t1\t2\t3\t4\t5\t6\t7\t8\t9\t10\tTOTAL\tHDCP\n";
                        output = output + "======================================================================================================================\n";
                    }

                    //reinit vars to the starting values
                    stringCount = 0;
                    stringTotal = 0;
                    bowlerMatchTotal = 0;
                    fieldTarget = 11;
                    currentLine = "";
                }

                File.WriteAllText(stringPath, output);
            }

            //print the file we just created.
            try
            {
                if (stringPath != "")
                {
                    streamToPrint = new StreamReader(stringPath);

                    try
                    {
                        printFont = new Font("Arial", 10);
                        PrintDocument pd = new PrintDocument();
                        pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                        pd.Print();
                    }
                    finally
                    {
                        streamToPrint.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /*Function will append spaces to string. spacing is the total spaces from start of one field to the start of the next field.*/
        private string padString(string in_string, int target)
        {
            for (int x = in_string.Length; x < target; x++)
            {
                in_string = in_string + " ";
            }

            return in_string;
        }

        private void checkDirectories()
        {
            string RootPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore");
            string DonePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore", "CompletedMatches");
            string SummaryPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore", "SummaryFiles");
            string DetailedPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore", "DetailedFiles");


            if (!Directory.Exists(RootPath))
            {
                Directory.CreateDirectory(RootPath);
            }

            if (!Directory.Exists(DonePath))
            {
                Directory.CreateDirectory(DonePath);
            }

            if (!Directory.Exists(SummaryPath))
            {
                Directory.CreateDirectory(SummaryPath);
            }

            if (!Directory.Exists(DetailedPath))
            {
                Directory.CreateDirectory(DetailedPath);
            }
        }

        // The PrintPage event is raised for each page to be printed.
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = 0.118f;
            float topMargin = ev.MarginBounds.Top;
            string line = null;
            float[] tabStops = { 150.0f, 50.0f, 50.0f, 50.0f, 50.0f, 50.0f, 50.0f, 50.0f, 50.0f, 50.0f, 50.0f, 50.0f, 50.0f, 50.0f };
            StringFormat myStringFormat = new StringFormat();

            myStringFormat.SetTabStops(0.0f, tabStops);
            ev.PageSettings.Landscape = true;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            // Print each line of the file.
            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, myStringFormat);
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
            {
                ev.HasMorePages = true;
            }
            else
            {
                ev.HasMorePages = false;
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminLogin = new AdminLogin();
            adminLogin.Show();
        }

        private void NextString_GotFocus(object sender, EventArgs e)
        {
            string controlName = "NextStringBtn";
            Button tempButton = (Button)teamOne.Controls.Find(controlName, false)[0];
            tempButton.BackColor = Color.Yellow;
        }

        private void NextString_LostFocus(object sender, EventArgs e)
        {
            string controlName = "NextStringBtn";
            Button tempButton = (Button)teamOne.Controls.Find(controlName, false)[0];
            tempButton.BackColor = Color.White;
        }

        private void DoneBowling_GotFocus(object sender, EventArgs e)
        {
            string controlName = "DoneBowlingBtn";
            Button tempButton = (Button)teamOne.Controls.Find(controlName, false)[0];
            tempButton.BackColor = Color.Yellow;
        }

        private void DoneBowling_LostFocus(object sender, EventArgs e)
        {
            string controlName = "DoneBowlingBtn";
            Button tempButton = (Button)teamOne.Controls.Find(controlName, false)[0];
            tempButton.BackColor = Color.White;
        }
    }
}