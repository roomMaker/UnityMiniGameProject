using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : SingletonBehaviour<GameManager>
{

    //플레이어가 레이어에 닿았을때 뜨는 텍스트+패널

    //상호작용 가능한 오브젝트별 텍스트변화
    [Header("상호작용 가능한 오브젝트&텍스트변화")]
    public string[] Tags;
    public string[] ChageText;
    //상호작용이 되는것인가?
    public bool IsInteractOK;

    private Interactable _tempInteractable;
    [Header("상호작용 UI 팝업")]
    [SerializeField]
    private Text _popuptext;
    [SerializeField]
    private GameObject _popupObject;
    public Interactable GetInteractable()
    {
        return _tempInteractable;
    }


    private void Awake()
    {
        IsInteractOK = false;
        _popupObject.SetActive(false);
    }

    //트리거 안에 들어왔을때
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Interactable 클래스를 오버라이드한 해당 오브젝트의 정보를 가지고 옴
        if(collision.GetComponent<Interactable>()!=null)
        { 
            _tempInteractable = (Interactable)collision.GetComponent<Interactable>();
        }
        //상호작용이 가능한 태그를 가지고있을시 이름패널 팝업
            if (collision.gameObject.CompareTag(Tags[0]))
            {
                _popuptext.text = ChageText[0];
                IsInteractOK = true;
                _popupObject.SetActive(true);
            } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags[1])) { GameManager.Instance.PlayerDie(); }
    }
    //나가면 모두 Null
    private void OnTriggerExit2D(Collider2D collision)
    { 
            IsInteractOK = false;
            _popupObject.SetActive(false);
        if(_tempInteractable != null)
            _tempInteractable = null;
    }
}
