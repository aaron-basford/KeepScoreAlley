using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeepScore
{
    public partial class AdminLogin : Form
    {
        private SetDefaults setDefaults;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            if (this.PassWord.Text == "Fun2Bowl")
            {
                setDefaults = new SetDefaults();
                setDefaults.Show();

                this.Close();
            }
            else
            {
                this.PassWord.Text = "";
                this.PassWord.Focus();
            }
        }
    }
}
