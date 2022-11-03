using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeepScore
{
    public partial class scoreSheetInstr : Form
    {
        public scoreSheetInstr()
        {
            InitializeComponent();

            this.Size = new Size(1900, 900);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(10, 10);

            Label lblInstruction = new Label();
            Button close = new Button();

            string Message = "*   Press the TAB key when done entering the score for the box.\n\n";
            Message += "*   The following inputs are allowed: \n";
            Message += "*      X - denotes a strike.\n";
            Message += "*      / - denotes a spare.\n";
            Message += "*      R - Will reset the box, this is needed if a spare or strike need to be corrected.\n";
            Message += "*      S - Enter/exit score correct mode\n";
            Message += "*      Any number between 0 and 10.\n";
            Message += "*   To correct an open box, just back space over the number in the box and re-enter the score.\n";
            Message += "*   To correct a load/fill on a single mark, back space/delete the load/fill; re-enter the correct value.\n";
            Message += "*   To change a spare to a strike, strike to a spare or remove a mark, the R option must be used.\n";
            Message += "*   To move the cusor forward a box use TAB, to move the cursor back a box use SHIFT-TAB.\n";
            Message += "*   If you need these insructions again, click the word 'Help' in the upper left corner.\n";

            close.Text = "Close";
            close.Size = new Size(200, 100);
            close.Font = new Font(FontFamily.GenericSerif, 30, FontStyle.Regular);
            close.Location = new Point(850, 700);
            close.Click += new System.EventHandler(Close_Form);
            close.Focus();

            lblInstruction.Text = Message;
            lblInstruction.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
            lblInstruction.Size = new Size(1890, 600);

            this.Controls.Add(lblInstruction);
            lblInstruction.Show();
            this.Controls.Add(close);
            close.Show();
            this.Show();
        }

        public void Close_Form(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
