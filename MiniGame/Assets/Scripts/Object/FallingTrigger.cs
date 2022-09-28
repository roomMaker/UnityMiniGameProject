using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    //�������� ������Ʈ
    public GameObject[] FallingObjects;
    //Ʈ���� ���� ����
    [SerializeField]
    private AudioSource _triggerSound;

    private BoxCollider2D _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    //Ʈ���ſ� ������ ������Ʈ�� ������
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
