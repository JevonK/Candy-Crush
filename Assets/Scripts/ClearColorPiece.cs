using UnityEngine;

public class ClearColorPiece : ClearablePiece
{

    private ColorPiece.ColorType color;

    public ColorPiece.ColorType Color
    {
        get { return color; }
        set { color = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Clear()
    {
        base.Clear();
        piece.GridRef.ClearColor(color);
    }
}
