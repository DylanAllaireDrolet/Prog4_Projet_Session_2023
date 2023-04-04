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
            this.lbl_pb = new System.Windows.Forms.Label();
            this.lbl_pw = new System.Windows.Forms.Label();
            this.btnNull_pw = new System.Windows.Forms.Button();
            this.btnNull_pb = new System.Windows.Forms.Button();
            this.btnResign_pb = new System.Windows.Forms.Button();
            this.btnResign_pw = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.Location = new System.Drawing.Point(18, 152);
            this.pnlBoard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(644, 575);
            this.pnlBoard.TabIndex = 0;
            this.pnlBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBoard_Paint);
            this.pnlBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_MouseClick);
            // 
            // lbl_pb
            // 
            this.lbl_pb.AutoSize = true;
            this.lbl_pb.Location = new System.Drawing.Point(21, 752);
            this.lbl_pb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_pb.Name = "lbl_pb";
            this.lbl_pb.Size = new System.Drawing.Size(92, 32);
            this.lbl_pb.TabIndex = 1;
            this.lbl_pb.Text = "label1";
            // 
            // lbl_pw
            // 
            this.lbl_pw.AutoSize = true;
            this.lbl_pw.Location = new System.Drawing.Point(21, 99);
            this.lbl_pw.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_pw.Name = "lbl_pw";
            this.lbl_pw.Size = new System.Drawing.Size(92, 32);
            this.lbl_pw.TabIndex = 2;
            this.lbl_pw.Text = "label1";
            // 
            // btnNull_pw
            // 
            this.btnNull_pw.Location = new System.Drawing.Point(18, 13);
            this.btnNull_pw.Name = "btnNull_pw";
            this.btnNull_pw.Size = new System.Drawing.Size(131, 60);
            this.btnNull_pw.TabIndex = 3;
            this.btnNull_pw.Text = "Draw ?";
            this.btnNull_pw.UseVisualStyleBackColor = true;
            this.btnNull_pw.Click += new System.EventHandler(this.btnNull_pw_Click);
            // 
            // btnNull_pb
            // 
            this.btnNull_pb.Location = new System.Drawing.Point(18, 806);
            this.btnNull_pb.Name = "btnNull_pb";
            this.btnNull_pb.Size = new System.Drawing.Size(131, 60);
            this.btnNull_pb.TabIndex = 4;
            this.btnNull_pb.Text = "Draw ?";
            this.btnNull_pb.UseVisualStyleBackColor = true;
            this.btnNull_pb.Click += new System.EventHandler(this.btnNull_pb_Click);
            // 
            // btnResign_pb
            // 
            this.btnResign_pb.Location = new System.Drawing.Point(168, 806);
            this.btnResign_pb.Name = "btnResign_pb";
            this.btnResign_pb.Size = new System.Drawing.Size(131, 60);
            this.btnResign_pb.TabIndex = 5;
            this.btnResign_pb.Text = "Resign";
            this.btnResign_pb.UseVisualStyleBackColor = true;
            this.btnResign_pb.Click += new System.EventHandler(this.btnResign_pb_Click);
            // 
            // btnResign_pw
            // 
            this.btnResign_pw.Location = new System.Drawing.Point(155, 13);
            this.btnResign_pw.Name = "btnResign_pw";
            this.btnResign_pw.Size = new System.Drawing.Size(131, 60);
            this.btnResign_pw.TabIndex = 6;
            this.btnResign_pw.Text = "Resign";
            this.btnResign_pw.UseVisualStyleBackColor = true;
            this.btnResign_pw.Click += new System.EventHandler(this.btnResign_pw_Click);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 875);
            this.Controls.Add(this.btnResign_pw);
            this.Controls.Add(this.btnResign_pb);
            this.Controls.Add(this.btnNull_pb);
            this.Controls.Add(this.btnNull_pw);
            this.Controls.Add(this.lbl_pw);
            this.Controls.Add(this.lbl_pb);
            this.Controls.Add(this.pnlBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Label lbl_pb;
        private System.Windows.Forms.Label lbl_pw;
        private System.Windows.Forms.Button btnNull_pw;
        private System.Windows.Forms.Button btnNull_pb;
        private System.Windows.Forms.Button btnResign_pb;
        private System.Windows.Forms.Button btnResign_pw;
    }
}