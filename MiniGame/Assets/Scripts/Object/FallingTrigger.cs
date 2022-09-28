using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    //떨어지는 오브젝트
    public GameObject[] FallingObjects;
    //트리거 사운드 실행
    [SerializeField]
    private AudioSource _triggerSound;

    private BoxCollider2D _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    //트리거에 닿으면 오브젝트가 떨어짐
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FallingObjects[0].SetActive(true);
            //FallingObjects[0].AddComponent<Rigidbody2D>();
            FallingObjects[0].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            _triggerSound.Play();
            _boxCollider.enabled = false;
        }
    }

}
