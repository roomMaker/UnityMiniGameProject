using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour
{
    // ���� ������ �ӵ�
    public float MoveSpeed = 1f;
    // ���� ������ ����
    public float RatMoveRange = 200f;

    // �ӵ� Ƚ�� ���� ī��Ʈ
    private float _moveCount = 0;
    // ������Ʈ
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
       _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(RatMoving());
    }

    /// <summary>
    /// ���� �������� �����ϴ� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    IEnumerator RatMoving()
    {
        while (true)
        {
            transform.Translate(new Vector2(-MoveSpeed * Time.fixedDeltaTime, 0f));
            _moveCount++;

            if (_moveCount > RatMoveRange)
            {
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                _moveCount = 0;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
