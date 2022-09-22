using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SearchService;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    public Text Popuptext;
    public GameObject PopupObject;
    public LayerMask[] layerMasks;
    public Interactable Interactable;

    static private UnityEvent _interact;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == )
        {
            PopupObject.SetActive(true);


        }
        else
        {
            PopupObject.SetActive(false);
        }
    }

    public void InteractObject()
    {
        _interact.Invoke();
    }
}
