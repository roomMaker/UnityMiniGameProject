using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MonoBehaviour
{
    // ������ ������
    public float MoveSpeed = 1f;
    // ������ ������ ����
    public float MoveRange = 200f;

    // ������ Ƚ�� ���� ī��Ʈ
    private float _moveCount = 0f;

    private void Start()
    {
        StartCoroutine(EagleMoving());
    }

    /// <summary>
    /// �������� �������� �����ϴ� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator EagleMoving()
    {
        while (true)
        {
            transform.Translate(new Vector2(0f, MoveSpeed * Time.fixedDeltaTime));

            _moveCount++;

            if (_moveCount > MoveRange)
            {
                _moveCount = 0;
                MoveSpeed *= -1;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
