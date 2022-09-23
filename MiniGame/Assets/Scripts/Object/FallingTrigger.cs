using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    //�������� ������Ʈ
    public GameObject[] FallingObjects;

    //Ʈ���ſ� ������ ������Ʈ�� ������
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FallingObjects[0].SetActive(true);
            FallingObjects[0].AddComponent<Rigidbody2D>();
        }
    }

}
