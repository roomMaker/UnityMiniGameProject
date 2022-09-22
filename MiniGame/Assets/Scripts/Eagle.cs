using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    private float elapsedTime = 0f;

    private void Start()
    {
        StartCoroutine(EAGLE_Updown());
    }
    IEnumerator EAGLE_Updown()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > 1f)
        {
            elapsedTime = 0f;
            gameObject.transform.position = Vector2.left * elapsedTime;
        }

        yield return new WaitForSeconds(elapsedTime);
    }

}
