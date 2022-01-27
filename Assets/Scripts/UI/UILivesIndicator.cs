using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILivesIndicator : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private GameObject lifeIndicator;
    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (transform.childCount != _gameManager.LivesLeft())
        {
            RefreshChildren();
        }
    }

    void RefreshChildren()
    {
        //delete all children
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        
        //add the right number back
        for (int i = 0; i < _gameManager.LivesLeft(); i++)
        {
            Instantiate(lifeIndicator, transform);
        }
    }
}
