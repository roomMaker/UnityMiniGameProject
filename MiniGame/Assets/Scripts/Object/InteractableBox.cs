using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBox : Interactable
{
    //���⼭ ������Ʈ �̺�Ʈ ����
    public override void ActivateObject()
    {
        Destroy(this.gameObject);
        Debug.Log("�ӻ����");
    }
}
