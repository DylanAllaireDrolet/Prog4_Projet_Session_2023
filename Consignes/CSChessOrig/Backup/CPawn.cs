using System;

public class CPawn : CPiece
{
    private int Color;

	public CPawn(int _Color)
	{
        this.Color = _Color;
	}

    public override string ToString()
    {
        return this.Color == 0 ? "p" : "P";
    }
}
