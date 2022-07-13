namespace KeepScore
{
    internal class BowlingString
    {
        public List<Box> game;

        public TextBox stringTotal = new TextBox();

        public BowlingString()
        {
            this.stringTotal.Size = new Size(35, 35);
            this.stringTotal.TextAlign = HorizontalAlignment.Center;
            this.stringTotal.Text = "0";
            this.stringTotal.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);

            game = new List<Box>();

            for (int i = 0; i < 10; i++)
            {
                game.Add(new Box(i));
            }
        }

        public int Calc_Total()
        {

            int total = 0;

            for (int x = 0; x < game.Count; x++)
            {
                total += game[x].boxTotal;
            }

            return total;
        }

        public void BowlingString_CalcTotal(object sender, EventArgs e)
        {
            int total = 0;

            for (int x = 0; x < game.Count; x++)
            {
                total += game[x].boxTotal;
            }

            this.stringTotal.Text = total.ToString();
        }

        public delegate void StringBoxTextChanged(Box in_box);

        public void String_BoxTextChanged(object sender, EventArgs e, Box in_box)
        {
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
                else if ((in_box.isSpare && in_box.Text.ToUpper() == "X") || (in_box.isStrike && in_box.Text.ToUpper() == "/"))
                {
                    //is this the last box of the string?
                    if (in_box.boxNumber == 9)
                    {
                        in_box.setBaseScore("10");
                    }
                    else
                    {
                        this.game[in_box.boxNumber + 1].setBaseScore(in_box.Text);
                        in_box.setBaseScore("10");
                    }
                }
                else if (in_box.isStrike && in_box.Text.ToUpper() == "X")
                {
                    if (in_box.boxNumber == 9)
                    {
                        if (in_box.markLoad < 20)
                        {
                            in_box.setBaseScore("10");
                            in_box.Text = "";
                            in_box.Focus();
                        }

                        if (in_box.markLoad > 10)
                        {
                            in_box.Text = in_box.markLoad.ToString();
                        }
                    }
                    else if (this.game[in_box.boxNumber + 1].isStrike)
                    {
                        if (in_box.boxNumber < 8)
                        {
                            this.game[in_box.boxNumber + 2].setBaseScore(in_box.Text);
                            this.game[in_box.boxNumber + 1].setBaseScore(in_box.Text);
                            this.game[in_box.boxNumber + 1].Text = "";
                            this.game[in_box.boxNumber + 1].Focus();
                            in_box.setBaseScore("10");
                        }
                        else
                        {
                            this.game[in_box.boxNumber + 1].setBaseScore("10");
                            in_box.setBaseScore("10");
                            in_box.Text = "";
                        }

                        if (in_box.markLoad < 11)
                        {
                            in_box.Focus();
                        }
                    }
                    else
                    {
                        this.game[in_box.boxNumber + 1].setBaseScore(in_box.Text);
                        in_box.setBaseScore("10");
                        in_box.Text = "";
                        in_box.Focus();
                    }
                }
                else
                {
                    in_box.setBaseScore(in_box.Text);

                    if (((!in_box.isSpare && !in_box.isStrike) || ((in_box.isSpare || in_box.isStrike) && in_box.Text != "")) && in_box.boxNumber < 9)
                    {
                        this.game[in_box.boxNumber + 1].Focus();
                    }
                    else if (in_box.boxNumber == 9)
                    {
                        this.stringTotal.Focus();
                    }
                }
            }
        }

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
