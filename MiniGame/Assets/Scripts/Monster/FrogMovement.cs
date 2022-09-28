using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    // 개구리 점프 높이
    public float JumpRange = 30f;
    // 개구리 이동 반경
    public float MoveRange = 4f;

    public float FrogWaitSecond;

    // 컴포넌트
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FrogMoving());
    }

    /// <summary>
    /// 개구리 점프하는 코루틴
    /// </summary>
    /// <returns></returns>
    IEnumerator FrogMoving()
    {
        while (true)
        {
            yield return new WaitForSeconds(FrogWaitSecond);
            MoveRange *= -1;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
            _rigidbody.AddForce(new Vector2(MoveRange, JumpRange), ForceMode2D.Impulse);

            _animator.SetBool("IsJump", true);
        }
    }

    /// <summary>
    /// 개구리가 바닥에 닿았는지 확인
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            _animator.SetBool("IsJump", false);
        }
    }
}
