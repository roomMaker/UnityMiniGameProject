using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractableBox : Interactable
{
    // 게임클리어 이미지 삽입
    public Image GameClear_Image;

    // 상자 획득시 게임 클리어
    public override void ActivateObject()
    {
        GameClear_Image.gameObject.SetActive(true);

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
