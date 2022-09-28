using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractableBox : Interactable
{
    // 게임클리어 이미지 삽입
    public Image GameClear_Image;
    [SerializeField]
    private AudioSource _InteractSound;

    // 상자 획득시 게임 클리어
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