namespace KeepScore
{
    partial class Main_Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            CreateMatch = new Button();
            NextString = new Button();
            menuStrip = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            adminToolStripMenuItem = new ToolStripMenuItem();
            Welcome = new TextBox();
            lbl_NumStrings = new Label();
            NumStrings = new ComboBox();
            Team1_Bowler1 = new TextBox();
            Team1_Bowler2 = new TextBox();
            Team1_Bowler3 = new TextBox();
            Team1_Bowler4 = new TextBox();
            Team1_Bowler5 = new TextBox();
            Team2_Bowler1 = new TextBox();
            Team2_Bowler2 = new TextBox();
            Team2_Bowler3 = new TextBox();
            Team2_Bowler4 = new TextBox();
            Team2_Bowler5 = new TextBox();
            lbl_BowlersNames = new Label();
            lbl_BowlersHDCP = new Label();
            lbl_numBoxesTurn = new Label();
            numBoxesPerTurn = new ComboBox();
            PrintSummaryLbl = new Label();
            Instructions = new RichTextBox();
            printSummary = new ComboBox();
            panel1 = new Panel();
            laneNumberlbl = new Label();
            laneNumberTxt = new TextBox();
            Team2_Bowler6 = new TextBox();
            Team1_Bowler6 = new TextBox();
            Team2_Bowler7 = new TextBox();
            Team1_Bowler7 = new TextBox();
            LeagueOnly = new Label();
            menuStrip.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // CreateMatch
            // 
            CreateMatch.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            CreateMatch.Location = new Point(649, 741);
            CreateMatch.Name = "CreateMatch";
            CreateMatch.Size = new Size(436, 70);
            CreateMatch.TabIndex = 17;
            CreateMatch.Text = "Create Score Sheet";
            CreateMatch.Click += CreateButton_OnClick;
            // 
            // NextString
            // 
            NextString.Location = new Point(1151, 755);
            NextString.Name = "NextString";
            NextString.Size = new Size(187, 23);
            NextString.TabIndex = 30;
            NextString.Text = "Next String";
            NextString.Visible = false;
            NextString.Click += NextString_OnClick;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1474, 24);
            menuStrip.TabIndex = 2;
            menuStrip.Text = "menuStrip";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { adminToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(110, 22);
            adminToolStripMenuItem.Text = "Admin";
            adminToolStripMenuItem.Click += adminToolStripMenuItem_Click;
            // 
            // Welcome
            // 
            Welcome.BackColor = Color.CadetBlue;
            Welcome.BorderStyle = BorderStyle.None;
            Welcome.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            Welcome.Location = new Point(31, 111);
            Welcome.Name = "Welcome";
            Welcome.ReadOnly = true;
            Welcome.Size = new Size(1194, 86);
            Welcome.TabIndex = 40;
            Welcome.TabStop = false;
            Welcome.TextAlign = HorizontalAlignment.Center;
            // 
            // lbl_NumStrings
            // 
            lbl_NumStrings.AutoSize = true;
            lbl_NumStrings.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_NumStrings.Location = new Point(121, 585);
            lbl_NumStrings.Name = "lbl_NumStrings";
            lbl_NumStrings.Size = new Size(349, 54);
            lbl_NumStrings.TabIndex = 4;
            lbl_NumStrings.Text = "Number of Strings";
            // 
            // NumStrings
            // 
            NumStrings.DropDownStyle = ComboBoxStyle.DropDownList;
            NumStrings.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            NumStrings.FormattingEnabled = true;
            NumStrings.ItemHeight = 54;
            NumStrings.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            NumStrings.Location = new Point(482, 582);
            NumStrings.Name = "NumStrings";
            NumStrings.Size = new Size(121, 62);
            NumStrings.TabIndex = 14;
            // 
            // Team1_Bowler1
            // 
            Team1_Bowler1.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team1_Bowler1.Location = new Point(288, 428);
            Team1_Bowler1.Name = "Team1_Bowler1";
            Team1_Bowler1.Size = new Size(175, 61);
            Team1_Bowler1.TabIndex = 0;
            // 
            // Team1_Bowler2
            // 
            Team1_Bowler2.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team1_Bowler2.Location = new Point(469, 428);
            Team1_Bowler2.Name = "Team1_Bowler2";
            Team1_Bowler2.Size = new Size(171, 61);
            Team1_Bowler2.TabIndex = 1;
            // 
            // Team1_Bowler3
            // 
            Team1_Bowler3.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team1_Bowler3.Location = new Point(646, 428);
            Team1_Bowler3.Name = "Team1_Bowler3";
            Team1_Bowler3.Size = new Size(152, 61);
            Team1_Bowler3.TabIndex = 2;
            // 
            // Team1_Bowler4
            // 
            Team1_Bowler4.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team1_Bowler4.Location = new Point(804, 428);
            Team1_Bowler4.Name = "Team1_Bowler4";
            Team1_Bowler4.Size = new Size(171, 61);
            Team1_Bowler4.TabIndex = 3;
            // 
            // Team1_Bowler5
            // 
            Team1_Bowler5.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team1_Bowler5.Location = new Point(981, 428);
            Team1_Bowler5.Name = "Team1_Bowler5";
            Team1_Bowler5.Size = new Size(152, 61);
            Team1_Bowler5.TabIndex = 4;
            // 
            // Team2_Bowler1
            // 
            Team2_Bowler1.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team2_Bowler1.Location = new Point(288, 495);
            Team2_Bowler1.Name = "Team2_Bowler1";
            Team2_Bowler1.Size = new Size(175, 61);
            Team2_Bowler1.TabIndex = 7;
            // 
            // Team2_Bowler2
            // 
            Team2_Bowler2.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team2_Bowler2.Location = new Point(469, 495);
            Team2_Bowler2.Name = "Team2_Bowler2";
            Team2_Bowler2.Size = new Size(171, 61);
            Team2_Bowler2.TabIndex = 8;
            // 
            // Team2_Bowler3
            // 
            Team2_Bowler3.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team2_Bowler3.Location = new Point(646, 495);
            Team2_Bowler3.Name = "Team2_Bowler3";
            Team2_Bowler3.Size = new Size(152, 61);
            Team2_Bowler3.TabIndex = 9;
            // 
            // Team2_Bowler4
            // 
            Team2_Bowler4.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team2_Bowler4.Location = new Point(804, 495);
            Team2_Bowler4.Name = "Team2_Bowler4";
            Team2_Bowler4.Size = new Size(171, 61);
            Team2_Bowler4.TabIndex = 10;
            // 
            // Team2_Bowler5
            // 
            Team2_Bowler5.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team2_Bowler5.Location = new Point(981, 495);
            Team2_Bowler5.Name = "Team2_Bowler5";
            Team2_Bowler5.Size = new Size(152, 61);
            Team2_Bowler5.TabIndex = 11;
            // 
            // lbl_BowlersNames
            // 
            lbl_BowlersNames.AutoSize = true;
            lbl_BowlersNames.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_BowlersNames.Location = new Point(-3, 431);
            lbl_BowlersNames.Name = "lbl_BowlersNames";
            lbl_BowlersNames.Size = new Size(285, 54);
            lbl_BowlersNames.TabIndex = 35;
            lbl_BowlersNames.Text = "Bowler's Name";
            // 
            // lbl_BowlersHDCP
            // 
            lbl_BowlersHDCP.AutoSize = true;
            lbl_BowlersHDCP.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_BowlersHDCP.Location = new Point(-3, 498);
            lbl_BowlersHDCP.Name = "lbl_BowlersHDCP";
            lbl_BowlersHDCP.Size = new Size(283, 54);
            lbl_BowlersHDCP.TabIndex = 36;
            lbl_BowlersHDCP.Text = "Bowler's HDCP";
            // 
            // lbl_numBoxesTurn
            // 
            lbl_numBoxesTurn.AutoSize = true;
            lbl_numBoxesTurn.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_numBoxesTurn.Location = new Point(690, 585);
            lbl_numBoxesTurn.Name = "lbl_numBoxesTurn";
            lbl_numBoxesTurn.Size = new Size(488, 54);
            lbl_numBoxesTurn.TabIndex = 37;
            lbl_numBoxesTurn.Text = "Number of Boxes Per Turn";
            // 
            // numBoxesPerTurn
            // 
            numBoxesPerTurn.DropDownStyle = ComboBoxStyle.DropDownList;
            numBoxesPerTurn.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            numBoxesPerTurn.FormattingEnabled = true;
            numBoxesPerTurn.ItemHeight = 54;
            numBoxesPerTurn.Items.AddRange(new object[] { "0", "1", "2", "5", "10" });
            numBoxesPerTurn.Location = new Point(1184, 582);
            numBoxesPerTurn.Name = "numBoxesPerTurn";
            numBoxesPerTurn.Size = new Size(121, 62);
            numBoxesPerTurn.TabIndex = 15;
            // 
            // PrintSummaryLbl
            // 
            PrintSummaryLbl.AutoSize = true;
            PrintSummaryLbl.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            PrintSummaryLbl.Location = new Point(460, 661);
            PrintSummaryLbl.Name = "PrintSummaryLbl";
            PrintSummaryLbl.Size = new Size(282, 54);
            PrintSummaryLbl.TabIndex = 38;
            PrintSummaryLbl.Text = "Print Summary";
            // 
            // Instructions
            // 
            Instructions.BackColor = Color.CadetBlue;
            Instructions.BorderStyle = BorderStyle.None;
            Instructions.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            Instructions.Location = new Point(155, 190);
            Instructions.Name = "Instructions";
            Instructions.ReadOnly = true;
            Instructions.Size = new Size(1194, 238);
            Instructions.TabIndex = 39;
            Instructions.TabStop = false;
            Instructions.Text = resources.GetString("Instructions.Text");
            // 
            // printSummary
            // 
            printSummary.DropDownStyle = ComboBoxStyle.DropDownList;
            printSummary.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            printSummary.FormattingEnabled = true;
            printSummary.ItemHeight = 54;
            printSummary.Items.AddRange(new object[] { "None", "Detailed (Strings)", "League Summary" });
            printSummary.Location = new Point(756, 658);
            printSummary.Name = "printSummary";
            printSummary.Size = new Size(368, 62);
            printSummary.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(LeagueOnly);
            panel1.Controls.Add(Team2_Bowler7);
            panel1.Controls.Add(Team1_Bowler7);
            panel1.Controls.Add(Team2_Bowler6);
            panel1.Controls.Add(Team1_Bowler6);
            panel1.Controls.Add(laneNumberlbl);
            panel1.Controls.Add(laneNumberTxt);
            panel1.Controls.Add(CreateMatch);
            panel1.Controls.Add(NextString);
            panel1.Controls.Add(printSummary);
            panel1.Controls.Add(PrintSummaryLbl);
            panel1.Controls.Add(Instructions);
            panel1.Controls.Add(numBoxesPerTurn);
            panel1.Controls.Add(Welcome);
            panel1.Controls.Add(lbl_numBoxesTurn);
            panel1.Controls.Add(NumStrings);
            panel1.Controls.Add(lbl_NumStrings);
            panel1.Controls.Add(lbl_BowlersHDCP);
            panel1.Controls.Add(Team1_Bowler2);
            panel1.Controls.Add(Team2_Bowler5);
            panel1.Controls.Add(lbl_BowlersNames);
            panel1.Controls.Add(Team2_Bowler4);
            panel1.Controls.Add(Team1_Bowler1);
            panel1.Controls.Add(Team2_Bowler3);
            panel1.Controls.Add(Team2_Bowler2);
            panel1.Controls.Add(Team1_Bowler3);
            panel1.Controls.Add(Team2_Bowler1);
            panel1.Controls.Add(Team1_Bowler4);
            panel1.Controls.Add(Team1_Bowler5);
            panel1.Location = new Point(12, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(1450, 814);
            panel1.TabIndex = 41;
            panel1.Paint += panel1_Paint;
            // 
            // laneNumberlbl
            // 
            laneNumberlbl.AutoSize = true;
            laneNumberlbl.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            laneNumberlbl.Location = new Point(381, 22);
            laneNumberlbl.Name = "laneNumberlbl";
            laneNumberlbl.Size = new Size(445, 86);
            laneNumberlbl.TabIndex = 42;
            laneNumberlbl.Text = "Lane Number";
            // 
            // laneNumberTxt
            // 
            laneNumberTxt.BackColor = Color.CadetBlue;
            laneNumberTxt.BorderStyle = BorderStyle.None;
            laneNumberTxt.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            laneNumberTxt.Location = new Point(809, 22);
            laneNumberTxt.Name = "laneNumberTxt";
            laneNumberTxt.ReadOnly = true;
            laneNumberTxt.Size = new Size(73, 86);
            laneNumberTxt.TabIndex = 41;
            laneNumberTxt.TabStop = false;
            // 
            // Team2_Bowler6
            // 
            Team2_Bowler6.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team2_Bowler6.Location = new Point(1139, 495);
            Team2_Bowler6.Name = "Team2_Bowler6";
            Team2_Bowler6.Size = new Size(152, 61);
            Team2_Bowler6.TabIndex = 12;
            // 
            // Team1_Bowler6
            // 
            Team1_Bowler6.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team1_Bowler6.Location = new Point(1139, 428);
            Team1_Bowler6.Name = "Team1_Bowler6";
            Team1_Bowler6.Size = new Size(152, 61);
            Team1_Bowler6.TabIndex = 5;
            // 
            // Team2_Bowler7
            // 
            Team2_Bowler7.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team2_Bowler7.Location = new Point(1297, 495);
            Team2_Bowler7.Name = "Team2_Bowler7";
            Team2_Bowler7.Size = new Size(152, 61);
            Team2_Bowler7.TabIndex = 13;
            // 
            // Team1_Bowler7
            // 
            Team1_Bowler7.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            Team1_Bowler7.Location = new Point(1297, 428);
            Team1_Bowler7.Name = "Team1_Bowler7";
            Team1_Bowler7.Size = new Size(152, 61);
            Team1_Bowler7.TabIndex = 6;
            // 
            // LeagueOnly
            // 
            LeagueOnly.AutoSize = true;
            LeagueOnly.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            LeagueOnly.Location = new Point(64, 542);
            LeagueOnly.Name = "LeagueOnly";
            LeagueOnly.Size = new Size(141, 30);
            LeagueOnly.TabIndex = 43;
            LeagueOnly.Text = "(League Only)";
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(1474, 843);
            Controls.Add(panel1);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "Main_Form";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button CreateMatch;
        private Button NextString;
        private MenuStrip menuStrip;
        private TextBox Welcome;
        private Label lbl_NumStrings;
        private ComboBox NumStrings;
        private TextBox Team1_Bowler1;
        private TextBox Team1_Bowler2;
        private TextBox Team1_Bowler3;
        private TextBox Team1_Bowler4;
        private TextBox Team1_Bowler5;
        private TextBox Team2_Bowler1;
        private TextBox Team2_Bowler2;
        private TextBox Team2_Bowler3;
        private TextBox Team2_Bowler4;
        private TextBox Team2_Bowler5;
        private Label lbl_BowlersNames;
        private Label lbl_BowlersHDCP;
        private Label lbl_numBoxesTurn;
        private ComboBox numBoxesPerTurn;
        private Label PrintSummaryLbl;
        private RichTextBox Instructions;
        private ComboBox printSummary;
        private Panel panel1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem adminToolStripMenuItem;
        private Label laneNumberlbl;
        private TextBox laneNumberTxt;
        private TextBox Team2_Bowler6;
        private TextBox Team1_Bowler6;
        private TextBox Team2_Bowler7;
        private TextBox Team1_Bowler7;
        private Label LeagueOnly;
    }
}