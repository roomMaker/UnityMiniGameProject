using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    //떨어지는 오브젝트
    public GameObject FallingObject;

    private void OnTriggerStay2D(Collider2D other)
    {
        //트리거에 닿으면 오브젝트가 떨어짐
        if (other.gameObject.CompareTag("Player")) FallingObject.SetActive(true);
    }

}
