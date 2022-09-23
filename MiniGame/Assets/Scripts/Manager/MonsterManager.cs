using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // ���͵��� ������ �ӵ�
    public float MoveSpeed = 1f;

    // ���� ������ ����
    public float RatMoveRange = 200f;
    // �������� ������ ����
    public float EagleMoveRange = 200f;
    // ������ ���� ����
    public float FrogJumpRange = 15f;
    // ������ �̵� �ݰ�
    public float FrogMoveRange = 4f;

    // ������ ������Ʈ
    [SerializeField]
    private GameObject Eagle;
    // �� ������Ʈ
    [SerializeField]
    private GameObject Rat;
    // ������ ������Ʈ
    [SerializeField]
    private GameObject Frog;

    // ���� �ð����� ����Ǵ� �̺�Ʈ Ÿ�� ����
    private float _elapsedTime = 0f;

    // Ƚ�� ���� ī��Ʈ
    private float _eagleCount = 0;
    private float _ratCount = 0;

    // ������ ���� ����, ������ ����
    private bool _isFrogLeftJump = false;

    // ������Ʈ ��������
    private SpriteRenderer _spriteRenderer_rat;
    private SpriteRenderer _spriteRenderer_frog;
    private Rigidbody2D _rigidbody_frog;
    private Animator _animator;

    // �ڷ�ƾ ��ŸƮ
    private void Start()
    {
        _animator = Frog.GetComponent<Animator>();
        _rigidbody_frog = Frog.GetComponent<Rigidbody2D>();
        _spriteRenderer_rat = Rat.GetComponent<SpriteRenderer>();
        _spriteRenderer_frog = Frog.GetComponent<SpriteRenderer>();
        StartCoroutine(EAGLE_Updown());
        StartCoroutine(RatMoving());
        StartCoroutine(FrogMoving());
    }

    // ������ ��, �Ʒ��� �̵��ϴ� �ڷ�ƾ
    IEnumerator EAGLE_Updown()
    {
        while (true)
        {
            Eagle.transform.Translate(new Vector2(0f, MoveSpeed * Time.fixedDeltaTime));

            _eagleCount++;

            if (_eagleCount > EagleMoveRange)
            {
                _eagleCount = 0;
                MoveSpeed *= -1;
            }
            yield return new WaitForSeconds(0.001f);
        }
    }

    // �� ��,�� ������
    IEnumerator RatMoving()
    {
        while (true)
        {
            Rat.transform.Translate(new Vector2(-MoveSpeed * Time.fixedDeltaTime, 0f));
            _ratCount++;

            if (_ratCount > RatMoveRange)
            {
                _spriteRenderer_rat.flipX = !_spriteRenderer_rat.flipX;
                _ratCount = 0;
            }
            yield return new WaitForSeconds(0.001f);
        }
    }

    // ������ ���� ����, ������ ���� ������
    IEnumerator FrogMoving()
    {
        while (true)
        {
            _elapsedTime += Time.fixedDeltaTime;
            Debug.Log($"���� : {_elapsedTime}��");

            if (_isFrogLeftJump)
            {
                _animator.SetBool("IsJump", true);
                _spriteRenderer_frog.flipX = true;

            }
            else
            {
                _animator.SetBool("IsIdle", true);
                _spriteRenderer_frog.flipX = false;
            }

            // �������� ����! 
            if (_isFrogLeftJump)
            {
                _rigidbody_frog.AddForce(new Vector2(FrogMoveRange, FrogJumpRange), ForceMode2D.Impulse);
                _isFrogLeftJump = false;
            }
            // ���������� ����!
            else
            {
                _rigidbody_frog.AddForce(new Vector2(-FrogMoveRange, FrogJumpRange), ForceMode2D.Impulse);
                _isFrogLeftJump = true;
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
