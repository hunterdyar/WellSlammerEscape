using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private LevelList _levelList;

    void Start()
    {
        _levelList.StartNewGame();
    }
}
