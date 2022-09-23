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
        if(!GameManager.Instance.IsGameOver)
        {
            Move();
        }
    }

    private void Update()
    {
        Jump();
        if(Input.GetMouseButton(0))
        {
            GameManager.Instance.PlayerDie();
        }
    }

    private void Move()
    {
        if(_input.MoveX != 0)
        {
            _animator.SetBool("IsRun", true);
        }
        else
        {
            _animator.SetBool("IsRun", false);
        }

        if(_input.MoveX > 0)
        {
            _spriteRenderer.flipX = false;
        }
        if(_input.MoveX < 0)
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
        // �����̽� Ű�� ������, ���� ���� ���°� �ƴ� ��
        if (Input.GetKeyDown(KeyCode.Space) && _isJump == false)
        {
            _animator.SetBool("IsJump", true);
            _isJump = true;
            // ����!
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }

        if(_isJump == false)
        {
            _animator.SetBool("IsJump", false);
        }
    }

    // ���� �÷��̾��� ���� ���¸� Ȯ���ϴ� ó��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            _isJump = false;
        }
    }
    // ���� �÷��̾��� ���� ���¸� Ȯ���ϴ� ó��
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isJump = true;
        }
    }
}
