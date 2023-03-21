using System;

public class CJoueur : IComparable
{
    private string m_Nom;
    private int m_Victoire;
    private int m_Defaite;
    private int m_Classement;

    public CJoueur(string _Nom, int _Victoire, int _Defaite, int _Classement)
    {
        this.m_Nom = _Nom;
        this.m_Victoire = _Victoire;
        this.m_Defaite = _Defaite;
        this.m_Classement = _Classement;
    }

    public CJoueur(CJoueur _Source)
    {
        this.m_Nom = _Source.m_Nom;
        this.m_Victoire = _Source.m_Victoire;
        this.m_Defaite = _Source.m_Defaite;
        this.m_Classement = _Source.m_Classement;
    }

    public int Victoires
    {
        get
        {
            return this.m_Victoire;
        }
    }

    public int Defaites
    {
        get
        {
            return this.m_Defaite;
        }
    }

    public int Classement
    {
        get
        {
            return this.m_Classement;
        }
    }

    public int Parties
    {
        get
        {
            return this.m_Victoire + this.m_Defaite;
        }
    }

    public override string ToString()
    {
        return this.m_Nom + " (" + this.m_Classement.ToString() + ")";
    }

    public int CompareTo(Object _Source)
    {
        CJoueur srcPlayer = (CJoueur)_Source;
        return this.m_Classement == srcPlayer.m_Classement ? 0 : this.m_Classement - srcPlayer.m_Classement;
    }

    public static CJoueur operator +(CJoueur _JoueurG, CJoueur _JoueurD)
    {
        CJoueur tmpPlayer = new CJoueur(_JoueurG);
        int Difference = Math.Abs(tmpPlayer.m_Classement - _JoueurD.m_Classement);
        if (Math.Abs(tmpPlayer.m_Classement - _JoueurD.m_Classement) < 500)
        {
            if (tmpPlayer.m_Classement > _JoueurD.m_Classement)
                tmpPlayer.m_Classement += Difference / 4;
            else
                tmpPlayer.m_Classement += Difference / 2;
        }
        else
            if (tmpPlayer.m_Classement > _JoueurD.m_Classement)
                tmpPlayer.m_Classement += Difference / 2;

        return tmpPlayer;
    }

    public static CJoueur operator -(CJoueur _JoueurG, CJoueur _JoueurD)
    {
        CJoueur tmpPlayer = new CJoueur(_JoueurG);
        int Difference = Math.Abs(tmpPlayer.m_Classement - _JoueurD.m_Classement);
        if (Math.Abs(tmpPlayer.m_Classement - _JoueurD.m_Classement) < 500)
        {
            if (tmpPlayer.m_Classement > _JoueurD.m_Classement)
                tmpPlayer.m_Classement -= Difference / 2;
            else
                tmpPlayer.m_Classement -= Difference / 4;
        }
        else
            if (tmpPlayer.m_Classement > _JoueurD.m_Classement)
                tmpPlayer.m_Classement -= Difference / 2;

        return tmpPlayer;
    }
}
