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
    public string[] tags;
    //상호작용이 되는것인가?
    public bool IsInteractOK;

    private Interactable _tempInteractable;

    public Interactable GetInteractable()
    {
        return _tempInteractable;
    }


    private void Awake()
    {
        IsInteractOK = false;
    }

    //트리거 안에 들어왔을때 상호작용이 되는 레이어인가 비교 후 패널 팝업
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<Interactable>()!=null)_tempInteractable = (Interactable)collision.GetComponent<Interactable>();

            if (collision.gameObject.CompareTag("Interact"))
            {
                IsInteractOK = true;
                PopupObject.SetActive(true);
            }
    }
    private void OnTriggerExit2D(Collider2D collision)
    { 
            IsInteractOK = false;
            PopupObject.SetActive(false);
        if(_tempInteractable != null)
            _tempInteractable = null;
    }
}
