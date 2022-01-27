using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : Interactable
{
	public override void Interact()
	{
		GameManager.Instance.Win();
	}
}
