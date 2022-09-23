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
    // 개구리 점프 높이
    public float FrogJumpRange = 15f;
    // 개구리 이동 반경
    public float FrogMoveRange = 4f;

    // 독수리 오브젝트
    [SerializeField]
    private GameObject Eagle;
    // 쥐 오브젝트
    [SerializeField]
    private GameObject Rat;
    // 개구리 오브젝트
    [SerializeField]
    private GameObject Frog;

    // 일정 시간마다 진행되는 이벤트 타임 변수
    private float _elapsedTime = 0f;

    // 횟수 제한 카운트
    private float _eagleCount = 0;
    private float _ratCount = 0;

    // 개구리 점프 왼쪽, 오른쪽 상태
    private bool _isFrogLeftJump = false;

    // 컴포넌트 가져오기
    private SpriteRenderer _spriteRenderer_rat;
    private SpriteRenderer _spriteRenderer_frog;
    private Rigidbody2D _rigidbody_frog;
    private Animator _animator;

    // 코루틴 스타트
    private void Start()
    {
        _animator = Frog.GetComponent<Animator>();
        _rigidbody_frog = Frog.GetComponent<Rigidbody2D>();
        _spriteRenderer_rat = Rat.GetComponent<SpriteRenderer>();
        _spriteRenderer_frog = Frog.GetComponent<SpriteRenderer>();
        StartCoroutine(EAGLE_Updown());
        StartCoroutine(RatMoving());
        StartCoroutine(FrogMoving());
    }

    // 독수리 위, 아래로 이동하는 코루틴
    IEnumerator EAGLE_Updown()
    {
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

    // 쥐 좌,우 움직임
    IEnumerator RatMoving()
    {
        while (true)
        {
            Rat.transform.Translate(new Vector2(-MoveSpeed * Time.fixedDeltaTime, 0f));
            _ratCount++;

            if (_ratCount > RatMoveRange)
            {
                _spriteRenderer_rat.flipX = !_spriteRenderer_rat.flipX;
                _ratCount = 0;
            }
            yield return new WaitForSeconds(0.001f);
        }
    }

    // 개구리 왼쪽 점프, 오른쪽 점프 움직임
    IEnumerator FrogMoving()
    {
        while (true)
        {
            _elapsedTime += Time.fixedDeltaTime;
            Debug.Log($"현재 : {_elapsedTime}초");

            if (_isFrogLeftJump)
            {
                _animator.SetBool("IsJump", true);
                _spriteRenderer_frog.flipX = true;

            }
            else
            {
                _animator.SetBool("IsIdle", true);
                _spriteRenderer_frog.flipX = false;
            }

            // 왼쪽으로 점프! 
            if (_isFrogLeftJump)
            {
                _rigidbody_frog.AddForce(new Vector2(FrogMoveRange, FrogJumpRange), ForceMode2D.Impulse);
                _isFrogLeftJump = false;
            }
            // 오른쪽으로 점프!
            else
            {
                _rigidbody_frog.AddForce(new Vector2(-FrogMoveRange, FrogJumpRange), ForceMode2D.Impulse);
                _isFrogLeftJump = true;
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
