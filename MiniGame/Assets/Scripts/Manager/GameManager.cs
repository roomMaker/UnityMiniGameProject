using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int GameSceneIndex = 1;
    // ���� �Ŵ���
    public GameObject Player;

    public bool IsTutorialOver;

    public bool IsGameOver;
    
    public bool CanMovePlayer = true;

    public bool IsPause;

    public Text DeadNameText;
    // ���� UI �ؽ�Ʈ
    public Text ScoreText;
    // ����
    public int Score;

    public GameObject TutorialUI;

    public GameObject[] GameOverUI;

    public GameObject PauseUI;


    /// <summary>
    /// �÷��̾� ��� �Լ�
    /// </summary>
    public void PlayerDie()
    {
        Player = FindObjectOfType<PlayerMove>().gameObject;
        if(Player == null)
        {
            return;
        }
        CanMovePlayer = false;


        Debug.Log("�÷��̾� ���!");
        
        Animator[] animator = Player.GetComponentsInChildren<Animator>();
        animator[0].SetBool("IsDie", true);
        animator[1].SetBool("Dead", true);

        
        StartCoroutine(PlayerDeadMove());
    }

    IEnumerator PlayerDeadMove()
    {
        Player.GetComponent<CapsuleCollider2D>().enabled = false;
        Player.GetComponent<Rigidbody2D>().drag = 10000f;

        yield return new WaitForSeconds(0.4f);
        Player.GetComponent<Rigidbody2D>().drag = 0f;
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 15f, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1f);
        ActiveGameOverUI();
        IsGameOver = true;
    }

    public void InActiveTutorial()
    {
        Time.timeScale = 1f;
        IsTutorialOver = true;
        TutorialUI.SetActive(false);
    }
    
    /// <summary>
    /// ���ھ� ���� �� ���� �Լ�
    /// </summary>
    /// <param name="score">���� ���ھ�</param>
    public void AddScore(int score)
    {
        Score += score;
        ScoreText.text = $"Score : {Score}";
    }
    /// <summary>
    /// ���ھ� ���� �Լ�
    /// </summary>
    public void ResetScore()
    {
        Score = 0;
        ScoreText.text = $"Score : {Score}";
    }

    /// <summary>
    /// ���ӿ��� UI Ȱ��ȭ
    /// </summary>
    public void ActiveGameOverUI()
    {
        //GameOverUI.SetActive(true);
    }

    /// <summary>
    /// ���ӿ��� UI ��Ȱ��ȭ
    /// </summary>
    public void InActiveGameOverUI()
    {
        //GameOverUI.SetActive(false);
    }

    /// <summary>
    /// �Ͻ����� ó�� �Լ�
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
