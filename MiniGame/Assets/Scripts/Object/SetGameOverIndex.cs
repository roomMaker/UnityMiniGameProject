using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameOverIndex : MonoBehaviour
{
    public int gameOverIndex;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            GameManager.Instance.SetGameOverUI(gameOverIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.SetGameOverUI(gameOverIndex);
        }
    }
}
