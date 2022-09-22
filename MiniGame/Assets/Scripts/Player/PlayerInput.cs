using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // PlayerMove ��ũ��Ʈ���� �޾� �� �� �� Ű�� ����
    public float MoveX;

    [SerializeField]
    private PlayerInteract _PlayerInteract;
    // �ϴ� �뷫������ �� ���̴� ���� �Ը���� ���� �ϼŵ� �˴ϴ�. ���, �����Ͻ� ���� ���������� �� �������ּ���
    private void FixedUpdate()
    {
        // ��ȣ�ۿ� Ű ������ ���
        if (Input.GetKeyDown(KeyCode.E))
        {
            _PlayerInteract.InteractObject();
        }

        // ���� Ű ó�� ���� => PlayerMove ��ũ��Ʈ�� �̵�

        // ���ӿ��� ó��
        if (Input.GetKeyDown(KeyCode.R))
        {

        }

        // �� �� �� �޾Ƽ� MoveX�� ������Ʈ
        MoveX = Input.GetAxisRaw("Horizontal");
    }
}
