namespace KeepScore
{
    public partial class Match : Form
    {
        public Match()
        {
            InitializeComponent();
        }

        private void Match_Load(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string Message = "Press the TAB key when done entering the score for the box.\n\n";
            Message += "The following inputs are allowed: \n";
            Message += "*   X - denotes a strike\n";
            Message += "*   / - denotes a spare\n";
            Message += "*   R - Will reset the box, this is needed if a spare or strike need to be corrected\n";
            Message += "*   Any number 10 or under\n";
            Message += "*   To correct an open box, just back space over the number in the box and re-enter the score\n";
            Message += "*   To correct a load/fill on a singe mark, back space or delete the load/fill and re-enter the correct value\n";
            Message += "*   To change a spare into a strike or strike into a spare or remove a mark, the R option must be used";

            MessageBox.Show(Message, "How to keep score", MessageBoxButtons.OK);
        }
    }
}
