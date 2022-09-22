using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public float MoveSpeed = 1f;

    // 독수리 오브젝트
    [SerializeField]
    private GameObject Eagle;
    // 쥐 오브젝트
    [SerializeField]
    private GameObject Rat;

    //지난 시간
    private float elapsedTime = 0f;
    //횟수 제한 카운트
    private float _count = 0;

    // 코루틴 스타트
    private void Start()
    {
        StartCoroutine(EAGLE_Updown());
        //StartCoroutine(RatMove());
    }

    // 독수리 위, 아래로 이동하는 코루틴
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
