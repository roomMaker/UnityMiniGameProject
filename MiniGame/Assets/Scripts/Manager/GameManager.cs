using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int GameSceneIndex = 1;
    // 게임 매니저
    public GameObject Player;

    public bool IsGameOver;
    
    public bool CanMovePlayer = true;

    public bool IsPause;

    public Text DeadNameText;
    // 점수 UI 텍스트
    public Text ScoreText;
    // 점수
    public int Score;

    public GameObject GameOverUI;

    public GameObject PauseUI;


    /// <summary>
    /// 플레이어 사망 함수
    /// </summary>
    public void PlayerDie()
    {
        Player = FindObjectOfType<PlayerMove>().gameObject;
        if(Player == null)
        {
            return;
        }
        CanMovePlayer = false;


        Debug.Log("플레이어 사망!");
        
        Animator[] animator = Player.GetComponentsInChildren<Animator>();
        animator[0].SetBool("IsDie", true);
        animator[1].SetBool("Dead", true);

        
        StartCoroutine(PlayerDeadMove());
    }

    IEnumerator PlayerDeadMove()
    {
        Player.GetComponent<BoxCollider2D>().enabled = false;
        Player.GetComponent<Rigidbody2D>().drag = 10000f;

        yield return new WaitForSeconds(0.4f);
        Player.GetComponent<Rigidbody2D>().drag = 0f;
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1f);
        ActiveGameOverUI();
        IsGameOver = true;
    }
    
    /// <summary>
    /// 스코어 증가 및 설정 함수
    /// </summary>
    /// <param name="score">증가 스코어</param>
    public void SetScore(int score)
    {
        Score += score;
        ScoreText.text = $"Score : {Score}";
    }

    /// <summary>
    /// 게임오버 UI 활성화
    /// </summary>
    public void ActiveGameOverUI()
    {
        GameOverUI.SetActive(true);
    }

    /// <summary>
    /// 게임오버 UI 비활성화
    /// </summary>
    public void InActiveGameOverUI()
    {
        GameOverUI.SetActive(false);
    }

    /// <summary>
    /// 일시정지 처리 함수
    /// </summary>
    public void PauseOnOff()
    {
        IsPause = !IsPause;
        if(IsPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        PauseUI.SetActive(IsPause);
    }


}
