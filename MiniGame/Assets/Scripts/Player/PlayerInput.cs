using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    // PlayerMove 스크립트에서 받아 올 좌 우 키값 변수
    public float MoveX;

    [SerializeField]
    private PlayerInteract _PlayerInteract;
    // 일단 대략적으로 한 것이니 본인 입맛대로 수정 하셔도 됩니다. 대신, 수정하실 때는 팀원을에게 꼭 말씀해주세요
    private void FixedUpdate()
    {
        // 상호작용 키 눌렀을 경우
        if (Input.GetKeyDown(KeyCode.E))
        {
            _PlayerInteract.InteractObject();
        }

        // 점프 키 처리 삭제 => PlayerMove 스크립트로 이동

        // 게임오버 처리
        if (Input.GetKeyDown(KeyCode.R))
        {

        }

        // 좌 우 값 받아서 MoveX에 업데이트
        MoveX = Input.GetAxisRaw("Horizontal");
    }
}
