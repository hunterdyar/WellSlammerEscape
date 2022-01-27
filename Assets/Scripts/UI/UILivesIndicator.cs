using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILivesIndicator : MonoBehaviour
{
    [SerializeField] private GameObject lifeIndicator;
    void Update()
    {
        if (transform.childCount != GameManager.Instance.LivesLeft())
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
        for (int i = 0; i < GameManager.Instance.LivesLeft(); i++)
        {
            Instantiate(lifeIndicator, transform);
        }
    }
}
