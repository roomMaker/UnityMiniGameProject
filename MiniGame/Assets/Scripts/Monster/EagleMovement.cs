using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MonoBehaviour
{
    // 독수리 움직임
    public float MoveSpeed = 1f;
    // 독수리 움직임 범위
    public float MoveRange = 200f;

    // 독수리 횟수 제한 카운트
    private float _moveCount = 0f;

    private void Start()
    {
        StartCoroutine(EagleMoving());
    }

    /// <summary>
    /// 독수리의 움직임을 조절하는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator EagleMoving()
    {
        while (true)
        {
            transform.Translate(new Vector2(0f, MoveSpeed * Time.fixedDeltaTime));

            _moveCount++;

            if (_moveCount > MoveRange)
            {
                _moveCount = 0;
                MoveSpeed *= -1;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
