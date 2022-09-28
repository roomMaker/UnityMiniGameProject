using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractableBox : Interactable
{
    // ����Ŭ���� �̹��� ����
    public Image GameClear_Image;
    [SerializeField]
    private AudioSource _InteractSound;

    // ���� ȹ��� ���� Ŭ����
    public override void ActivateObject()
    {
        if(!GameManager.Instance.IsGameClear)
        {
            GameManager.Instance.IsGameClear = true;
            GameManager.Instance.CanMovePlayer = false;
            GameClear_Image.gameObject.SetActive(true);
            _InteractSound.Play();
        }
    }
}