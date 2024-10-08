﻿using System;
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

            this.Size = new Size(1900, 1000);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(10, 10);

            Label lblInstruction = new Label();
            Button close = new Button();

            string Message = "*   Use arrow keys to navigate from box to box when necessary.\n\n";
            Message += "*   The following inputs are allowed: \n";
            Message += "*      X - denotes a strike.\n";
            Message += "*      / - denotes a spare.\n";
            Message += "*      * - denotes a ten box.\n";
            Message += "*      Any number between 0 and 9.\n";
            Message += "*      R - Will reset the box, this is needed if a spare or strike need to be corrected.\n";
            Message += "*   To correct an open box, arrow to the box, use back space/delete and re-enter the score.\n";
            Message += "*   To correct a load/fill on a single mark, back space/delete the load/fill; re-enter the correct value.\n";
            Message += "*   To correct a load/fill on a double or triple (or more) strike, R option must be used.\n";
            Message += "*   To change a spare to a strike, strike to a spare or remove a mark, the R option must be used.\n";
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
