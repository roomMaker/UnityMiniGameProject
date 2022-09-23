using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    //떨어지는 오브젝트
    public GameObject[] FallingObjects;

    //트리거에 닿으면 오브젝트가 떨어짐
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FallingObjects[0].SetActive(true);
            FallingObjects[0].AddComponent<Rigidbody2D>();
        }
    }

}
