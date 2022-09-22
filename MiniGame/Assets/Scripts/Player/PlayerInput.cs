using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // PlayerMove ��ũ��Ʈ���� �޾� �� �� �� Ű�� ����
    public float MoveX;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // �ϴ� �뷫������ �� ���̴� ���� �Ը���� ���� �ϼŵ� �˴ϴ�. ���, �����Ͻ� ���� ���������� �� �������ּ���
    private void FixedUpdate()
    {
        //_animator.SetBool("IsIdle", true);

        // ��ȣ�ۿ� Ű ������ ���
        if(Input.GetKeyDown(KeyCode.E))
        {
           
        }

        // ���� Ű ������ ���
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("IsJump", true);
        }

        // ���ӿ��� ó��
        if(Input.GetKeyDown(KeyCode.R))
        {

        }

        // �� �� �� �޾Ƽ� MoveX�� ������Ʈ
        MoveX = Input.GetAxis("Horizontal");
    }
}
