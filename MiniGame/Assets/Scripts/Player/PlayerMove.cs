using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;

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
            // ����!
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    // ���� �÷��̾��� ���� ���¸� Ȯ���ϴ� ó��
    private void OnCollisionStay2D(Collision2D collision)
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
