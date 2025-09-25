using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Level : MonoBehaviour
{

    public enum LevelType
    {
        TIMER,
        OBSTACLE,
        MOVES,
    }

    public GameGrid gameGrid;
    public HUD hud;

    public int score1Star;
    public int score2Star;
    public int score3Star;

    protected int currentScore;

    protected bool didWin;

    protected LevelType type;

    public LevelType Type
    {
        get { return type; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hud.SetScore(currentScore);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void GameWin()
    {
        gameGrid.GameOver();
        didWin = true;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void GameLose()
    {
        gameGrid.GameOver();
        didWin = false;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void OnMove()
    {
    }

    public virtual void OnPieceCleared(GamePiece piece)
    {
        currentScore += piece.score;
        hud.SetScore(currentScore);
    }

    protected virtual IEnumerator WaitForGridFill()
    {
        while (gameGrid.IsFilling)
        {
            yield return 0;
        }

        if (didWin)
        {
            hud.OnGameWin(currentScore);
        }
        else
        {
            hud.OnGameLose();
        }
    }
}
