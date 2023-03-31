using System;

public class CRook : CPiece
{
    private int Color;

	public CRook(int _Color)
	{
        this.Color = _Color;
	}

    public override string ToString()
    {
        return this.Color == 0 ? "t" : "T";
    }
}
