using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    // PlayerMove 스크립트에서 받아 올 좌 우 키값 변수
    public float MoveX;
    //상호작용할 PlayerInteract 스크립트가져옴
    [SerializeField]
    private PlayerInteract _playerInteract;
    //기획부분에서 상호작용 키를 바꿀것을 대비
    [SerializeField]
    private KeyCode _interactKey = KeyCode.E;
    // 일단 대략적으로 한 것이니 본인 입맛대로 수정 하셔도 됩니다. 대신, 수정하실 때는 팀원을에게 꼭 말씀해주세요
    private void Update()
    {
        // 상호작용 키 눌렀을 경우
        if (Input.GetKeyDown(_interactKey))
        {
            Debug.Log("키를 누름");
            //상호작용이 가능한가? 가능하면 키를 눌렀을경우 상호작용
            if(_playerInteract.IsInteractOK) { _playerInteract.GetInteractable().ActivateObject(); }
        }
        // 점프 키 처리 삭제 => PlayerMove 스크립트로 이동

        // 게임오버 처리
        if (Input.GetKeyDown(KeyCode.R) && GameManager.Instance.IsGameOver)
        {
            GameManager.Instance.IsGameOver = false;
            GameManager.Instance.CanMovePlayer = true;
            GameManager.Instance.InActiveGameOverUI();
            GameManager.Instance.ResetScore();
            GameManager.Instance.ResetSound.Play();
            GameManager.Instance.GameSceneIndex = 1;
            SceneManager.LoadScene(1);
        }

        if(Input.GetKeyDown(KeyCode.R) && GameManager.Instance.IsGameClear)
        {
            GameManager.Instance.GameSceneIndex = 0;
            GameManager.Instance.IsGameClear = false;
            GameManager.Instance.CanMovePlayer = true;
            GameManager.Instance.ResetScore();
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.R) && GameManager.Instance.IsPause)
        {
            GameManager.Instance.GameSceneIndex = 0;
            GameManager.Instance.ActiveTutorial();
            GameManager.Instance.PauseOnOff();
            SceneManager.LoadScene(0);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.PauseOnOff();
        }

        if(Input.GetKeyDown(KeyCode.Return) && GameManager.Instance.IsTutorialOver == false)
        {
            GameManager.Instance.InActiveTutorial();
        }

        // 좌 우 값 받아서 MoveX에 업데이트
        MoveX = Input.GetAxisRaw("Horizontal");
    }
}