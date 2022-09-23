using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    // 몬스터들의 움직임 속도
    public float MoveSpeed = 1f;

    // 쥐의 움직임 범위
    public float RatMoveRange = 200f;
    // 독수리의 움직임 범위
    public float EagleMoveRange = 200f;

    // 독수리 오브젝트
    [SerializeField]
    private GameObject Eagle;
    // 쥐 오브젝트
    [SerializeField]
    private GameObject Rat;

    //지난 시간
    private float elapsedTime = 0f;
    //횟수 제한 카운트
    private float _eagleCount = 0;
    private float _ratCount = 0;

    private SpriteRenderer _spriteRenderer;

    // 코루틴 스타트
    private void Start()
    {
        _spriteRenderer = Rat.GetComponent<SpriteRenderer>();
        StartCoroutine(EAGLE_Updown());
        StartCoroutine(RatMoving());
    }

    // 독수리 위, 아래로 이동하는 코루틴
    IEnumerator EAGLE_Updown()
    {
        //Vector2 move = new Vector2(0f,MoveSpeed);
        while (true)
        {
            Eagle.transform.Translate(new Vector2(0f, MoveSpeed * Time.fixedDeltaTime));

            _eagleCount++;

            if (_eagleCount > EagleMoveRange)
            {
                _eagleCount = 0;
                MoveSpeed *= -1;
            }
            yield return new WaitForSeconds(0.001f);
        }
    }

    // 쥐 움직임
    IEnumerator RatMoving()
    {
        while (true)
        {
            Rat.transform.Translate(new Vector2(-MoveSpeed * Time.fixedDeltaTime, 0f));
            _ratCount++;

            if (_ratCount > RatMoveRange)
            {
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                _ratCount = 0;
            }
            yield return new WaitForSeconds(0.003f);
        }
    }


}
