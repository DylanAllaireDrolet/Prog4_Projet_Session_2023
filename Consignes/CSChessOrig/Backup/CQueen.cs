using System;

public class CQueen : CPiece
{
    private int Color;

	public CQueen(int _Color)
	{
        this.Color = _Color;
	}

    public override string ToString()
    {
        return this.Color == 0 ? "w" : "W";
    }
}
