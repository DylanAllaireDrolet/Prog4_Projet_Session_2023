namespace CSChess
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lstJoueurs = new System.Windows.Forms.ListBox();
            this.btnJouer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDefaites = new System.Windows.Forms.Label();
            this.lblVictoires = new System.Windows.Forms.Label();
            this.lblParties = new System.Windows.Forms.Label();
            this.pnlEchiquier = new System.Windows.Forms.Panel();
            this.lblEtat = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstJoueurs
            // 
            this.lstJoueurs.FormattingEnabled = true;
            this.lstJoueurs.Location = new System.Drawing.Point(10, 311);
            this.lstJoueurs.Name = "lstJoueurs";
            this.lstJoueurs.Size = new System.Drawing.Size(142, 69);
            this.lstJoueurs.TabIndex = 0;
            this.lstJoueurs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstJoueurs_MouseClick);
            // 
            // btnJouer
            // 
            this.btnJouer.Location = new System.Drawing.Point(10, 282);
            this.btnJouer.Name = "btnJouer";
            this.btnJouer.Size = new System.Drawing.Size(241, 23);
            this.btnJouer.TabIndex = 1;
            this.btnJouer.Text = "Jouer";
            this.btnJouer.UseVisualStyleBackColor = true;
            this.btnJouer.Click += new System.EventHandler(this.btnJouer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDefaites);
            this.groupBox1.Controls.Add(this.lblVictoires);
            this.groupBox1.Controls.Add(this.lblParties);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(159, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(92, 66);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistiques";
            // 
            // lblDefaites
            // 
            this.lblDefaites.AutoSize = true;
            this.lblDefaites.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefaites.Location = new System.Drawing.Point(6, 42);
            this.lblDefaites.Name = "lblDefaites";
            this.lblDefaites.Size = new System.Drawing.Size(55, 13);
            this.lblDefaites.TabIndex = 2;
            this.lblDefaites.Text = "Défaites : ";
            // 
            // lblVictoires
            // 
            this.lblVictoires.AutoSize = true;
            this.lblVictoires.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVictoires.Location = new System.Drawing.Point(6, 29);
            this.lblVictoires.Name = "lblVictoires";
            this.lblVictoires.Size = new System.Drawing.Size(56, 13);
            this.lblVictoires.TabIndex = 1;
            this.lblVictoires.Text = "Victoires : ";
            // 
            // lblParties
            // 
            this.lblParties.AutoSize = true;
            this.lblParties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParties.Location = new System.Drawing.Point(6, 16);
            this.lblParties.Name = "lblParties";
            this.lblParties.Size = new System.Drawing.Size(48, 13);
            this.lblParties.TabIndex = 0;
            this.lblParties.Text = "Parties : ";
            // 
            // pnlEchiquier
            // 
            this.pnlEchiquier.Location = new System.Drawing.Point(10, 36);
            this.pnlEchiquier.Name = "pnlEchiquier";
            this.pnlEchiquier.Size = new System.Drawing.Size(241, 241);
            this.pnlEchiquier.TabIndex = 3;
            this.pnlEchiquier.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlEchiquier_MouseClick);
            this.pnlEchiquier.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlEchiquier_Paint);
            // 
            // lblEtat
            // 
            this.lblEtat.AutoSize = true;
            this.lblEtat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtat.Location = new System.Drawing.Point(12, 9);
            this.lblEtat.Name = "lblEtat";
            this.lblEtat.Size = new System.Drawing.Size(189, 15);
            this.lblEtat.TabIndex = 4;
            this.lblEtat.Text = "Sélectionnez deux joueurs...";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 392);
            this.Controls.Add(this.lblEtat);
            this.Controls.Add(this.pnlEchiquier);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnJouer);
            this.Controls.Add(this.lstJoueurs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSChess";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstJoueurs;
        private System.Windows.Forms.Button btnJouer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblParties;
        private System.Windows.Forms.Label lblDefaites;
        private System.Windows.Forms.Label lblVictoires;
        private System.Windows.Forms.Panel pnlEchiquier;
        private System.Windows.Forms.Label lblEtat;


    }
}

