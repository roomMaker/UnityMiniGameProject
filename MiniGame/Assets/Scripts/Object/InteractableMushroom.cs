using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMushroom : Interactable
{
    public override void ActivateObject()
    {
        Destroy(this.gameObject);
        Debug.Log("╬савю╫");
    }
}
