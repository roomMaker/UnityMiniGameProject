using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGem : MonoBehaviour
{
    public int GemScore;
    private BoxCollider2D _collider;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            MoveGetGem();
        }
    }

    private void MoveGetGem()
    {
        _collider.enabled = false;
        _rigidbody.gravityScale = 5f;
        _rigidbody.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
        GameManager.Instance.AddScore(GemScore);
    }
}
