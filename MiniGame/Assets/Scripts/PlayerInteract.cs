using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public Text PopupText;
    public GameObject PopupObject;
    public LayerMask[] LayerMask;
    public Interactable Interactable;

    private UnityEvent _interact;

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider other)
    {
        PopupText.text = "'E'를 눌러 상호작용";
        PopupObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            _interact.Invoke();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PopupObject.SetActive(false);
    }
}
