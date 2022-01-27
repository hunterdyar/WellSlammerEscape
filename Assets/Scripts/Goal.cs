using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
	private GameManager _gameManager;

	private void Awake()
	{
		_gameManager = FindObjectOfType<GameManager>();
	}

	public void PlayerAtGoal()
	{
		_gameManager.Win();
	}
}
