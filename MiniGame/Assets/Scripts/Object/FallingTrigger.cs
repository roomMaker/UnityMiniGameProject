using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    //�������� ������Ʈ
    public GameObject FallingObject;

    private void OnTriggerStay2D(Collider2D other)
    {
        //Ʈ���ſ� ������ ������Ʈ�� ������
        if (other.gameObject.CompareTag("Player")) FallingObject.SetActive(true);
    }

}
