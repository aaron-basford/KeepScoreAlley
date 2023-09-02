using System.Text.Json.Serialization;

namespace KeepScore
{
    [Serializable]
    internal class Box
    {
        public Label spareImgLabel = new Label();
        public Label strikeImgLabel = new Label();
        public Label DbleStrikeRightImglabel = new Label();
        public Label DbleStrikeLeftImglabel = new Label();

        Image strikeImg = KeepScore.Properties.Resources.Strike;
        Image spareImg = KeepScore.Properties.Resources.Spare;
        Image dblStrikeLeft = KeepScore.Properties.Resources.Dbl_Strike_Left;
        Image dblStrikeRight = KeepScore.Properties.Resources.Dbl_Strike_Right;

        [JsonInclude]
        public int baseScore;
        [JsonInclude]
        public int boxTotal;
        [JsonInclude]
        public Boolean isStrike;
        [JsonInclude]
        public Boolean isSpare;
        [JsonInclude]
        public int markLoad;
        [JsonInclude]
        public int boxNumber;

        public TextBox DisplayBox = new TextBox();

        [JsonConstructor]
        public Box(int baseScore, int boxTotal, Boolean isStrike, Boolean isSpare, int markLoad, int boxNumber) =>
            (this.baseScore, this.boxTotal, this.isStrike, this.isSpare, this.markLoad, this.boxNumber) = (baseScore, boxTotal, isStrike, isSpare, markLoad, boxNumber);

        public Box(int baseScore, int markLoad, int boxTotal, bool isStrike, bool isSpare)
        {
            this.baseScore = baseScore;
            this.markLoad = markLoad;
            this.boxTotal = boxTotal;
            this.isStrike = isStrike;
            this.isSpare = isSpare;

            DisplayBox.Size = new Size(100, 50);
        }

        public Box(int in_boxNumber)
        {
            //set default values for the box
            this.isStrike = false;
            this.isSpare = false;
            this.baseScore = 0;
            this.boxTotal = 0;
            this.markLoad = 0;
            this.boxNumber = in_boxNumber;

            formatBox();
        }

        public void formatBox()
        {
            //set the display size, font and alignment
            this.DisplayBox.Size = new Size(100, 50);
            this.DisplayBox.TextAlign = HorizontalAlignment.Center;
            this.DisplayBox.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold, GraphicsUnit.Point);

            //set up the image for a spare
            spareImgLabel.Image = spareImg;
            spareImgLabel.AutoSize = false;
            spareImgLabel.Size = new Size(20, 20);
            spareImgLabel.ImageAlign = ContentAlignment.MiddleCenter;
            spareImgLabel.Text = "";
            spareImgLabel.BackColor = Color.Transparent;
            spareImgLabel.Parent = this.DisplayBox;
            spareImgLabel.Location = new Point(0, 0);

            //set up the image for the strike
            strikeImgLabel.Image = strikeImg;
            strikeImgLabel.AutoSize = false;
            strikeImgLabel.Size = new Size(21, 21);
            strikeImgLabel.ImageAlign = ContentAlignment.MiddleCenter;
            strikeImgLabel.Text = "";
            strikeImgLabel.BackColor = Color.Transparent;
            strikeImgLabel.Parent = this.DisplayBox;
            strikeImgLabel.Location = new Point(75, 27);

            //set up the image for a double strike (only used in the last box)
            DbleStrikeRightImglabel.Image = dblStrikeRight;
            DbleStrikeRightImglabel.AutoSize = false;
            DbleStrikeRightImglabel.Size = new Size(20, 20);
            DbleStrikeRightImglabel.ImageAlign = ContentAlignment.MiddleCenter;
            DbleStrikeRightImglabel.Text = "";
            DbleStrikeRightImglabel.BackColor = Color.Transparent;
            DbleStrikeRightImglabel.Parent = this.DisplayBox;
            DbleStrikeRightImglabel.Location = new Point(75, 0);

            //set up the image for a double strike (only used in the last box)
            DbleStrikeLeftImglabel.Image = dblStrikeLeft;
            DbleStrikeLeftImglabel.AutoSize = false;
            DbleStrikeLeftImglabel.Size = new Size(21, 21);
            DbleStrikeLeftImglabel.ImageAlign = ContentAlignment.MiddleCenter;
            DbleStrikeLeftImglabel.Text = "";
            DbleStrikeLeftImglabel.BackColor = Color.Transparent;
            DbleStrikeLeftImglabel.Parent = this.DisplayBox;
            DbleStrikeLeftImglabel.Location = new Point(0, 27);

            //hide all the images so the box will displayed as blank.
            this.spareImgLabel.Hide();
            this.strikeImgLabel.Hide();
            this.DbleStrikeLeftImglabel.Hide();
            this.DbleStrikeRightImglabel.Hide();
        }

        public void setBaseScore(string in_score)
        {
            //if we are just cursoring through the boxes, don't process it again.
            if (markLoad.ToString() != DisplayBox.Text) { 
                //if the entered value is an R or an r then we need to reset the box to default values and hide images.
                if (in_score.ToUpper() == "R")
                {
                    this.baseScore = 0;
                    this.markLoad = 0;
                    isStrike = false;
                    isSpare = false;
                    this.spareImgLabel.Hide();
                    this.strikeImgLabel.Hide();
                    this.DbleStrikeLeftImglabel.Hide();
                    this.DbleStrikeRightImglabel.Hide();
                    DisplayBox.Text = "";
                    DisplayBox.Focus();
                }
                else
                {
                    //if this box isn't a strike or spare
                    if (!isStrike && !isSpare)
                    {
                        switch (in_score.ToUpper())
                        {
                            //if it's a strike set the base score to 10, so the strike images and set the strike flag
                            case "X":
                                this.baseScore = 10;
                                isStrike = true;
                                isSpare = false;
                                this.spareImgLabel.Show();
                                this.strikeImgLabel.Show();
                                DisplayBox.Text = "";
                                DisplayBox.Focus();
                                break;
                            //if it's a spare set the base score to 10, so the spare image and set the spare flag
                            case "/":
                                this.baseScore = 10;
                                isStrike = false;
                                isSpare = true;
                                this.spareImgLabel.Show();
                                DisplayBox.Text = "";
                                DisplayBox.Focus();
                                break;
                            case "S":
                                //this is score correct mode, don't do anything
                                break;
                            //it's neither a strike or a spare so it's an open box
                            default:
                                try
                                {
                                    //make sure we got a number
                                    this.baseScore = int.Parse(in_score);

                                    //if the entered value is a number but more than 10, show an error.
                                    if (this.baseScore > 10 || this.baseScore < 0)
                                    {
                                        this.baseScore = 0;
                                        DisplayBox.Text = "";
                                        DisplayBox.Focus();
                                        MessageBox.Show("Please enter a number that is 10 or less but greater than or equal to zero.", "Score Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                //if we didn't get a number, an r, a slash or an x then error
                                catch (Exception e)
                                {
                                    if (in_score != "")
                                    {
                                        this.baseScore = 0;
                                        DisplayBox.Text = "";
                                        MessageBox.Show("Please enter a number less than ten, an X (strike), a / (spare) or an R to reset the box.", "Score Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        DisplayBox.Focus();
                                    }
                                }

                                isStrike = false;
                                isSpare = false;
                                break;
                        }
                    }
                    //if this box already has a strike or spare
                    else
                    {
                        try
                        {
                            if (in_score.ToUpper() == "R" || in_score.ToUpper() == "X" || in_score.ToUpper() == "/" || (int.Parse(in_score) > -1 && int.Parse(in_score) < 21)) {
                            //if this a strike or spare and they put a strike or spare on it then set the mark load to 10
                                if (in_score.ToUpper() == "X" || in_score.ToUpper() == "/")
                                {
                                    in_score = "10";
                                }

                                //if the passed in score is ten or less and this is a strike with a load less than 20 or a spare with a load less than 10 then add
                                //the passed in value to mark load and set the text of this box to the mark load value
                                if (int.Parse(in_score) < 11 && ((this.isStrike && this.markLoad < 20) || (this.isSpare && this.markLoad < 10)))
                                {
                                    this.markLoad += int.Parse(in_score);
                                    DisplayBox.Text = markLoad.ToString();
                                }
                                else
                                {
                                    //if mark load and the passed in value aren't the same, reset the values as something went wrong
                                    //put the focus back in this box so the user can re-enter the score.
                                    if (int.Parse(in_score) != markLoad)
                                    {
                                        this.markLoad = 0;
                                        DisplayBox.Text = "";
                                        DisplayBox.Focus();
                                    }
                                    //everything is good, box is over so let's set the text of this box to the mark load value
                                    else
                                    {
                                        DisplayBox.Text = this.markLoad.ToString();
                                    }
                                }
                            }
                            else
                            {
                                DisplayBox.Text = "";
                                MessageBox.Show("The load must be between 0 and 9, or an X or / or an R to reset the box.", "Score Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DisplayBox.Focus();
                            }
                        }
                        catch (Exception e)
                        {
                            if (in_score != "")
                            {
                                this.baseScore = 0;
                                MessageBox.Show("Please enter a number less than ten, an X (strike), a / (spare) or an R to reset the box.", "Score Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DisplayBox.Focus();
                            }
                        }
                    }
                }

                //call the method to calculate the box total
                this.calcBoxTotal();
            }
        }

        public void calcBoxTotal()
        {
            //if the strike or spare flag is set, then the box total is 10 plus mark load
            if (this.isSpare || this.isStrike)
            {
                this.boxTotal = 10 + this.markLoad;
            }
            //it's an open box so the total score is the base score.
            else
            {
                this.boxTotal = this.baseScore;
            }
        }

        public void Box_TextChanged(object sender, EventArgs e)
        {
            if (DisplayBox.Text != "")
            {
                this.setBaseScore(DisplayBox.Text);
            }
        }
    }
}
