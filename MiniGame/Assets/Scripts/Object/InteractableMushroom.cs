using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMushroom : Interactable 
{
    public override void ActivateObject()
    {
        GameManager.Instance.PlayerDie();
    }
}
