using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // PlayerMove ��ũ��Ʈ���� �޾� �� �� �� Ű�� ����
    public float MoveX;

    // �ϴ� �뷫������ �� ���̴� ���� �Ը���� ���� �ϼŵ� �˴ϴ�. ���, �����Ͻ� ���� ���������� �� �������ּ���
    private void FixedUpdate()
    {

        // ��ȣ�ۿ� Ű ������ ���
        if(Input.GetKeyDown(KeyCode.E))
        {
           
        }

        // ���� Ű ������ ���
        if(Input.GetKeyDown(KeyCode.Space))
        {
         
        }

        // ���ӿ��� ó��
        if(Input.GetKeyDown(KeyCode.R))
        {

        }

        // �� �� �� �޾Ƽ� MoveX�� ������Ʈ
        MoveX = Input.GetAxis("Horizontal");
    }
}
