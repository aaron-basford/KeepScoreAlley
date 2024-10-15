namespace KeepScore
{
    partial class SetDefaults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Welcome = new System.Windows.Forms.TextBox();
            this.Welcomelbl = new System.Windows.Forms.Label();
            this.SaveDefaults = new System.Windows.Forms.Button();
            this.printSummary = new System.Windows.Forms.ComboBox();
            this.PrintSummaryLbl = new System.Windows.Forms.Label();
            this.numBoxesPerTurn = new System.Windows.Forms.ComboBox();
            this.lbl_numBoxesTurn = new System.Windows.Forms.Label();
            this.laneNumberlbl = new System.Windows.Forms.Label();
            this.laneNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Welcome
            // 
            this.Welcome.BackColor = System.Drawing.SystemColors.Window;
            this.Welcome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Welcome.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Welcome.Location = new System.Drawing.Point(12, 63);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(1194, 64);
            this.Welcome.TabIndex = 1;
            this.Welcome.TabStop = false;
            this.Welcome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Welcomelbl
            // 
            this.Welcomelbl.AutoSize = true;
            this.Welcomelbl.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Welcomelbl.Location = new System.Drawing.Point(12, 15);
            this.Welcomelbl.Name = "Welcomelbl";
            this.Welcomelbl.Size = new System.Drawing.Size(288, 45);
            this.Welcomelbl.TabIndex = 42;
            this.Welcomelbl.Text = "Welcome Message";
            // 
            // SaveDefaults
            // 
            this.SaveDefaults.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SaveDefaults.Location = new System.Drawing.Point(460, 428);
            this.SaveDefaults.Name = "SaveDefaults";
            this.SaveDefaults.Size = new System.Drawing.Size(282, 70);
            this.SaveDefaults.TabIndex = 4;
            this.SaveDefaults.Text = "Save Defaults";
            this.SaveDefaults.Click += new System.EventHandler(this.SaveDefaults_Click);
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
            this.printSummary.Location = new System.Drawing.Point(508, 228);
            this.printSummary.Name = "printSummary";
            this.printSummary.Size = new System.Drawing.Size(368, 62);
            this.printSummary.TabIndex = 3;
            // 
            // PrintSummaryLbl
            // 
            this.PrintSummaryLbl.AutoSize = true;
            this.PrintSummaryLbl.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PrintSummaryLbl.Location = new System.Drawing.Point(220, 231);
            this.PrintSummaryLbl.Name = "PrintSummaryLbl";
            this.PrintSummaryLbl.Size = new System.Drawing.Size(282, 54);
            this.PrintSummaryLbl.TabIndex = 47;
            this.PrintSummaryLbl.Text = "Print Summary";
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
            this.numBoxesPerTurn.Location = new System.Drawing.Point(740, 146);
            this.numBoxesPerTurn.Name = "numBoxesPerTurn";
            this.numBoxesPerTurn.Size = new System.Drawing.Size(121, 62);
            this.numBoxesPerTurn.TabIndex = 2;
            // 
            // lbl_numBoxesTurn
            // 
            this.lbl_numBoxesTurn.AutoSize = true;
            this.lbl_numBoxesTurn.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_numBoxesTurn.Location = new System.Drawing.Point(220, 149);
            this.lbl_numBoxesTurn.Name = "lbl_numBoxesTurn";
            this.lbl_numBoxesTurn.Size = new System.Drawing.Size(488, 54);
            this.lbl_numBoxesTurn.TabIndex = 46;
            this.lbl_numBoxesTurn.Text = "Number of Boxes Per Turn";
            // 
            // laneNumberlbl
            // 
            this.laneNumberlbl.AutoSize = true;
            this.laneNumberlbl.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.laneNumberlbl.Location = new System.Drawing.Point(220, 320);
            this.laneNumberlbl.Name = "laneNumberlbl";
            this.laneNumberlbl.Size = new System.Drawing.Size(263, 54);
            this.laneNumberlbl.TabIndex = 48;
            this.laneNumberlbl.Text = "Lane Number";
            // 
            // laneNumber
            // 
            this.laneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.laneNumber.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.laneNumber.Location = new System.Drawing.Point(508, 320);
            this.laneNumber.Name = "laneNumber";
            this.laneNumber.Size = new System.Drawing.Size(100, 61);
            this.laneNumber.TabIndex = 49;
            // 
            // SetDefaults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1218, 536);
            this.Controls.Add(this.laneNumber);
            this.Controls.Add(this.laneNumberlbl);
            this.Controls.Add(this.SaveDefaults);
            this.Controls.Add(this.printSummary);
            this.Controls.Add(this.PrintSummaryLbl);
            this.Controls.Add(this.numBoxesPerTurn);
            this.Controls.Add(this.lbl_numBoxesTurn);
            this.Controls.Add(this.Welcomelbl);
            this.Controls.Add(this.Welcome);
            this.Name = "SetDefaults";
            this.Text = "Set Defaults";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox Welcome;
        private Label Welcomelbl;
        private Button SaveDefaults;
        private ComboBox printSummary;
        private Label PrintSummaryLbl;
        private ComboBox numBoxesPerTurn;
        private Label lbl_numBoxesTurn;
        private Label laneNumberlbl;
        private TextBox laneNumber;
    }
}