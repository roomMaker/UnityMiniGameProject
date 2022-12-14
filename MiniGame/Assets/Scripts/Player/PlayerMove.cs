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
    private AudioSource _audioSource;

    // 현재 점프상태인지 확인하는 변수
    [SerializeField]
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
        _audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if(GameManager.Instance.CanMovePlayer)
        {
            Move();
        }
    }

    private void Update()
    {
        if(_animator.GetBool("IsJump"))
        {
            _isJump = true;
        }
        if(Input.GetKeyDown(KeyCode.Space) && _rigidbody.velocity.y <= 0)
        {
            Jump();
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
        if(_isJump)
        {
            return;
        }
        Debug.Log("점프");
        _animator.SetBool("IsJump", true);
        _isJump = true;
        // 점프!
        _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        if(false == _audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    // 현재 플레이어의 점프 가능여부 처리
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.CompareTag("Ground") && transform.position.y - collision.collider.transform.position.y >= 0.9f) || collision.collider.CompareTag("Bridge"))
        {
            _isJump = false;
            _animator.SetBool("IsJump", false);
        }
    }
}
    