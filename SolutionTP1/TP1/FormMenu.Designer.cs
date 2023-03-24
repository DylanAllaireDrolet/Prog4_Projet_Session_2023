namespace TP1
{
    partial class FormMenu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.StripMenuControl = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuPlayers = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlPlayers = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.lsbPlayers = new System.Windows.Forms.ListBox();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnPlayers = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pnlPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuControl});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(868, 52);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // StripMenuControl
            // 
            this.StripMenuControl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuNewGame,
            this.StripMenuPlayers});
            this.StripMenuControl.Name = "StripMenuControl";
            this.StripMenuControl.Size = new System.Drawing.Size(119, 48);
            this.StripMenuControl.Text = "Menu";
            // 
            // StripMenuNewGame
            // 
            this.StripMenuNewGame.Name = "StripMenuNewGame";
            this.StripMenuNewGame.Size = new System.Drawing.Size(448, 54);
            this.StripMenuNewGame.Text = "New game";
            // 
            // StripMenuPlayers
            // 
            this.StripMenuPlayers.Name = "StripMenuPlayers";
            this.StripMenuPlayers.Size = new System.Drawing.Size(448, 54);
            this.StripMenuPlayers.Text = "Players";
            this.StripMenuPlayers.Click += new System.EventHandler(this.StripMenuPlayers_Click);
            // 
            // pnlPlayers
            // 
            this.pnlPlayers.Controls.Add(this.btnRemove);
            this.pnlPlayers.Controls.Add(this.lblUsername);
            this.pnlPlayers.Controls.Add(this.tbName);
            this.pnlPlayers.Controls.Add(this.btnAddPlayer);
            this.pnlPlayers.Controls.Add(this.lsbPlayers);
            this.pnlPlayers.Location = new System.Drawing.Point(12, 387);
            this.pnlPlayers.Name = "pnlPlayers";
            this.pnlPlayers.Size = new System.Drawing.Size(843, 563);
            this.pnlPlayers.TabIndex = 1;
            this.pnlPlayers.Visible = false;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(162, 219);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(179, 61);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Visible = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(15, 22);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(159, 32);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username :";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(178, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(331, 38);
            this.tbName.TabIndex = 2;
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(162, 116);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(179, 61);
            this.btnAddPlayer.TabIndex = 1;
            this.btnAddPlayer.Text = "Add player";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // lsbPlayers
            // 
            this.lsbPlayers.FormattingEnabled = true;
            this.lsbPlayers.ItemHeight = 31;
            this.lsbPlayers.Location = new System.Drawing.Point(524, 3);
            this.lsbPlayers.Name = "lsbPlayers";
            this.lsbPlayers.Size = new System.Drawing.Size(316, 531);
            this.lsbPlayers.TabIndex = 0;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(174, 77);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(512, 110);
            this.btnNewGame.TabIndex = 2;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            // 
            // btnPlayers
            // 
            this.btnPlayers.Location = new System.Drawing.Point(178, 220);
            this.btnPlayers.Name = "btnPlayers";
            this.btnPlayers.Size = new System.Drawing.Size(512, 110);
            this.btnPlayers.TabIndex = 3;
            this.btnPlayers.Text = "Players";
            this.btnPlayers.UseVisualStyleBackColor = true;
            this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 962);
            this.Controls.Add(this.btnPlayers);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.pnlPlayers);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlPlayers.ResumeLayout(false);
            this.pnlPlayers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem StripMenuControl;
        private System.Windows.Forms.ToolStripMenuItem StripMenuNewGame;
        private System.Windows.Forms.ToolStripMenuItem StripMenuPlayers;
        private System.Windows.Forms.Panel pnlPlayers;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.ListBox lsbPlayers;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnPlayers;
        private System.Windows.Forms.Button btnRemove;
    }
}

