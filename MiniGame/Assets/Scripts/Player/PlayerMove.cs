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

    // 현재 점프상태인지 확인하는 변수
    private bool _isJump;

    // 플레이어 이동 벡터에 들어갈 X 값 변수
    private float _playerX;
    // 점프 파워
    [SerializeField]
    private float _jumpPower = 15f;

    // 이동 속도
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
        // 이동 벡터에 들어갈 변수 값 할당
        _playerX = _input.MoveX * _moveSpeed * Time.fixedDeltaTime;

        // 이동 벡터 생성
        Vector2 moveDirection = new Vector2(_playerX, 0f);

        //// 플레이어 이동
        transform.Translate(moveDirection);
    }

    private void Jump()
    {
        // 스페이스 키가 눌리고, 현재 점프 상태가 아닐 때
        if (Input.GetKeyDown(KeyCode.Space) && _isJump == false)
        {
            _animator.SetBool("IsJump", true);
            _isJump = true;
            // 점프!
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }

        if(_isJump == false)
        {
            _animator.SetBool("IsJump", false);
        }
    }

    // 현재 플레이어의 점프 상태를 확인하는 처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            _isJump = false;
        }
    }
    // 현재 플레이어의 점프 상태를 확인하는 처리
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isJump = true;
        }
    }
}
