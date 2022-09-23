using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    // ���� �Ŵ���
    public GameObject Player;

    public bool CanMovePlayer;
    /// <summary>
    /// �÷��̾� ��� ó��
    /// </summary>
    public void PlayerDie()
    {
        Debug.Log("�÷��̾� ���!");
        Animator[] animator = Player.GetComponentsInChildren<Animator>();
        //Player.GetComponent<Animator>().SetBool("IsDie", true);
        animator[0].SetBool("IsDie", true);
        animator[1].SetBool("Dead", true);


    }

    IEnumerator PlayerDeadMove()
    {
        while(true)
        {

            yield return new WaitForSeconds(0.01f);
        }
    }

}
