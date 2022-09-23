using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public float MoveSpeed = 1f;

    // ������ ������Ʈ
    [SerializeField]
    private GameObject Eagle;
    // �� ������Ʈ
    [SerializeField]
    private GameObject Rat;

    //���� �ð�
    private float elapsedTime = 0f;
    //Ƚ�� ���� ī��Ʈ
    private float _eagleCount = 0;
    private float _ratCount = 0;

    private SpriteRenderer _spriteRenderer;

    // �ڷ�ƾ ��ŸƮ
    private void Start()
    {
        _spriteRenderer = Rat.GetComponent<SpriteRenderer>();
        StartCoroutine(EAGLE_Updown());
        StartCoroutine(RatMoving());
    }

    // ������ ��, �Ʒ��� �̵��ϴ� �ڷ�ƾ
    IEnumerator EAGLE_Updown()
    {
        //Vector2 move = new Vector2(0f,MoveSpeed);
        while (true)
        {
            Eagle.transform.Translate(new Vector2(0f, MoveSpeed * Time.fixedDeltaTime));

            _eagleCount++;

            if (_eagleCount > 200)
            {
                _eagleCount = 0;
                MoveSpeed *= -1;
            }
            yield return new WaitForSeconds(0.001f);
        }
    }

    // �� ������
    IEnumerator RatMoving()
    {
        while (true)
        {
            Rat.transform.Translate(new Vector2(-MoveSpeed * Time.fixedDeltaTime, 0f));
            _ratCount++;

            if (_ratCount > 10000)
            {
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                _ratCount = 0;
                MoveSpeed *= -1;
            }
            yield return new WaitForSeconds(0.0005f);
        }
    }


}
