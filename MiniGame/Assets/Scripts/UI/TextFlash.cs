using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour
{
    private bool _isTextOn = false;
    public Text Color;

    void Start()
    {
        StartCoroutine(textFlash());
    }

    IEnumerator textFlash()
    {
        while (true)
        {
            if (_isTextOn)
            {
                _isTextOn = !_isTextOn;
                Color.color = new Color(0, 0, 0, 0);
            }
            else
            {
                _isTextOn = !_isTextOn;
                Color.color = new Color(255, 255, 255, 255);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
