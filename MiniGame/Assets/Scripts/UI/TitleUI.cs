using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("엔터키 입력!!");
            SceneManager.LoadScene("ProtoTypeMap1");
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("게임 종료!!");
            Application.Quit();
        }
    }
}
