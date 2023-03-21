using System;

public class CPartie
{
    private CJoueur m_JoueurBlanc;
    private CJoueur m_JoueurNoir;
    private CBoard m_Echiquier;
    private bool m_Tour;
    private bool m_Echec;

	public CPartie(CJoueur _JoueurBlanc, CJoueur _JoueurNoir)
	{
        this.m_JoueurBlanc = _JoueurBlanc;
        this.m_JoueurNoir = _JoueurNoir;
        this.m_Echiquier = new CBoard();
        this.m_Tour = false;
        this.m_Echec = false;
	}

    public bool jouerCoup(int _srcX, int _srcY, int _dstX, int _dstY)
    {
        return false;
    }

    public override string ToString()
    {
        string strPartie = "";
        strPartie += this.m_Echiquier.ToString();
        if (this.m_Tour) strPartie += "1"; else strPartie += "0";
        if (this.m_Echec) strPartie += "1"; else strPartie += "0";
        return strPartie;
    }
}
