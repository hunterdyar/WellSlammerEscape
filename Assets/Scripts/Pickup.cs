using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
   private GameManager _gameManager;
   private void Awake()
   {
      _gameManager = FindObjectOfType<GameManager>();
   }

   public void PickUp()
   {
      _gameManager.GetExtraLife();
      Destroy(gameObject);
   }
}
