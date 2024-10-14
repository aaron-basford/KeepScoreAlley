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
            this.CreateMatch = new System.Windows.Forms.Button();
            this.NextString = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Welcome = new System.Windows.Forms.TextBox();
            this.lbl_NumStrings = new System.Windows.Forms.Label();
            this.NumStrings = new System.Windows.Forms.ComboBox();
            this.Team1_Bowler1 = new System.Windows.Forms.TextBox();
            this.Team1_Bowler2 = new System.Windows.Forms.TextBox();
            this.Team1_Bowler3 = new System.Windows.Forms.TextBox();
            this.Team1_Bowler4 = new System.Windows.Forms.TextBox();
            this.Team1_Bowler5 = new System.Windows.Forms.TextBox();
            this.Team2_Bowler1 = new System.Windows.Forms.TextBox();
            this.Team2_Bowler2 = new System.Windows.Forms.TextBox();
            this.Team2_Bowler3 = new System.Windows.Forms.TextBox();
            this.Team2_Bowler4 = new System.Windows.Forms.TextBox();
            this.Team2_Bowler5 = new System.Windows.Forms.TextBox();
            this.lbl_BowlersNames = new System.Windows.Forms.Label();
            this.lbl_BowlersHDCP = new System.Windows.Forms.Label();
            this.lbl_numBoxesTurn = new System.Windows.Forms.Label();
            this.numBoxesPerTurn = new System.Windows.Forms.ComboBox();
            this.PrintSummaryLbl = new System.Windows.Forms.Label();
            this.Instructions = new System.Windows.Forms.RichTextBox();
            this.printSummary = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateMatch
            // 
            this.CreateMatch.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateMatch.Location = new System.Drawing.Point(435, 655);
            this.CreateMatch.Name = "CreateMatch";
            this.CreateMatch.Size = new System.Drawing.Size(436, 70);
            this.CreateMatch.TabIndex = 13;
            this.CreateMatch.Text = "Create Score Sheet";
            this.CreateMatch.Click += new System.EventHandler(this.CreateButton_OnClick);
            // 
            // NextString
            // 
            this.NextString.Location = new System.Drawing.Point(942, 692);
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
            // Welcome
            // 
            this.Welcome.BackColor = System.Drawing.SystemColors.Window;
            this.Welcome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Welcome.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Welcome.Location = new System.Drawing.Point(33, 10);
            this.Welcome.Name = "Welcome";
            this.Welcome.ReadOnly = true;
            this.Welcome.Size = new System.Drawing.Size(1194, 64);
            this.Welcome.TabIndex = 40;
            this.Welcome.TabStop = false;
            this.Welcome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_NumStrings
            // 
            this.lbl_NumStrings.AutoSize = true;
            this.lbl_NumStrings.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_NumStrings.Location = new System.Drawing.Point(18, 508);
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
            this.NumStrings.Location = new System.Drawing.Point(383, 500);
            this.NumStrings.Name = "NumStrings";
            this.NumStrings.Size = new System.Drawing.Size(121, 62);
            this.NumStrings.TabIndex = 10;
            // 
            // Team1_Bowler1
            // 
            this.Team1_Bowler1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team1_Bowler1.Location = new System.Drawing.Point(327, 362);
            this.Team1_Bowler1.Name = "Team1_Bowler1";
            this.Team1_Bowler1.Size = new System.Drawing.Size(186, 61);
            this.Team1_Bowler1.TabIndex = 0;
            // 
            // Team1_Bowler2
            // 
            this.Team1_Bowler2.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team1_Bowler2.Location = new System.Drawing.Point(519, 362);
            this.Team1_Bowler2.Name = "Team1_Bowler2";
            this.Team1_Bowler2.Size = new System.Drawing.Size(182, 61);
            this.Team1_Bowler2.TabIndex = 1;
            // 
            // Team1_Bowler3
            // 
            this.Team1_Bowler3.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team1_Bowler3.Location = new System.Drawing.Point(707, 362);
            this.Team1_Bowler3.Name = "Team1_Bowler3";
            this.Team1_Bowler3.Size = new System.Drawing.Size(163, 61);
            this.Team1_Bowler3.TabIndex = 2;
            // 
            // Team1_Bowler4
            // 
            this.Team1_Bowler4.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team1_Bowler4.Location = new System.Drawing.Point(876, 362);
            this.Team1_Bowler4.Name = "Team1_Bowler4";
            this.Team1_Bowler4.Size = new System.Drawing.Size(182, 61);
            this.Team1_Bowler4.TabIndex = 3;
            // 
            // Team1_Bowler5
            // 
            this.Team1_Bowler5.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team1_Bowler5.Location = new System.Drawing.Point(1064, 362);
            this.Team1_Bowler5.Name = "Team1_Bowler5";
            this.Team1_Bowler5.Size = new System.Drawing.Size(163, 61);
            this.Team1_Bowler5.TabIndex = 4;
            // 
            // Team2_Bowler1
            // 
            this.Team2_Bowler1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team2_Bowler1.Location = new System.Drawing.Point(327, 429);
            this.Team2_Bowler1.Name = "Team2_Bowler1";
            this.Team2_Bowler1.Size = new System.Drawing.Size(186, 61);
            this.Team2_Bowler1.TabIndex = 5;
            // 
            // Team2_Bowler2
            // 
            this.Team2_Bowler2.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team2_Bowler2.Location = new System.Drawing.Point(519, 429);
            this.Team2_Bowler2.Name = "Team2_Bowler2";
            this.Team2_Bowler2.Size = new System.Drawing.Size(182, 61);
            this.Team2_Bowler2.TabIndex = 6;
            // 
            // Team2_Bowler3
            // 
            this.Team2_Bowler3.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team2_Bowler3.Location = new System.Drawing.Point(707, 429);
            this.Team2_Bowler3.Name = "Team2_Bowler3";
            this.Team2_Bowler3.Size = new System.Drawing.Size(163, 61);
            this.Team2_Bowler3.TabIndex = 7;
            // 
            // Team2_Bowler4
            // 
            this.Team2_Bowler4.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team2_Bowler4.Location = new System.Drawing.Point(876, 429);
            this.Team2_Bowler4.Name = "Team2_Bowler4";
            this.Team2_Bowler4.Size = new System.Drawing.Size(182, 61);
            this.Team2_Bowler4.TabIndex = 8;
            // 
            // Team2_Bowler5
            // 
            this.Team2_Bowler5.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Team2_Bowler5.Location = new System.Drawing.Point(1064, 429);
            this.Team2_Bowler5.Name = "Team2_Bowler5";
            this.Team2_Bowler5.Size = new System.Drawing.Size(163, 61);
            this.Team2_Bowler5.TabIndex = 9;
            // 
            // lbl_BowlersNames
            // 
            this.lbl_BowlersNames.AutoSize = true;
            this.lbl_BowlersNames.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_BowlersNames.Location = new System.Drawing.Point(22, 362);
            this.lbl_BowlersNames.Name = "lbl_BowlersNames";
            this.lbl_BowlersNames.Size = new System.Drawing.Size(285, 54);
            this.lbl_BowlersNames.TabIndex = 35;
            this.lbl_BowlersNames.Text = "Bowler\'s Name";
            // 
            // lbl_BowlersHDCP
            // 
            this.lbl_BowlersHDCP.AutoSize = true;
            this.lbl_BowlersHDCP.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_BowlersHDCP.Location = new System.Drawing.Point(22, 429);
            this.lbl_BowlersHDCP.Name = "lbl_BowlersHDCP";
            this.lbl_BowlersHDCP.Size = new System.Drawing.Size(283, 54);
            this.lbl_BowlersHDCP.TabIndex = 36;
            this.lbl_BowlersHDCP.Text = "Bowler\'s HDCP";
            // 
            // lbl_numBoxesTurn
            // 
            this.lbl_numBoxesTurn.AutoSize = true;
            this.lbl_numBoxesTurn.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_numBoxesTurn.Location = new System.Drawing.Point(599, 508);
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
            this.numBoxesPerTurn.Location = new System.Drawing.Point(1097, 500);
            this.numBoxesPerTurn.Name = "numBoxesPerTurn";
            this.numBoxesPerTurn.Size = new System.Drawing.Size(121, 62);
            this.numBoxesPerTurn.TabIndex = 11;
            // 
            // PrintSummaryLbl
            // 
            this.PrintSummaryLbl.AutoSize = true;
            this.PrintSummaryLbl.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PrintSummaryLbl.Location = new System.Drawing.Point(363, 576);
            this.PrintSummaryLbl.Name = "PrintSummaryLbl";
            this.PrintSummaryLbl.Size = new System.Drawing.Size(282, 54);
            this.PrintSummaryLbl.TabIndex = 38;
            this.PrintSummaryLbl.Text = "Print Summary";
            // 
            // Instructions
            // 
            this.Instructions.BackColor = System.Drawing.SystemColors.Window;
            this.Instructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Instructions.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Instructions.Location = new System.Drawing.Point(33, 80);
            this.Instructions.Name = "Instructions";
            this.Instructions.ReadOnly = true;
            this.Instructions.Size = new System.Drawing.Size(1194, 279);
            this.Instructions.TabIndex = 39;
            this.Instructions.TabStop = false;
            this.Instructions.Text = resources.GetString("Instructions.Text");
            // 
            // printSummary
            // 
            this.printSummary.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.printSummary.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.printSummary.FormattingEnabled = true;
            this.printSummary.ItemHeight = 54;
            this.printSummary.Items.AddRange(new object[] {
            "None",
            "Detailed (Strings)",
            "League Summary"});
            this.printSummary.Location = new System.Drawing.Point(651, 576);
            this.printSummary.Name = "printSummary";
            this.printSummary.Size = new System.Drawing.Size(368, 62);
            this.printSummary.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.CreateMatch);
            this.panel1.Controls.Add(this.NextString);
            this.panel1.Controls.Add(this.printSummary);
            this.panel1.Controls.Add(this.PrintSummaryLbl);
            this.panel1.Controls.Add(this.Instructions);
            this.panel1.Controls.Add(this.numBoxesPerTurn);
            this.panel1.Controls.Add(this.Welcome);
            this.panel1.Controls.Add(this.lbl_numBoxesTurn);
            this.panel1.Controls.Add(this.NumStrings);
            this.panel1.Controls.Add(this.lbl_NumStrings);
            this.panel1.Controls.Add(this.lbl_BowlersHDCP);
            this.panel1.Controls.Add(this.Team1_Bowler2);
            this.panel1.Controls.Add(this.Team2_Bowler5);
            this.panel1.Controls.Add(this.lbl_BowlersNames);
            this.panel1.Controls.Add(this.Team2_Bowler4);
            this.panel1.Controls.Add(this.Team1_Bowler1);
            this.panel1.Controls.Add(this.Team2_Bowler3);
            this.panel1.Controls.Add(this.Team2_Bowler2);
            this.panel1.Controls.Add(this.Team1_Bowler3);
            this.panel1.Controls.Add(this.Team2_Bowler1);
            this.panel1.Controls.Add(this.Team1_Bowler4);
            this.panel1.Controls.Add(this.Team1_Bowler5);
            this.panel1.Location = new System.Drawing.Point(20, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1242, 742);
            this.panel1.TabIndex = 41;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1267, 784);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main_Form";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button CreateMatch;
        private Button NextString;
        private MenuStrip menuStrip;
        private ToolStripMenuItem helpToolStripMenuItem;
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
    }
}