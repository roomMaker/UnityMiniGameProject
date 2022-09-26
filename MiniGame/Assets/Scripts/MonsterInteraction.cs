using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInteraction : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            GameManager.Instance.DeadNameText.text = "¸ó½ºÅÍ¿Í ºÎµúÇô »ç¸Á!";
            GameManager.Instance.PlayerDie();
        }
    }
}
