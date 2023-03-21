using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSChess
{
    public partial class frmMain : Form
    {
        private int CaseSourceX, CaseSourceY;

        private CJoueur[] tabJoueurs;
        private CPartie Partie;

        public frmMain()
        {
            this.Partie = null;
            tabJoueurs = new CJoueur[10];
            // La classe joueur possède deux constructeur : CJoueur(string Nom) et CJoueur(string Nom, int Vistoire, int Defaite, int Classement)
            tabJoueurs[0] = new CJoueur("Roiz, Michael", 22, 6, 2630);
            tabJoueurs[1] = new CJoueur("Ehlvest, Jaan", 22, 22, 2629);
            tabJoueurs[2] = new CJoueur("Kramnik, Vladimir", 1, 0, 2769);
            tabJoueurs[3] = new CJoueur("Smirin, Ilia", 8, 2, 2649);
            tabJoueurs[4] = new CJoueur("Fridman, Daniel", 12, 6, 2628);
            tabJoueurs[5] = new CJoueur("Polgar, Judit", 7, 3, 2707);
            tabJoueurs[6] = new CJoueur("Leko, Peter", 5, 4, 2751);
            tabJoueurs[7] = new CJoueur("Aronian, Levon", 10, 5, 2750);
            tabJoueurs[8] = new CJoueur("Milov, Vadim", 1, 0, 2675);
            tabJoueurs[9] = new CJoueur("Ni, Hua", 20, 4, 2681);

            InitializeComponent();

            this.CaseSourceX = this.CaseSourceY = -1;

            Array.Sort(tabJoueurs);
            lstJoueurs.SelectionMode = SelectionMode.MultiExtended;
            lstJoueurs.DataSource = this.tabJoueurs;
        }

        private void btnJouer_Click(object sender, EventArgs e)
        {
            // Création d'une partie s'il y a 2 et seulement 2 joueurs sélectionnés...
            if ((lstJoueurs.SelectedItems.Count < 2) || (lstJoueurs.SelectedItems.Count > 2))
                MessageBox.Show("Vous devez sélectionner deux joueurs pour débuter une partie!");
            else
            {
                btnJouer.Enabled = false;
                lstJoueurs.Enabled = false;
                // La classe CPartie possède un seul constructeur : CPartie(CJoueur JoueurBlanc, CJoueur JoueurNoir)
                this.Partie = new CPartie((CJoueur)lstJoueurs.SelectedItems[0], (CJoueur)lstJoueurs.SelectedItems[1]);
                this.pnlEchiquier.Refresh();
            }
        }

        private void pnlEchiquier_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics myGraph = pnlEchiquier.CreateGraphics();
            // S'il s'agit de la même case de départ...
            if ((this.CaseSourceX == e.X / 30) && (this.CaseSourceY == e.Y / 30))
            {
                myGraph.DrawRectangle(new Pen(Color.Chocolate, 2), this.CaseSourceX * 30, this.CaseSourceY * 30, 30, 30);
                this.CaseSourceX = this.CaseSourceY = -1;
            }
            // S'il n'y a pas de case départ sélectionnée...
            else if ((this.CaseSourceX == -1) && (this.CaseSourceY == -1))
            {
                this.CaseSourceX = e.X / 30;
                this.CaseSourceY = e.Y / 30;
                myGraph.DrawRectangle(new Pen(Color.DarkGreen, 2), this.CaseSourceX * 30, this.CaseSourceY * 30, 30, 30);
            }
            // S'il s'agit de la case destination...
            else
            {
                myGraph.DrawRectangle(new Pen(Color.Chocolate, 2), this.CaseSourceX * 30, this.CaseSourceY * 30, 30, 30);
                if (!this.Partie.jouerCoup(this.CaseSourceX, this.CaseSourceY, e.X / 30, e.Y / 30))
                {
                    lblEtat.Text = "Coup illégal...";
                    lblEtat.Refresh();
                }
                System.Threading.Thread.Sleep(1000);
                pnlEchiquier.Refresh();
                this.CaseSourceX = this.CaseSourceY = -1;
            }
        }

        private void pnlEchiquier_Paint(object sender, PaintEventArgs e)
        {
            Bitmap imgPiece = null;
            char[] tabEchiquier = null;
            if (this.Partie != null) tabEchiquier = this.Partie.ToString().ToCharArray();
            Graphics myGraph = pnlEchiquier.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.Chocolate);

            // Dessine l'échiquier...
            myGraph.DrawRectangle(new Pen(Color.Chocolate), 0, 0, 240, 240);
            for (int c = 0; c < 8; c++)
                for (int r = c % 2 == 0 ? 1 : 0; r < 8; r += 2)
                    myGraph.FillRectangle(myBrush, r * 30, c * 30, 30, 30);

            // Dessine les pièces...
            for (int c = 0; c < 8; c++)
                for (int r = 0; r < 8; r++)
                {
                    if (this.Partie != null) {
                        switch (tabEchiquier[c * 8 + r])
                        {
                            case 'P':
                                imgPiece = new Bitmap("pionn.bmp");
                                break;
                            case 'p':
                                imgPiece = new Bitmap("pionb.bmp");
                                break;
                            case 'T':
                                imgPiece = new Bitmap("tourn.bmp");
                                break;
                            case 't':
                                imgPiece = new Bitmap("tourb.bmp");
                                break;
                            case 'C':
                                imgPiece = new Bitmap("cavaliern.bmp");
                                break;
                            case 'c':
                                imgPiece = new Bitmap("cavalierb.bmp");
                                break;
                            case 'F':
                                imgPiece = new Bitmap("foun.bmp");
                                break;
                            case 'f':
                                imgPiece = new Bitmap("foub.bmp");
                                break;
                            case 'W':
                                imgPiece = new Bitmap("reinen.bmp");
                                break;
                            case 'w':
                                imgPiece = new Bitmap("reineb.bmp");
                                break;
                            case 'R':
                                imgPiece = new Bitmap("roin.bmp");
                                break;
                            case 'r':
                                imgPiece = new Bitmap("roib.bmp");
                                break;
                        }
                        if (imgPiece != null)
                        {
                            imgPiece.MakeTransparent(imgPiece.GetPixel(1, 1));
                            myGraph.DrawImage(imgPiece, r * 30, c * 30);
                        }
                        // Affiche l'état de la partie...
                        lblEtat.Text = "";
                        if (tabEchiquier[65] == '1') lblEtat.Text += "ÉCHEC : ";
                        if (tabEchiquier[64] == '0') lblEtat.Text += "Aux blancs à jouer..."; else lblEtat.Text += "Aux noirs à jouer...";
                    }
                }
        }

        private void lstJoueurs_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstJoueurs.SelectedItems.Count == 1)
            {
                CJoueur Joueur = (CJoueur)lstJoueurs.SelectedItems[0];
                lblParties.Text = "Parties : " + Joueur.Parties.ToString();
                lblVictoires.Text = "Victoires : " + Joueur.Victoires.ToString();
                lblDefaites.Text = "Défaites : " + Joueur.Defaites.ToString();
            }
            else if (lstJoueurs.SelectedItems.Count == 2)
            {
                lblParties.Text = "";
                CJoueur JoueurB = (CJoueur)lstJoueurs.SelectedItems[0];
                CJoueur JoueurN = (CJoueur)lstJoueurs.SelectedItems[1];
                lblVictoires.Text = "B: (" + (JoueurB + JoueurN).Classement + ", " + (JoueurN - JoueurB).Classement + ")";
                lblDefaites.Text = "N: (" + (JoueurB - JoueurN).Classement + ", " + (JoueurN + JoueurB).Classement + ")";
            }
        }
    }
}