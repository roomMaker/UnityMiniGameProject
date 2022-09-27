using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDead : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            GameManager.Instance.DeadNameText.text = "¶³¾îÁ® »ç¸ÁÇÏ¿´½À´Ï´Ù..";
            GameManager.Instance.PlayerDie();
        }
    }
}
