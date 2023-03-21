using System;

public class CBishop : CPiece
{
    private int Color;

	public CBishop(int _Color)
	{
        this.Color = _Color;
	}

    public override string ToString()
    {
        return this.Color == 0 ? "f" : "F";
    }
}
