using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    // 게임 매니저
    /// <summary>
    /// 플레이어 사망 처리
    /// </summary>
    public void PlayerDie()
    {
        Debug.Log("플레이어 사망!");
    }
}
