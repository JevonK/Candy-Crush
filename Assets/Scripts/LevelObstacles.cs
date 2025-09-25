using UnityEngine;

public class LevelObstacles : Level
{
    public int numMoves;
    public GameGrid.PieceType[] obstacleTypes;
    private int numObstaclesLeft;

    private int movesUsed = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        type = LevelType.OBSTACLE;

        for (int i = 0; i < obstacleTypes.Length; i++)
        {
            numObstaclesLeft += gameGrid.GetPiecesOfType(obstacleTypes[i]).Count;
        }

        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(numObstaclesLeft);
        hud.SetRemaining(numMoves);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnMove()
    {
        movesUsed++;

        hud.SetRemaining(numMoves - movesUsed);

        if (numMoves - movesUsed == 0 && numObstaclesLeft > 0)
        {
            GameLose();
        }
    }

    public override void OnPieceCleared(GamePiece piece)
    {
        base.OnPieceCleared(piece);

        for (int i = 0; i < obstacleTypes.Length; i++)
        {
            if (obstacleTypes[i] == piece.Type)
            {
                numObstaclesLeft--;
                hud.SetTarget(numObstaclesLeft);

                if (numObstaclesLeft == 0)
                {
                    currentScore += 1000 * (numMoves - movesUsed);
                    hud.SetScore(currentScore);
                    GameWin();
                }
            }
        }
    }
}
