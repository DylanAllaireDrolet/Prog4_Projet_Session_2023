using System;

public class CKing : CPiece
{
    private int Color;

	public CKing(int _Color)
	{
        this.Color = _Color;
	}

    public override string ToString()
    {
        return this.Color == 0 ? "r" : "R";
    }
}
