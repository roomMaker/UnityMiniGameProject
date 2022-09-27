using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractableBox : Interactable
{
    // ����Ŭ���� �̹��� ����
    public Image GameClear_Image;

    // ���� ȹ��� ���� Ŭ����
    public override void ActivateObject()
    {
        GameClear_Image.gameObject.SetActive(true);

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
