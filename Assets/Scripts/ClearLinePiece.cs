using UnityEngine;
using System.Collections;

public class ClearLinePiece : ClearablePiece
{

    public bool isRow;

    // Start is called once before the first execution of Update after the ClearablePiece is created
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

        if (isRow)
        {
            // Clear row
            piece.GridRef.ClearRow(piece.Y);
        }
        else
        {
            // Clear column
            piece.GridRef.ClearColumn(piece.X);
        }
    }
}
