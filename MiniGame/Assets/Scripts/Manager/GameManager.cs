using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    // ���� �Ŵ���
    /// <summary>
    /// �÷��̾� ��� ó��
    /// </summary>
    public void PlayerDie()
    {
        Debug.Log("�÷��̾� ���!");
    }
}
