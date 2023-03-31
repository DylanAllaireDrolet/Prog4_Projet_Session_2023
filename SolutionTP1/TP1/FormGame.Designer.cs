namespace TP1
{
    partial class FormGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.lbl_pw = new System.Windows.Forms.Label();
            this.lbl_pb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.Location = new System.Drawing.Point(17, 76);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(643, 575);
            this.pnlBoard.TabIndex = 0;
            this.pnlBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBoard_Paint);
            this.pnlBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_MouseClick);
            // 
            // lbl_pw
            // 
            this.lbl_pw.AutoSize = true;
            this.lbl_pw.Location = new System.Drawing.Point(21, 676);
            this.lbl_pw.Name = "lbl_pw";
            this.lbl_pw.Size = new System.Drawing.Size(92, 32);
            this.lbl_pw.TabIndex = 1;
            this.lbl_pw.Text = "label1";
            // 
            // lbl_pb
            // 
            this.lbl_pb.AutoSize = true;
            this.lbl_pb.Location = new System.Drawing.Point(21, 24);
            this.lbl_pb.Name = "lbl_pb";
            this.lbl_pb.Size = new System.Drawing.Size(92, 32);
            this.lbl_pb.TabIndex = 2;
            this.lbl_pb.Text = "label1";
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 719);
            this.Controls.Add(this.lbl_pb);
            this.Controls.Add(this.lbl_pw);
            this.Controls.Add(this.pnlBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Label lbl_pw;
        private System.Windows.Forms.Label lbl_pb;
    }
}