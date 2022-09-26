using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextMap : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.GameSceneIndex++;
            SceneManager.LoadScene(GameManager.Instance.GameSceneIndex);
        }
    }
}
