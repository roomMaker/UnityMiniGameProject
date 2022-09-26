using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonBehaviour<GameManager>
{
    public int GameSceneIndex;
    // ���� �Ŵ���
    public GameObject Player;

    public bool IsGameOver;

    public bool CanMovePlayer;

    public Text ScoreText;

    public int Score;
    /// <summary>
    /// �÷��̾� ��� �Լ�
    /// </summary>
    public void PlayerDie()
    {
        Player = FindObjectOfType<PlayerMove>().gameObject;
        IsGameOver = true;

        Debug.Log("�÷��̾� ���!");
        
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
    }
    
    /// <summary>
    /// ���ھ� ���� �� ���� �Լ�
    /// </summary>
    /// <param name="score">���� ���ھ�</param>
    public void SetScore(int score)
    {
        Score += score;
        ScoreText.text = $"Score : {Score}";
    }
}
