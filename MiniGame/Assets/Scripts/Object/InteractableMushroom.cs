using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMushroom : Interactable 
{
    public AudioSource EatSound;

    public override void ActivateObject()
    {
        GameManager.Instance.SetGameOverUI();
        GameManager.Instance.PlayerDie();
        EatSound.Play();
        
    }
}
