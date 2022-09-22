using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    public int ItemCode;

    // Start is called before the first frame update
    void Start()
    {
        ItemCode = Random.Range(0, 1000000);
    }
}
