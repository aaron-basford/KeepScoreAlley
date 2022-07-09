using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            for(int i = 0; i < 10; i++)
            {
                game.Add(new Box(i));
            }
        }

        public int Calc_Total() {

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
                if ((in_box.isSpare && in_box.Text.ToUpper() == "X") || (in_box.isStrike && in_box.Text.ToUpper() == "/"))
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
                        in_box.setBaseScore("10");
                    }
                    else if (this.game[in_box.boxNumber + 1].isStrike)
                    {
                        if (in_box.boxNumber < 8)
                        {
                            this.game[in_box.boxNumber + 2].setBaseScore(in_box.Text);
                            this.game[in_box.boxNumber + 1].setBaseScore(in_box.Text);
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
                }
            }
        }
    }
}
