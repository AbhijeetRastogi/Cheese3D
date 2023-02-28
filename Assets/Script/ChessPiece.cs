using UnityEngine.EventSystems;
using UnityEngine.UI;

public  class ChessPiece
{
    public Type type;
    public Color color;
    public int[] position; // starts from bottom left (1,a) to (8,h)

    public ChessPiece()
    {
        color = Color.White;
        type = Type.Rook;
        position = new []{0, 0 };
    }
}
