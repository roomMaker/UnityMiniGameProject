using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SearchService;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    //플레이어가 레이어에 닿았을때 뜨는 텍스트+패널
    public Text Popuptext;
    public GameObject PopupObject;
    //상호작용이 필요한 레이어 배열
    public LayerMask[] layerMasks;
    //오브젝트 상호작용
    public Interactable Interactable;
    //상호작용이 되는것인가?
    public bool IsInteractOK;


    // 유니티 이벤트
    private UnityEvent _Interact;

    private void Awake()
    {
        IsInteractOK = false;
    }
    private void Update()
    {

    }

    //트리거 안에 들어왔을때 상호작용이 되는 레이어인가 비교 후 패널 팝업
    private void OnTriggerEnter2D(Collider2D collision)
    {
        for(int i = 0; i < layerMasks.Length; i++)
        {
            if (collision.gameObject.layer == layerMasks[i])
            {
            IsInteractOK = true;
            PopupObject.SetActive(true);
            }

            else
            {
                IsInteractOK = false;
                PopupObject.SetActive(false);
            }
        }
    }

    //상호 작용
    public void InteractObject()
    {
        _Interact.Invoke();
    }
}
