namespace KeepScore
{
    internal class BowlingString
    {
        public List<Box> game;

        public TextBox stringTotal = new TextBox();
        public TextBox totalHDCP = new TextBox();
        public int HDCP = 0;
        public int boxesPerTurn = 1;

        public BowlingString()
        {
            //set the display size and location of the string total textbox
            this.stringTotal.Size = new Size(100, 50);
            this.stringTotal.TextAlign = HorizontalAlignment.Center;
            this.stringTotal.Text = "0";
            this.stringTotal.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);

            this.totalHDCP.Size = new Size(100, 50);
            this.totalHDCP.TextAlign = HorizontalAlignment.Center;
            this.totalHDCP.Text = "0";
            this.totalHDCP.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);

            game = new List<Box>();

            //add 10 new boxes to the string
            for (int i = 0; i < 10; i++)
            {
                game.Add(new Box(i));
            }
        }

        public int Calc_Total()
        {

            int total = 0;

            //itertate through all the boxes and add them up to get the string total.
            for (int x = 0; x < game.Count; x++)
            {
                total += game[x].boxTotal;
            }

            return total;
        }

        public void BowlingString_CalcTotal(object sender, EventArgs e)
        {
            int total = 0;

            //itertate through all the boxes and add them up to get the string total.
            for (int x = 0; x < game.Count; x++)
            {
                total += game[x].boxTotal;
            }

            this.stringTotal.Text = total.ToString();

            total += HDCP;

            this.totalHDCP.Text = total.ToString();
        }

        public delegate void StringBoxTextChanged(Box in_box);

        public void String_BoxTextChanged(object sender, EventArgs e, Box in_box)
        {
            Boolean error = false;
            string errMsg = "";

            if (in_box.Text != "")
            {
                //if we are resetting the box and this box is a spare or strike we have some decisions to make
                //Otherwise we'll let this box reset itself
                if (in_box.Text.ToUpper() == "R" && (in_box.isSpare || in_box.isStrike))
                {
                    //if the previous box is spare or strike we need to subtract ten from the markLoad prop and give that box focus.
                    //Unless this is the first box of the string, then we just reset this box.
                    if (in_box.boxNumber > 0 && (this.game[in_box.boxNumber - 1].isStrike || this.game[in_box.boxNumber - 1].isSpare))
                    {
                        //if the previous box is a strike, we need to look at the box before that, if it's a strike then we need to subtract
                        //ten from markLoad of that box and give it focus
                        //Unless this is the second box of the string, then we only need to worry about the previous box
                        if (in_box.boxNumber > 1 && this.game[in_box.boxNumber - 1].isStrike && this.game[in_box.boxNumber - 2].isStrike && in_box.isStrike)
                        {
                            //reset the box we are on
                            in_box.setBaseScore(in_box.Text);

                            //reset the previous box
                            //this.game[in_box.boxNumber - 1].setBaseScore("-10");
                            this.game[in_box.boxNumber - 1].markLoad = 0;
                            this.game[in_box.boxNumber - 1].Text = "";
                            this.game[in_box.boxNumber - 1].calcBoxTotal();

                            //reset the box before that
                            //this.game[in_box.boxNumber - 2].setBaseScore("-10");
                            this.game[in_box.boxNumber - 2].markLoad = 10;
                            this.game[in_box.boxNumber - 2].Text = "";
                            this.game[in_box.boxNumber - 2].calcBoxTotal();
                            this.game[in_box.boxNumber - 2].Focus();
                        }
                        //the previous box is a spare so just deal with that.
                        else
                        {
                            //reset the box we are on
                            in_box.setBaseScore(in_box.Text);

                            //reset the previous box
                            //this.game[in_box.boxNumber - 1].setBaseScore("-10");
                            this.game[in_box.boxNumber - 1].markLoad = 0;
                            this.game[in_box.boxNumber - 1].Text = "";
                            this.game[in_box.boxNumber - 1].calcBoxTotal();
                            this.game[in_box.boxNumber - 1].Focus();
                        }
                    }
                    else
                    {
                        //reset the previous box
                        in_box.setBaseScore(in_box.Text);
                    }
                }
                //are we on a spare and they loaded it with a strike or a strike and they loaded it with a spare?
                else if ((in_box.isSpare && in_box.Text.ToUpper() == "X") || (in_box.isStrike && in_box.Text.ToUpper() == "/"))
                {
                    //is this the last box of the string?
                    if (in_box.boxNumber == 9)
                    {
                        in_box.setBaseScore("10");
                    }
                    else
                    {
                        //set the score for the next box
                        this.game[in_box.boxNumber + 1].setBaseScore(in_box.Text);
                        //set this boxes base score, this should already be set, but let's be sure
                        in_box.setBaseScore("10");
                    }
                }
                //are we on a strike and they loaded it with another strike? AKA double/triple strike
                else if (in_box.isStrike && in_box.Text.ToUpper() == "X")
                {
                    //if this is the last box of the string we need to do special stuff as there isn't another box to worry about
                    if (in_box.boxNumber == 9)
                    {
                        //if the mark load is less than 20 then this must be double strike
                        //so set the base score for the box to 10, blank out the text so the user can enter the last ball
                        //display the double strike images (upper right and lower left)
                        //put the curor back in the last box so the last ball can be entered.
                        if (in_box.markLoad < 20)
                        {
                            in_box.setBaseScore("10");
                            in_box.Text = "";
                            in_box.DbleStrikeRightImglabel.Show();
                            in_box.DbleStrikeLeftImglabel.Show();
                            in_box.Focus();
                        }

                        //if mark load is greater than 10, then the string is over, put the load value in the box and move focus to the string total
                        if (in_box.markLoad > 10)
                        {
                            in_box.Text = (in_box.markLoad - 10).ToString();
                            this.stringTotal.Focus();
                        }
                    }
                    //if this is the ninth box and this box has a strike in it, then we have a double or triple strike situation
                    else if (in_box.boxNumber == 8 && in_box.isStrike)
                    {
                        //the mark load is zero then it's a double strike.
                        //call the set base score method for this box and the next box so base and mark load values get set.
                        if (in_box.markLoad == 0)
                        {
                            in_box.setBaseScore(in_box.Text);
                            this.game[in_box.boxNumber + 1].setBaseScore("X");
                            in_box.Text = "";
                            in_box.Focus();
                        }
                        //The mark load is not 0 so this must be a triple strike 
                        //so call the set base score for this and the next box
                        //set the double strike images for the last (next) box
                        //set the focus to the last (next) box so the user can enter the score for the last ball
                        else
                        {
                            in_box.setBaseScore(in_box.Text);
                            this.game[in_box.boxNumber + 1].setBaseScore("X");
                            this.game[in_box.boxNumber + 1].Text = "";
                            this.game[in_box.boxNumber + 1].DbleStrikeRightImglabel.Show();
                            this.game[in_box.boxNumber + 1].DbleStrikeLeftImglabel.Show();
                            in_box.Text = in_box.markLoad.ToString();
                            this.game[in_box.boxNumber + 1].Focus();
                        }
                    }
                    //This isn't the last box, nor the next to last box, but the next box already has a strike, so this is a triple strike situation.
                    else if (this.game[in_box.boxNumber + 1].isStrike)
                    {
                        //if the box isn't the ninth one (it shouldn't be, but let's be extra careful)
                        //call the set base score method for the box two boxes ahead
                        //call the set base score method for the next and this box.
                        //let's put the cursor in the next box so the user can enter the score for the last ball of that box.
                        if (in_box.boxNumber < 8)
                        {
                            this.game[in_box.boxNumber + 2].setBaseScore(in_box.Text);
                            this.game[in_box.boxNumber + 1].setBaseScore(in_box.Text);
                            this.game[in_box.boxNumber + 1].Text = "";
                            this.game[in_box.boxNumber + 1].Focus();
                            in_box.setBaseScore("10");
                        }
                        //This is the ninth box (we shouldn't hit this, but let's be careful)
                        //call the set base score method for the next (last) box
                        else
                        {
                            this.game[in_box.boxNumber + 1].setBaseScore("10");
                            in_box.setBaseScore("10");
                            in_box.Text = "";
                        }

                        //if mark load is ten or less, this must be a double strike, so set the focus to this box 
                        //so the user can enter the last ball of this box
                        if (in_box.markLoad < 11)
                        {
                            in_box.Focus();
                        }
                    }
                    //This must a double strike with no special conditions
                    //so call set base score method for the next box and this box and set the 
                    //focus so the user can enter the last ball of this box.
                    else
                    {
                        this.game[in_box.boxNumber + 1].setBaseScore(in_box.Text);
                        in_box.setBaseScore("10");
                        in_box.Text = "";
                        in_box.Focus();
                    }
                }
                //so we aren't resetting the box and this isn't a strike on a spare, spare on a strike or a double/triple strike
                else
                {
                    //if this box has a strike or spare in it, but the previous box has a spare or strike with a load on it
                    //then the user has made a mistake and we need to let them know.
                    if (
                        (in_box.boxNumber > 0)
                        && ((in_box.Text.ToUpper() == "X" && (this.game[in_box.boxNumber - 1].isSpare || this.game[in_box.boxNumber - 1].isStrike) && this.game[in_box.boxNumber - 1].markLoad > 0) 
                        || (in_box.Text.ToUpper() == "/" && (this.game[in_box.boxNumber - 1].isStrike) && this.game[in_box.boxNumber - 1].markLoad > 0))
                        )
                    {
                        //figure out the appropriate error message to display to the user/
                        if (in_box.Text.ToUpper() == "/")
                        {
                            errMsg = "The previous box has a strike with a load on it, this box must be an open box.";
                        }
                        else
                        {
                            errMsg = "The previous box has a spare with a load on it, this box must be a spare or an open box.";
                        }

                        MessageBox.Show(errMsg, "Score Entry Error", MessageBoxButtons.OK);
                        in_box.Text = "";
                        in_box.Focus();
                        error = true;
                    }
                    //all is good, call the set base score method we update everything ok.
                    else
                    {
                        in_box.setBaseScore(in_box.Text);
                    }

                    //if there was no error and this box is done set the focus to the next box.
                    if (!error && ((!in_box.isSpare && !in_box.isStrike) || ((in_box.isSpare || in_box.isStrike) && in_box.Text != "")) && in_box.boxNumber < 9)
                    {
                        this.game[in_box.boxNumber + 1].Focus();
                    }
                    //if there was no error and this is the last box and we are done with it, set the focus to the string total text box.
                    else if (!error && in_box.boxNumber == 9 && ((!in_box.isSpare && !in_box.isStrike) || ((in_box.isStrike || in_box.isSpare) && in_box.markLoad != 0)))
                    {
                        this.stringTotal.Focus();
                    }
                }
            }
        }

        //Eventually I want to get this working so the users can use the enter key as well as the tab key, but I'm having an issue getting it to work.
        public void String_KeyPress(object sender, KeyEventArgs e, Box in_box)
        {
            int outParse;

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if ((in_box.Text == "/" || in_box.Text.ToUpper() == "X" || in_box.Text.ToUpper() == "R") || int.TryParse(in_box.Text, out outParse))
                {
                    String_BoxTextChanged(sender, new EventArgs(), in_box);
                    BowlingString_CalcTotal(sender, new EventArgs());
                }
                else
                {
                    in_box.baseScore = 0;
                    in_box.Text = "";
                    MessageBox.Show("Please enter a number less than ten, an X (strike), a / (spare) or an R to reset the box.", "Score Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    in_box.Focus();
                }
            }
        }
    }
}
