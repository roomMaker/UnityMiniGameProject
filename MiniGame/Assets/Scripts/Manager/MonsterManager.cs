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
    private float _count = 0;

    // �ڷ�ƾ ��ŸƮ
    private void Start()
    {
        StartCoroutine(EAGLE_Updown());
        //StartCoroutine(RatMove());
    }

    // ������ ��, �Ʒ��� �̵��ϴ� �ڷ�ƾ
    IEnumerator EAGLE_Updown()
    {
        //Vector2 move = new Vector2(0f,MoveSpeed);
        while (true)
        {
            Eagle.transform.Translate(new Vector2(0f, MoveSpeed * Time.fixedDeltaTime));

            _count++;

            if(_count > 200)
            {
                _count = 0;
                MoveSpeed *= -1;    
            }
            yield return new WaitForSeconds(0.001f);
        }
    }

    
}
