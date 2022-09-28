using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMushroom : Interactable 
{
    [SerializeField]
    private AudioSource Sound;
    public override void ActivateObject()
    {
        GameManager.Instance.PlayerDie();
        Sound.Play();   
    }
}
