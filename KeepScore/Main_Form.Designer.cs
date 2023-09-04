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
            this.lbl_NumStrings = new System.Windows.Forms.Label();
            this.NumStrings = new System.Windows.Forms.ComboBox();
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
            this.CreateMatch = new System.Windows.Forms.Button();
            this.NextString = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_BowlersNames = new System.Windows.Forms.Label();
            this.lbl_BowlersHDCP = new System.Windows.Forms.Label();
            this.lbl_numBoxesTurn = new System.Windows.Forms.Label();
            this.numBoxesPerTurn = new System.Windows.Forms.ComboBox();
            this.PrintSummary = new System.Windows.Forms.ComboBox();
            this.PrintSummaryLbl = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_NumStrings
            // 
            this.lbl_NumStrings.AutoSize = true;
            this.lbl_NumStrings.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_NumStrings.Location = new System.Drawing.Point(28, 210);
            this.lbl_NumStrings.Name = "lbl_NumStrings";
            this.lbl_NumStrings.Size = new System.Drawing.Size(349, 54);
            this.lbl_NumStrings.TabIndex = 4;
            this.lbl_NumStrings.Text = "Number of Strings";
            // 
            // NumStrings
            // 
            this.NumStrings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumStrings.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumStrings.FormattingEnabled = true;
            this.NumStrings.ItemHeight = 54;
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
            this.NumStrings.Location = new System.Drawing.Point(393, 202);
            this.NumStrings.Name = "NumStrings";
            this.NumStrings.Size = new System.Drawing.Size(121, 62);
            this.NumStrings.TabIndex = 10;
            // 
            // Team1_Bowler1
            // 
            this.Team1_Bowler1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team1_Bowler1.Location = new System.Drawing.Point(328, 52);
            this.Team1_Bowler1.Name = "Team1_Bowler1";
            this.Team1_Bowler1.Size = new System.Drawing.Size(186, 61);
            this.Team1_Bowler1.TabIndex = 0;
            // 
            // Team1_Bowler2
            // 
            this.Team1_Bowler2.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team1_Bowler2.Location = new System.Drawing.Point(520, 52);
            this.Team1_Bowler2.Name = "Team1_Bowler2";
            this.Team1_Bowler2.Size = new System.Drawing.Size(182, 61);
            this.Team1_Bowler2.TabIndex = 1;
            // 
            // Team1_Bowler3
            // 
            this.Team1_Bowler3.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team1_Bowler3.Location = new System.Drawing.Point(708, 52);
            this.Team1_Bowler3.Name = "Team1_Bowler3";
            this.Team1_Bowler3.Size = new System.Drawing.Size(163, 61);
            this.Team1_Bowler3.TabIndex = 2;
            // 
            // Team1_Bowler5
            // 
            this.Team1_Bowler5.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team1_Bowler5.Location = new System.Drawing.Point(1065, 52);
            this.Team1_Bowler5.Name = "Team1_Bowler5";
            this.Team1_Bowler5.Size = new System.Drawing.Size(163, 61);
            this.Team1_Bowler5.TabIndex = 4;
            // 
            // Team1_Bowler4
            // 
            this.Team1_Bowler4.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team1_Bowler4.Location = new System.Drawing.Point(877, 52);
            this.Team1_Bowler4.Name = "Team1_Bowler4";
            this.Team1_Bowler4.Size = new System.Drawing.Size(182, 61);
            this.Team1_Bowler4.TabIndex = 3;
            // 
            // Team2_Bowler5
            // 
            this.Team2_Bowler5.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team2_Bowler5.Location = new System.Drawing.Point(1065, 123);
            this.Team2_Bowler5.Name = "Team2_Bowler5";
            this.Team2_Bowler5.Size = new System.Drawing.Size(163, 61);
            this.Team2_Bowler5.TabIndex = 9;
            // 
            // Team2_Bowler4
            // 
            this.Team2_Bowler4.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team2_Bowler4.Location = new System.Drawing.Point(877, 123);
            this.Team2_Bowler4.Name = "Team2_Bowler4";
            this.Team2_Bowler4.Size = new System.Drawing.Size(182, 61);
            this.Team2_Bowler4.TabIndex = 8;
            // 
            // Team2_Bowler3
            // 
            this.Team2_Bowler3.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team2_Bowler3.Location = new System.Drawing.Point(708, 123);
            this.Team2_Bowler3.Name = "Team2_Bowler3";
            this.Team2_Bowler3.Size = new System.Drawing.Size(163, 61);
            this.Team2_Bowler3.TabIndex = 7;
            // 
            // Team2_Bowler2
            // 
            this.Team2_Bowler2.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team2_Bowler2.Location = new System.Drawing.Point(520, 123);
            this.Team2_Bowler2.Name = "Team2_Bowler2";
            this.Team2_Bowler2.Size = new System.Drawing.Size(182, 61);
            this.Team2_Bowler2.TabIndex = 6;
            // 
            // Team2_Bowler1
            // 
            this.Team2_Bowler1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team2_Bowler1.Location = new System.Drawing.Point(328, 123);
            this.Team2_Bowler1.Name = "Team2_Bowler1";
            this.Team2_Bowler1.Size = new System.Drawing.Size(186, 61);
            this.Team2_Bowler1.TabIndex = 5;
            // 
            // CreateMatch
            // 
            this.CreateMatch.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateMatch.Location = new System.Drawing.Point(475, 359);
            this.CreateMatch.Name = "CreateMatch";
            this.CreateMatch.Size = new System.Drawing.Size(436, 70);
            this.CreateMatch.TabIndex = 13;
            this.CreateMatch.Text = "Create Score Sheet";
            this.CreateMatch.Click += new System.EventHandler(this.CreateButton_OnClick);
            // 
            // NextString
            // 
            this.NextString.Location = new System.Drawing.Point(1068, 406);
            this.NextString.Name = "NextString";
            this.NextString.Size = new System.Drawing.Size(187, 23);
            this.NextString.TabIndex = 30;
            this.NextString.Text = "Next String";
            this.NextString.Visible = false;
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
            // lbl_BowlersNames
            // 
            this.lbl_BowlersNames.AutoSize = true;
            this.lbl_BowlersNames.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_BowlersNames.Location = new System.Drawing.Point(23, 55);
            this.lbl_BowlersNames.Name = "lbl_BowlersNames";
            this.lbl_BowlersNames.Size = new System.Drawing.Size(285, 54);
            this.lbl_BowlersNames.TabIndex = 35;
            this.lbl_BowlersNames.Text = "Bowler\'s Name";
            // 
            // lbl_BowlersHDCP
            // 
            this.lbl_BowlersHDCP.AutoSize = true;
            this.lbl_BowlersHDCP.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_BowlersHDCP.Location = new System.Drawing.Point(23, 123);
            this.lbl_BowlersHDCP.Name = "lbl_BowlersHDCP";
            this.lbl_BowlersHDCP.Size = new System.Drawing.Size(283, 54);
            this.lbl_BowlersHDCP.TabIndex = 36;
            this.lbl_BowlersHDCP.Text = "Bowler\'s HDCP";
            // 
            // lbl_numBoxesTurn
            // 
            this.lbl_numBoxesTurn.AutoSize = true;
            this.lbl_numBoxesTurn.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_numBoxesTurn.Location = new System.Drawing.Point(609, 210);
            this.lbl_numBoxesTurn.Name = "lbl_numBoxesTurn";
            this.lbl_numBoxesTurn.Size = new System.Drawing.Size(488, 54);
            this.lbl_numBoxesTurn.TabIndex = 37;
            this.lbl_numBoxesTurn.Text = "Number of Boxes Per Turn";
            // 
            // numBoxesPerTurn
            // 
            this.numBoxesPerTurn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numBoxesPerTurn.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numBoxesPerTurn.FormattingEnabled = true;
            this.numBoxesPerTurn.ItemHeight = 54;
            this.numBoxesPerTurn.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "5",
            "10"});
            this.numBoxesPerTurn.Location = new System.Drawing.Point(1107, 202);
            this.numBoxesPerTurn.Name = "numBoxesPerTurn";
            this.numBoxesPerTurn.Size = new System.Drawing.Size(121, 62);
            this.numBoxesPerTurn.TabIndex = 11;
            // 
            // PrintSummary
            // 
            this.PrintSummary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PrintSummary.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PrintSummary.FormattingEnabled = true;
            this.PrintSummary.ItemHeight = 54;
            this.PrintSummary.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.PrintSummary.Location = new System.Drawing.Point(776, 286);
            this.PrintSummary.Name = "PrintSummary";
            this.PrintSummary.Size = new System.Drawing.Size(121, 62);
            this.PrintSummary.TabIndex = 12;
            // 
            // PrintSummaryLbl
            // 
            this.PrintSummaryLbl.AutoSize = true;
            this.PrintSummaryLbl.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PrintSummaryLbl.Location = new System.Drawing.Point(475, 286);
            this.PrintSummaryLbl.Name = "PrintSummaryLbl";
            this.PrintSummaryLbl.Size = new System.Drawing.Size(282, 54);
            this.PrintSummaryLbl.TabIndex = 38;
            this.PrintSummaryLbl.Text = "Print Summary";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1267, 450);
            this.Controls.Add(this.PrintSummaryLbl);
            this.Controls.Add(this.PrintSummary);
            this.Controls.Add(this.numBoxesPerTurn);
            this.Controls.Add(this.lbl_numBoxesTurn);
            this.Controls.Add(this.lbl_BowlersHDCP);
            this.Controls.Add(this.lbl_BowlersNames);
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
            this.Controls.Add(this.NumStrings);
            this.Controls.Add(this.lbl_NumStrings);
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
        private Label lbl_NumStrings;
        private ComboBox NumStrings;
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
        private Button CreateMatch;
        private Button NextString;
        private MenuStrip menuStrip;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Label lbl_BowlersNames;
        private Label lbl_BowlersHDCP;
        private Label lbl_numBoxesTurn;
        private ComboBox numBoxesPerTurn;
        private ComboBox PrintSummary;
        private Label PrintSummaryLbl;
    }
}