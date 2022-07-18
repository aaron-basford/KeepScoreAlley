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
            this.NumTeams = new System.Windows.Forms.ComboBox();
            this.lbl_NumTeams = new System.Windows.Forms.Label();
            this.lbl_NumBowlers = new System.Windows.Forms.Label();
            this.NumBowlers = new System.Windows.Forms.ComboBox();
            this.lbl_NumStrings = new System.Windows.Forms.Label();
            this.NumStrings = new System.Windows.Forms.ComboBox();
            this.Team1 = new System.Windows.Forms.TextBox();
            this.lbl_Versus1 = new System.Windows.Forms.Label();
            this.Team2 = new System.Windows.Forms.TextBox();
            this.Team4 = new System.Windows.Forms.TextBox();
            this.lbl_Versus2 = new System.Windows.Forms.Label();
            this.Team3 = new System.Windows.Forms.TextBox();
            this.Team1_Bowler1 = new System.Windows.Forms.TextBox();
            this.Team1_Bowler2 = new System.Windows.Forms.TextBox();
            this.Team1_Bowler3 = new System.Windows.Forms.TextBox();
            this.Team1_Bowler5 = new System.Windows.Forms.TextBox();
            this.Team1_Bowler4 = new System.Windows.Forms.TextBox();
            this.Team2_Bowler5 = new System.Windows.Forms.TextBox();
            this.Team2_Bowler4 = new System.Windows.Forms.TextBox();
            this.Team2_Bowler3 = new System.Windows.Forms.TextBox();
            this.Team2_Bowler2 = new System.Windows.Forms.TextBox();
            this.Team2_Bowler1 = new System.Windows.Forms.TextBox();
            this.Team3_Bowler5 = new System.Windows.Forms.TextBox();
            this.Team3_Bowler4 = new System.Windows.Forms.TextBox();
            this.Team3_Bowler3 = new System.Windows.Forms.TextBox();
            this.Team3_Bowler2 = new System.Windows.Forms.TextBox();
            this.Team3_Bowler1 = new System.Windows.Forms.TextBox();
            this.Team4_Bowler5 = new System.Windows.Forms.TextBox();
            this.Team4_Bowler4 = new System.Windows.Forms.TextBox();
            this.Team4_Bowler3 = new System.Windows.Forms.TextBox();
            this.Team4_Bowler2 = new System.Windows.Forms.TextBox();
            this.Team4_Bowler1 = new System.Windows.Forms.TextBox();
            this.lbl_MatchTitle = new System.Windows.Forms.Label();
            this.MatchTitle = new System.Windows.Forms.TextBox();
            this.CreateMatch = new System.Windows.Forms.Button();
            this.NextString = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTeam1Bowlers = new System.Windows.Forms.Label();
            this.lblTeam2Bowlers = new System.Windows.Forms.Label();
            this.lblTeam3Bowlers = new System.Windows.Forms.Label();
            this.lblTeam4Bowlers = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // NumTeams
            // 
            this.NumTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumTeams.FormattingEnabled = true;
            this.NumTeams.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.NumTeams.Location = new System.Drawing.Point(139, 29);
            this.NumTeams.Name = "NumTeams";
            this.NumTeams.Size = new System.Drawing.Size(121, 23);
            this.NumTeams.TabIndex = 0;
            this.NumTeams.SelectedIndexChanged += new System.EventHandler(this.NumTeams_SelectedIndexChanged);
            // 
            // lbl_NumTeams
            // 
            this.lbl_NumTeams.AutoSize = true;
            this.lbl_NumTeams.Location = new System.Drawing.Point(21, 37);
            this.lbl_NumTeams.Name = "lbl_NumTeams";
            this.lbl_NumTeams.Size = new System.Drawing.Size(101, 15);
            this.lbl_NumTeams.TabIndex = 1;
            this.lbl_NumTeams.Text = "Number of Teams";
            // 
            // lbl_NumBowlers
            // 
            this.lbl_NumBowlers.AutoSize = true;
            this.lbl_NumBowlers.Location = new System.Drawing.Point(21, 139);
            this.lbl_NumBowlers.Name = "lbl_NumBowlers";
            this.lbl_NumBowlers.Size = new System.Drawing.Size(109, 15);
            this.lbl_NumBowlers.TabIndex = 2;
            this.lbl_NumBowlers.Text = "Number of Bowlers";
            // 
            // NumBowlers
            // 
            this.NumBowlers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumBowlers.FormattingEnabled = true;
            this.NumBowlers.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.NumBowlers.Location = new System.Drawing.Point(139, 130);
            this.NumBowlers.Name = "NumBowlers";
            this.NumBowlers.Size = new System.Drawing.Size(121, 23);
            this.NumBowlers.TabIndex = 5;
            this.NumBowlers.SelectedIndexChanged += new System.EventHandler(this.NumBowlers_SelectedIndexChanged);
            // 
            // lbl_NumStrings
            // 
            this.lbl_NumStrings.AutoSize = true;
            this.lbl_NumStrings.Location = new System.Drawing.Point(21, 314);
            this.lbl_NumStrings.Name = "lbl_NumStrings";
            this.lbl_NumStrings.Size = new System.Drawing.Size(104, 15);
            this.lbl_NumStrings.TabIndex = 4;
            this.lbl_NumStrings.Text = "Number of Strings";
            // 
            // NumStrings
            // 
            this.NumStrings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumStrings.FormattingEnabled = true;
            this.NumStrings.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.NumStrings.Location = new System.Drawing.Point(139, 306);
            this.NumStrings.Name = "NumStrings";
            this.NumStrings.Size = new System.Drawing.Size(121, 23);
            this.NumStrings.TabIndex = 26;
            // 
            // Team1
            // 
            this.Team1.Location = new System.Drawing.Point(305, 28);
            this.Team1.Name = "Team1";
            this.Team1.Size = new System.Drawing.Size(186, 23);
            this.Team1.TabIndex = 1;
            // 
            // lbl_Versus1
            // 
            this.lbl_Versus1.AutoSize = true;
            this.lbl_Versus1.Location = new System.Drawing.Point(497, 31);
            this.lbl_Versus1.Name = "lbl_Versus1";
            this.lbl_Versus1.Size = new System.Drawing.Size(40, 15);
            this.lbl_Versus1.TabIndex = 8;
            this.lbl_Versus1.Text = "Versus";
            // 
            // Team2
            // 
            this.Team2.Location = new System.Drawing.Point(543, 28);
            this.Team2.Name = "Team2";
            this.Team2.Size = new System.Drawing.Size(186, 23);
            this.Team2.TabIndex = 2;
            // 
            // Team4
            // 
            this.Team4.Location = new System.Drawing.Point(543, 71);
            this.Team4.Name = "Team4";
            this.Team4.Size = new System.Drawing.Size(186, 23);
            this.Team4.TabIndex = 4;
            // 
            // lbl_Versus2
            // 
            this.lbl_Versus2.AutoSize = true;
            this.lbl_Versus2.Location = new System.Drawing.Point(497, 74);
            this.lbl_Versus2.Name = "lbl_Versus2";
            this.lbl_Versus2.Size = new System.Drawing.Size(40, 15);
            this.lbl_Versus2.TabIndex = 12;
            this.lbl_Versus2.Text = "Versus";
            // 
            // Team3
            // 
            this.Team3.Location = new System.Drawing.Point(305, 71);
            this.Team3.Name = "Team3";
            this.Team3.Size = new System.Drawing.Size(186, 23);
            this.Team3.TabIndex = 3;
            // 
            // Team1_Bowler1
            // 
            this.Team1_Bowler1.Location = new System.Drawing.Point(305, 130);
            this.Team1_Bowler1.Name = "Team1_Bowler1";
            this.Team1_Bowler1.Size = new System.Drawing.Size(186, 23);
            this.Team1_Bowler1.TabIndex = 6;
            // 
            // Team1_Bowler2
            // 
            this.Team1_Bowler2.Location = new System.Drawing.Point(497, 130);
            this.Team1_Bowler2.Name = "Team1_Bowler2";
            this.Team1_Bowler2.Size = new System.Drawing.Size(182, 23);
            this.Team1_Bowler2.TabIndex = 7;
            // 
            // Team1_Bowler3
            // 
            this.Team1_Bowler3.Location = new System.Drawing.Point(685, 130);
            this.Team1_Bowler3.Name = "Team1_Bowler3";
            this.Team1_Bowler3.Size = new System.Drawing.Size(163, 23);
            this.Team1_Bowler3.TabIndex = 8;
            // 
            // Team1_Bowler5
            // 
            this.Team1_Bowler5.Location = new System.Drawing.Point(1042, 130);
            this.Team1_Bowler5.Name = "Team1_Bowler5";
            this.Team1_Bowler5.Size = new System.Drawing.Size(163, 23);
            this.Team1_Bowler5.TabIndex = 10;
            // 
            // Team1_Bowler4
            // 
            this.Team1_Bowler4.Location = new System.Drawing.Point(854, 130);
            this.Team1_Bowler4.Name = "Team1_Bowler4";
            this.Team1_Bowler4.Size = new System.Drawing.Size(182, 23);
            this.Team1_Bowler4.TabIndex = 9;
            // 
            // Team2_Bowler5
            // 
            this.Team2_Bowler5.Location = new System.Drawing.Point(1042, 169);
            this.Team2_Bowler5.Name = "Team2_Bowler5";
            this.Team2_Bowler5.Size = new System.Drawing.Size(163, 23);
            this.Team2_Bowler5.TabIndex = 15;
            // 
            // Team2_Bowler4
            // 
            this.Team2_Bowler4.Location = new System.Drawing.Point(854, 169);
            this.Team2_Bowler4.Name = "Team2_Bowler4";
            this.Team2_Bowler4.Size = new System.Drawing.Size(182, 23);
            this.Team2_Bowler4.TabIndex = 14;
            // 
            // Team2_Bowler3
            // 
            this.Team2_Bowler3.Location = new System.Drawing.Point(685, 169);
            this.Team2_Bowler3.Name = "Team2_Bowler3";
            this.Team2_Bowler3.Size = new System.Drawing.Size(163, 23);
            this.Team2_Bowler3.TabIndex = 13;
            // 
            // Team2_Bowler2
            // 
            this.Team2_Bowler2.Location = new System.Drawing.Point(497, 169);
            this.Team2_Bowler2.Name = "Team2_Bowler2";
            this.Team2_Bowler2.Size = new System.Drawing.Size(182, 23);
            this.Team2_Bowler2.TabIndex = 12;
            // 
            // Team2_Bowler1
            // 
            this.Team2_Bowler1.Location = new System.Drawing.Point(305, 169);
            this.Team2_Bowler1.Name = "Team2_Bowler1";
            this.Team2_Bowler1.Size = new System.Drawing.Size(186, 23);
            this.Team2_Bowler1.TabIndex = 11;
            // 
            // Team3_Bowler5
            // 
            this.Team3_Bowler5.Location = new System.Drawing.Point(1042, 209);
            this.Team3_Bowler5.Name = "Team3_Bowler5";
            this.Team3_Bowler5.Size = new System.Drawing.Size(163, 23);
            this.Team3_Bowler5.TabIndex = 20;
            // 
            // Team3_Bowler4
            // 
            this.Team3_Bowler4.Location = new System.Drawing.Point(854, 209);
            this.Team3_Bowler4.Name = "Team3_Bowler4";
            this.Team3_Bowler4.Size = new System.Drawing.Size(182, 23);
            this.Team3_Bowler4.TabIndex = 19;
            // 
            // Team3_Bowler3
            // 
            this.Team3_Bowler3.Location = new System.Drawing.Point(685, 209);
            this.Team3_Bowler3.Name = "Team3_Bowler3";
            this.Team3_Bowler3.Size = new System.Drawing.Size(163, 23);
            this.Team3_Bowler3.TabIndex = 18;
            // 
            // Team3_Bowler2
            // 
            this.Team3_Bowler2.Location = new System.Drawing.Point(497, 209);
            this.Team3_Bowler2.Name = "Team3_Bowler2";
            this.Team3_Bowler2.Size = new System.Drawing.Size(182, 23);
            this.Team3_Bowler2.TabIndex = 17;
            // 
            // Team3_Bowler1
            // 
            this.Team3_Bowler1.Location = new System.Drawing.Point(305, 209);
            this.Team3_Bowler1.Name = "Team3_Bowler1";
            this.Team3_Bowler1.Size = new System.Drawing.Size(186, 23);
            this.Team3_Bowler1.TabIndex = 16;
            // 
            // Team4_Bowler5
            // 
            this.Team4_Bowler5.Location = new System.Drawing.Point(1042, 249);
            this.Team4_Bowler5.Name = "Team4_Bowler5";
            this.Team4_Bowler5.Size = new System.Drawing.Size(163, 23);
            this.Team4_Bowler5.TabIndex = 25;
            // 
            // Team4_Bowler4
            // 
            this.Team4_Bowler4.Location = new System.Drawing.Point(854, 249);
            this.Team4_Bowler4.Name = "Team4_Bowler4";
            this.Team4_Bowler4.Size = new System.Drawing.Size(182, 23);
            this.Team4_Bowler4.TabIndex = 24;
            // 
            // Team4_Bowler3
            // 
            this.Team4_Bowler3.Location = new System.Drawing.Point(685, 249);
            this.Team4_Bowler3.Name = "Team4_Bowler3";
            this.Team4_Bowler3.Size = new System.Drawing.Size(163, 23);
            this.Team4_Bowler3.TabIndex = 23;
            // 
            // Team4_Bowler2
            // 
            this.Team4_Bowler2.Location = new System.Drawing.Point(497, 249);
            this.Team4_Bowler2.Name = "Team4_Bowler2";
            this.Team4_Bowler2.Size = new System.Drawing.Size(182, 23);
            this.Team4_Bowler2.TabIndex = 22;
            // 
            // Team4_Bowler1
            // 
            this.Team4_Bowler1.Location = new System.Drawing.Point(305, 249);
            this.Team4_Bowler1.Name = "Team4_Bowler1";
            this.Team4_Bowler1.Size = new System.Drawing.Size(186, 23);
            this.Team4_Bowler1.TabIndex = 21;
            // 
            // lbl_MatchTitle
            // 
            this.lbl_MatchTitle.Location = new System.Drawing.Point(296, 309);
            this.lbl_MatchTitle.Name = "lbl_MatchTitle";
            this.lbl_MatchTitle.Size = new System.Drawing.Size(66, 15);
            this.lbl_MatchTitle.TabIndex = 27;
            this.lbl_MatchTitle.Text = "Match Title";
            // 
            // MatchTitle
            // 
            this.MatchTitle.Location = new System.Drawing.Point(377, 306);
            this.MatchTitle.Name = "MatchTitle";
            this.MatchTitle.Size = new System.Drawing.Size(281, 23);
            this.MatchTitle.TabIndex = 28;
            // 
            // CreateMatch
            // 
            this.CreateMatch.Location = new System.Drawing.Point(742, 305);
            this.CreateMatch.Name = "CreateMatch";
            this.CreateMatch.Size = new System.Drawing.Size(187, 23);
            this.CreateMatch.TabIndex = 29;
            this.CreateMatch.Text = "Create Match";
            this.CreateMatch.Click += new System.EventHandler(this.CreateButton_OnClick);
            // 
            // NextString
            // 
            this.NextString.Location = new System.Drawing.Point(961, 305);
            this.NextString.Name = "NextString";
            this.NextString.Size = new System.Drawing.Size(187, 23);
            this.NextString.TabIndex = 30;
            this.NextString.Text = "Next String";
            this.NextString.Click += new System.EventHandler(this.NextString_OnClick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1267, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.Help_OnClick);
            // 
            // lblTeam1Bowlers
            // 
            this.lblTeam1Bowlers.AutoSize = true;
            this.lblTeam1Bowlers.Location = new System.Drawing.Point(286, 133);
            this.lblTeam1Bowlers.Name = "lblTeam1Bowlers";
            this.lblTeam1Bowlers.Size = new System.Drawing.Size(13, 15);
            this.lblTeam1Bowlers.TabIndex = 31;
            this.lblTeam1Bowlers.Text = "1";
            // 
            // lblTeam2Bowlers
            // 
            this.lblTeam2Bowlers.AutoSize = true;
            this.lblTeam2Bowlers.Location = new System.Drawing.Point(286, 172);
            this.lblTeam2Bowlers.Name = "lblTeam2Bowlers";
            this.lblTeam2Bowlers.Size = new System.Drawing.Size(13, 15);
            this.lblTeam2Bowlers.TabIndex = 32;
            this.lblTeam2Bowlers.Text = "2";
            // 
            // lblTeam3Bowlers
            // 
            this.lblTeam3Bowlers.AutoSize = true;
            this.lblTeam3Bowlers.Location = new System.Drawing.Point(286, 212);
            this.lblTeam3Bowlers.Name = "lblTeam3Bowlers";
            this.lblTeam3Bowlers.Size = new System.Drawing.Size(13, 15);
            this.lblTeam3Bowlers.TabIndex = 33;
            this.lblTeam3Bowlers.Text = "3";
            // 
            // lblTeam4Bowlers
            // 
            this.lblTeam4Bowlers.AutoSize = true;
            this.lblTeam4Bowlers.Location = new System.Drawing.Point(286, 252);
            this.lblTeam4Bowlers.Name = "lblTeam4Bowlers";
            this.lblTeam4Bowlers.Size = new System.Drawing.Size(13, 15);
            this.lblTeam4Bowlers.TabIndex = 34;
            this.lblTeam4Bowlers.Text = "4";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1267, 450);
            this.Controls.Add(this.lblTeam4Bowlers);
            this.Controls.Add(this.lblTeam3Bowlers);
            this.Controls.Add(this.lblTeam2Bowlers);
            this.Controls.Add(this.lblTeam1Bowlers);
            this.Controls.Add(this.Team4_Bowler5);
            this.Controls.Add(this.Team4_Bowler4);
            this.Controls.Add(this.Team4_Bowler3);
            this.Controls.Add(this.Team4_Bowler2);
            this.Controls.Add(this.Team4_Bowler1);
            this.Controls.Add(this.Team3_Bowler5);
            this.Controls.Add(this.Team3_Bowler4);
            this.Controls.Add(this.Team3_Bowler3);
            this.Controls.Add(this.Team3_Bowler2);
            this.Controls.Add(this.Team3_Bowler1);
            this.Controls.Add(this.Team2_Bowler5);
            this.Controls.Add(this.Team2_Bowler4);
            this.Controls.Add(this.Team2_Bowler3);
            this.Controls.Add(this.Team2_Bowler2);
            this.Controls.Add(this.Team2_Bowler1);
            this.Controls.Add(this.Team1_Bowler5);
            this.Controls.Add(this.Team1_Bowler4);
            this.Controls.Add(this.Team1_Bowler3);
            this.Controls.Add(this.Team1_Bowler2);
            this.Controls.Add(this.Team1_Bowler1);
            this.Controls.Add(this.Team4);
            this.Controls.Add(this.lbl_Versus2);
            this.Controls.Add(this.Team3);
            this.Controls.Add(this.Team2);
            this.Controls.Add(this.lbl_Versus1);
            this.Controls.Add(this.Team1);
            this.Controls.Add(this.NumStrings);
            this.Controls.Add(this.lbl_NumStrings);
            this.Controls.Add(this.NumBowlers);
            this.Controls.Add(this.lbl_NumBowlers);
            this.Controls.Add(this.lbl_NumTeams);
            this.Controls.Add(this.NumTeams);
            this.Controls.Add(this.lbl_MatchTitle);
            this.Controls.Add(this.MatchTitle);
            this.Controls.Add(this.CreateMatch);
            this.Controls.Add(this.NextString);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main_Form";
            this.Text = "KeepScore";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox NumTeams;
        private Label lbl_NumTeams;
        private Label lbl_NumBowlers;
        private ComboBox NumBowlers;
        private Label lbl_NumStrings;
        private ComboBox NumStrings;
        private TextBox Team1;
        private Label lbl_Versus1;
        private TextBox Team2;
        private TextBox Team4;
        private Label lbl_Versus2;
        private TextBox Team3;
        private TextBox Team1_Bowler1;
        private TextBox Team1_Bowler2;
        private TextBox Team1_Bowler3;
        private TextBox Team1_Bowler5;
        private TextBox Team1_Bowler4;
        private TextBox Team2_Bowler5;
        private TextBox Team2_Bowler4;
        private TextBox Team2_Bowler3;
        private TextBox Team2_Bowler2;
        private TextBox Team2_Bowler1;
        private TextBox Team3_Bowler5;
        private TextBox Team3_Bowler4;
        private TextBox Team3_Bowler3;
        private TextBox Team3_Bowler2;
        private TextBox Team3_Bowler1;
        private TextBox Team4_Bowler5;
        private TextBox Team4_Bowler4;
        private TextBox Team4_Bowler3;
        private TextBox Team4_Bowler2;
        private TextBox Team4_Bowler1;
        private Label lbl_MatchTitle;
        private TextBox MatchTitle;
        private Button CreateMatch;
        private Button NextString;
        private MenuStrip menuStrip;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Label lblTeam1Bowlers;
        private Label lblTeam2Bowlers;
        private Label lblTeam3Bowlers;
        private Label lblTeam4Bowlers;
    }
}