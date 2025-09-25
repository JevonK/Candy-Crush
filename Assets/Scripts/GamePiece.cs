using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePiece : MonoBehaviour
{

    public int score;

    private int x;
    private int y;

    public int X
    {
        get { return x; }
        set
        {
            if (IsMovable())
            {
                x = value;
            }
        }
    }

    public int Y
    {
        get { return y; }
        set
        {
            if (IsMovable())
            {
                y = value;
            }
        }
    }

    private GameGrid.PieceType type;

    public GameGrid.PieceType Type
    {
        get { return type; }
        set { type = value; }
    }

    private GameGrid grid;

    public GameGrid GridRef
    {
        get { return grid; }
        set { grid = value; }
    }

    private MovablePiece movableComponent;

    public MovablePiece MovableComponent
    {
        get { return movableComponent; }
        set { movableComponent = value; }
    }

    private ColorPiece colorComponent;

    public ColorPiece ColorComponent
    {
        get { return colorComponent; }
        set { colorComponent = value; }
    }

    private ClearablePiece clearableComponent;

    public ClearablePiece ClearableComponent
    {
        get { return clearableComponent; }
    }

    void Awake()
    {
        movableComponent = GetComponent<MovablePiece>();
        colorComponent = GetComponent<ColorPiece>();
        clearableComponent = GetComponent<ClearablePiece>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Init(int _x, int _y, GameGrid _grid, GameGrid.PieceType _type)
    {
        this.x = _x;
        this.y = _y;
        this.type = _type;
        this.grid = _grid;
    }

    void OnMouseEnter()
    {
        grid.EnterPiece(this);
    }

    void OnMouseDown()
    {
        grid.PressPiece(this);
    }

    void OnMouseUp()
    {
        grid.ReleasePiece();
    }

    public bool IsMovable()
    {
        return movableComponent != null;
    }

    public bool IsColored()
    {
        return colorComponent != null;
    }

    public bool IsClearable()
    {
        return clearableComponent != null;
    }
}
