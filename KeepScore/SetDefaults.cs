using Microsoft.VisualBasic;
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
    public partial class SetDefaults : Form
    {
        public SetDefaults()
        {
            InitializeComponent();

            string fileLine = "";
            string[] strArray = { };
            string fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore", "keepscore.ini");

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
                    }
                    else if (strArray[0] == "BoxesPerTurn")
                    {
                        //this.numBoxesPerTurn.Text = strArray[1];
                        this.numBoxesPerTurn.SelectedItem = strArray[1];
                    }
                    else if (strArray[0] == "PrintSummary")
                    {
                        this.printSummary.SelectedItem = strArray[1];
                    }
                    else if (strArray[0] == "LaneNumber")
                    {
                        this.laneNumber.Text = strArray[1];
                    }
                }

                file.Close();
            }
        }

        private void SaveDefaults_Click(object sender, EventArgs e)
        {
            string fileLine = "";
            string destFileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore", "keepscore.ini");
            string cpyFileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "KeepScore", "keepscore.ini_old");
            int laneNumber = 0;

            try
            {
                laneNumber = Int32.Parse(this.laneNumber.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("The lane number found is not valid, please correct it.", "Error", MessageBoxButtons.OK);
            }

            if (laneNumber > 0 && laneNumber < 50){
                if (File.Exists(destFileName))
                {
                    File.Delete(cpyFileName);
                    File.Move(destFileName, cpyFileName);
                }

                fileLine = "Welcome::" + this.Welcome.Text + "\n";
                fileLine = fileLine + "BoxesPerTurn::" + this.numBoxesPerTurn.SelectedItem + "\n";
                fileLine = fileLine + "PrintSummary::" + this.printSummary.SelectedItem + "\n";
                fileLine = fileLine + "LaneNumber::" + this.laneNumber.Text + "\n";

                try
                {
                    File.WriteAllText(destFileName, fileLine);
                }
                catch (IOException)
                {
                    MessageBox.Show("There was an error when saving the settings file, please try again.", "Error", MessageBoxButtons.OK);
                }

                MessageBox.Show("The settings file was saved successfully.", "Success", MessageBoxButtons.OK);
            }
        }
    }
}
