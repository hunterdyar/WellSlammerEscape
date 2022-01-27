using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelList levelList;
    [SerializeField] private int lives;
    private int turnCount = 0;

    private GameState gameState;//0 is playing. 1 is lost. 2 is won. 3 is paused.

    void Start()
    {
        gameState = GameState.Playing;
    }

    public void GetExtraLife()
    {
        turnCount--;
    }

    public int LivesLeft()
    {
        return lives - turnCount;
    }
    public void TurnTaken()
    {
        turnCount++;
        if (turnCount == lives)
        {
            Lose();
        }
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public void Lose()
    {
        if (gameState != GameState.Won)
        {
            gameState = GameState.Lost;
            Debug.Log("game over");
        }
    }

    public void Win()
    {
        gameState = GameState.Won;
        Debug.Log("won!");
    }

    void Update()
    {
        //For testing
        if (Input.GetKeyDown(KeyCode.R))
        {
            levelList.RestartLevel();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            levelList.GoToNextLevel();
        }
    }
}
