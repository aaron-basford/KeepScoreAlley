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
    public partial class startMenuInstr : Form
    {
        public startMenuInstr()
        {
            InitializeComponent();

            this.Size = new Size(1900, 600);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(10, 10);

            Label lblInstruction = new Label();
            Button close = new Button();

            string Message = "*   Use the TAB key to go to the next field. Up and down arrows can be used in drop down fields.\n";
            Message += "*   Enter the names of the bowlers, if fewer than 7, leave fields blank.\n";
            Message += "*   Enter the handicap for each bowler bowling, if this is open bowling, you can leave them blank.\n";
            Message += "*   Select the number of strings to be bowled in the match.\n";
            Message += "*   Select the number of boxes each bowler will bowl during their turn.\n";
            Message += "*   When the information is correct, click/press enter on the Create Score Sheet button.\n";
            Message += "*   When done with each string, load the next string's score sheet using the Next String button.";

            close.Text = "Close";
            close.Size = new Size(200, 100);
            close.Font = new Font(FontFamily.GenericSerif, 30, FontStyle.Regular);
            close.Location = new Point(850, 400);
            close.Click += new System.EventHandler(Close_Form);
            close.Focus();

            lblInstruction.Text = Message;
            lblInstruction.Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold);
            lblInstruction.Size = new Size(1890, 400);

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
