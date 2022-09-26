using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour
{
    // 쥐의 움직임 속도
    public float MoveSpeed = 1f;
    // 쥐의 움직임 범위
    public float RatMoveRange = 200f;

    // 속도 횟수 제한 카운트
    private float _moveCount = 0;
    // 컴포넌트
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
       _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(RatMoving());
    }

    /// <summary>
    /// 쥐의 움직임을 조절하는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator RatMoving()
    {
        while (true)
        {
            transform.Translate(new Vector2(-MoveSpeed * Time.fixedDeltaTime, 0f));
            _moveCount++;

            if (_moveCount > RatMoveRange)
            {
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                _moveCount = 0;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
