using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    // ������ ���� ����
    public float JumpRange = 30f;
    // ������ �̵� �ݰ�
    public float MoveRange = 4f;

    public float FrogWaitSecond;

    // ������Ʈ
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
    /// ������ �����ϴ� �ڷ�ƾ
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
    /// �������� �ٴڿ� ��Ҵ��� Ȯ��
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
