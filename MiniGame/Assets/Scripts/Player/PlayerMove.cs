using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    // ���� ������������ Ȯ���ϴ� ����
    private bool _isJump;

    // �÷��̾� �̵� ���Ϳ� �� X �� ����
    private float _playerX;
    // ���� �Ŀ�
    [SerializeField]
    private float _jumpPower = 15f;

    // �̵� �ӵ�
    [SerializeField]
    private float _moveSpeed = 5f;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.CanMovePlayer)
        {
            Move();
        }

    }

    private void Update()
    {
        Jump();
    }

    private void Move()
    {
        if (_input.MoveX != 0)
        {
            _animator.SetBool("IsRun", true);
        }
        else
        {
            _animator.SetBool("IsRun", false);
        }

        if (_input.MoveX > 0)
        {
            _spriteRenderer.flipX = false;
        }
        if (_input.MoveX < 0)
        {
            _spriteRenderer.flipX = true;
        }
        // �̵� ���Ϳ� �� ���� �� �Ҵ�
        _playerX = _input.MoveX * _moveSpeed * Time.fixedDeltaTime;

        // �̵� ���� ����
        Vector2 moveDirection = new Vector2(_playerX, 0f);

        //// �÷��̾� �̵�
        transform.Translate(moveDirection);
    }

    private void Jump()
    {
        // �����̽� Ű�� ������, ���� ������ ������ ��
        if (Input.GetKeyDown(KeyCode.Space) && _isJump == false && !_animator.GetBool("IsJump"))
        {
            _animator.SetBool("IsJump", true);
            _isJump = true;

            // ����!
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else if (_isJump && _rigidbody.velocity.y < 0.02f)
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
        }
    }

    // ���� �÷��̾��� ���� ���ɿ��� ó��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground") && collision.collider.transform.position.y <= transform.position.y - 0.9f)
        {
            _isJump = false;
            _animator.SetBool("IsJump", false);
        }

        if (collision.collider.CompareTag("Bridge"))
        {
            _isJump = false;
            _animator.SetBool("IsJump", false);
        }

    }
}
