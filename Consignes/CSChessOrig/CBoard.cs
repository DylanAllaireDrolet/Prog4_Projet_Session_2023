using System;

public class CBoard {
    private CPiece[,] Echiquier;

	public CBoard() {
        // Initialisation d'un échiquier de 8x8...
        this.Echiquier = new CPiece[8, 8];

        // Initialisation des pièces noires...
        this.Echiquier[0, 0] = new CRook(CPiece.NOIR);
        this.Echiquier[0, 1] = new CKnight(CPiece.NOIR);
        this.Echiquier[0, 2] = new CBishop(CPiece.NOIR);
        this.Echiquier[0, 3] = new CQueen(CPiece.NOIR);
        this.Echiquier[0, 4] = new CKing(CPiece.NOIR);
        this.Echiquier[0, 5] = new CBishop(CPiece.NOIR);
        this.Echiquier[0, 6] = new CKnight(CPiece.NOIR);
        this.Echiquier[0, 7] = new CRook(CPiece.NOIR);
        for (int i = 0; i < 8; i++) this.Echiquier[1, i] = new CPawn(CPiece.NOIR);

        // Initialisation des cases vides...
        for (int i = 0; i < 8; i++) this.Echiquier[2, i] = null;
        for (int i = 0; i < 8; i++) this.Echiquier[3, i] = null;
        for (int i = 0; i < 8; i++) this.Echiquier[4, i] = null;
        for (int i = 0; i < 8; i++) this.Echiquier[5, i] = null;

        // Initialisation des pièce blanches...
        for (int i = 0; i < 8; i++) this.Echiquier[6, i] = new CPawn(CPiece.BLANC);
        this.Echiquier[7, 0] = new CRook(CPiece.BLANC);
        this.Echiquier[7, 1] = new CKnight(CPiece.BLANC);
        this.Echiquier[7, 2] = new CBishop(CPiece.BLANC);
        this.Echiquier[7, 3] = new CQueen(CPiece.BLANC);
        this.Echiquier[7, 4] = new CKing(CPiece.BLANC);
        this.Echiquier[7, 5] = new CBishop(CPiece.BLANC);
        this.Echiquier[7, 6] = new CKnight(CPiece.BLANC);
        this.Echiquier[7, 7] = new CRook(CPiece.BLANC);    
    }

    public override string ToString()
    {
        string strBoard = "";
        for (int r = 0; r < 8; r++)
            for (int c = 0; c < 8; c++)
                strBoard += this.Echiquier[r, c] != null ? this.Echiquier[r, c].ToString() : "-";
        return strBoard;
    }
}
