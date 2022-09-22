using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBox : Interactable
{
    //여기서 오브젝트 이벤트 실행
    public override void ActivateObject()
    {
        Destroy(this.gameObject);
        Debug.Log("앙사라짐");
    }
}
