using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;

    private void OnEnable()
    {
        GameManager.OnGameStateChange += UpdateDisplayedState;
    }
    private void OnDisable()
    {
        GameManager.OnGameStateChange -= UpdateDisplayedState;
    }

    void UpdateDisplayedState(GameState newState)
    {
        if (newState == GameState.Lost)
        {
            losePanel.SetActive(true);
            winPanel.SetActive(false);
        }
        else if(newState == GameState.Won)
        {
            losePanel.SetActive(false);
            winPanel.SetActive(true);

        }
        else if (newState == GameState.Playing)
        {
            losePanel.SetActive(false);
            winPanel.SetActive(false);

        }
    }
}
