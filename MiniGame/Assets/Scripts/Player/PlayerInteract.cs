using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SearchService;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    //�÷��̾ ���̾ ������� �ߴ� �ؽ�Ʈ+�г�
    public Text Popuptext;
    public GameObject PopupObject;
    //��ȣ�ۿ��� �ʿ��� ���̾� �迭
    public LayerMask[] layerMasks;
    //������Ʈ ��ȣ�ۿ�
    public Interactable Interactable;
    //��ȣ�ۿ��� �Ǵ°��ΰ�?
    public bool IsInteractOK;


    // ����Ƽ �̺�Ʈ
    private UnityEvent _Interact;

    private void Awake()
    {
        IsInteractOK = false;
    }
    private void Update()
    {

    }

    //Ʈ���� �ȿ� �������� ��ȣ�ۿ��� �Ǵ� ���̾��ΰ� �� �� �г� �˾�
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

    //��ȣ �ۿ�
    public void InteractObject()
    {
        _Interact.Invoke();
    }
}
