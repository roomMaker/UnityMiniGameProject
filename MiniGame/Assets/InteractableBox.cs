using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBox : Interactable
{
    public override void ActivateObject()
    {
        Destroy(this.gameObject);

    }
}
