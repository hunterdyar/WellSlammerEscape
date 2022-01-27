using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    private GameManager _gameManager;
    private GameState currentlyDisplayedState;
    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        UpdateDisplayedState();
    }

    private void Update()
    {
        if (_gameManager.GetGameState() != currentlyDisplayedState)
        {
            UpdateDisplayedState();
        }
    }

    void UpdateDisplayedState()
    {
        if (_gameManager.GetGameState() == GameState.Lost)
        {
            losePanel.SetActive(true);
            winPanel.SetActive(false);
            currentlyDisplayedState = GameState.Lost;
        }
        else if(_gameManager.GetGameState() == GameState.Won)
        {
            losePanel.SetActive(false);
            winPanel.SetActive(true);
            currentlyDisplayedState = GameState.Won;

        }
        else if (_gameManager.GetGameState() == GameState.Playing)
        {
            losePanel.SetActive(false);
            winPanel.SetActive(false);
            currentlyDisplayedState = GameState.Playing;

        }
    }
}
