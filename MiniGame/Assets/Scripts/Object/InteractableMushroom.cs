using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMushroom : Interactable 
{
    public override void ActivateObject()
    {
        GameManager.Instance.DeadNameText.text = "독 버섯에 의해 사망하였습니다..";
        GameManager.Instance.PlayerDie();
    }
}
