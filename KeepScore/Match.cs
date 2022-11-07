using System.Windows.Forms;

namespace KeepScore
{
    public partial class Match : Form
    {
        public Match()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
        }

        private void Match_Load(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form scoreSheetInstructions = new scoreSheetInstr();

            scoreSheetInstructions.Show();
        }
    }
}
