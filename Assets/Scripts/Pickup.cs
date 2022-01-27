using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
   public override void Interact()
   {
      GameManager.Instance.GetExtraLife();
      Destroy(gameObject);
   }
}
