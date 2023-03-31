using System;

public class CKnight : CPiece
{
    private int Color;

	public CKnight(int _Color)
	{
        this.Color = _Color;
	}

    public override string ToString()
    {
        return this.Color == 0 ? "c" : "C";
    }
}
