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
            Debug.Log("����Ű �Է�!!");
            SceneManager.LoadScene("ProtoTypeMap1");
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("���� ����!!");
            Application.Quit();
        }
    }
}
