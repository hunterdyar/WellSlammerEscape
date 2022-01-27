using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance => _instance;
    private static GameManager _instance;
    
    public static Action<GameState> OnGameStateChange;
    [SerializeField] private LevelList levelList;
    [SerializeField] private int lives;
    private int turnCount = 0;

    private GameState gameState;//0 is playing. 1 is lost. 2 is won. 3 is paused.

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
       ChangeGameState(GameState.Playing);
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

    private void ChangeGameState(GameState newGameState)
    {
        gameState = newGameState;
        OnGameStateChange?.Invoke(newGameState);
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public void Lose()
    {
        if (gameState != GameState.Won)
        {
            ChangeGameState(GameState.Lost);
            Debug.Log("game over");
        }
    }

    public void Win()
    {
        ChangeGameState(GameState.Won);
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
