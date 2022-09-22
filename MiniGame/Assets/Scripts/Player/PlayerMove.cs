using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;

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
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Jump();
    }

    private void Move()
    {
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
            // 점프!
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    // 현재 플레이어의 점프 상태를 확인하는 처리
    private void OnCollisionStay2D(Collision2D collision)
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
