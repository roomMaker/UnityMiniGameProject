using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BGMScript : MonoBehaviour
{
    //����� �ٲٱ�
    public AudioClip[] BGM;
    public AudioSource BGMSource;
    private bool _changeMusic1;
    private bool _changeMusic2;
    private void Start()
    {
        _changeMusic1 = false;
        _changeMusic2 = false;
    }

    private void Update()
    {
        //��
        if (Application.loadedLevel == 4 && _changeMusic1 == false )
        {
            BGMSource.clip = BGM[2];
            BGMSource.Play();
            _changeMusic1 = true;
        }
        //���Ͻ�
        else if (Application.loadedLevel == 6 && _changeMusic2 == false)
        {
            BGMSource.clip = BGM[0];
            BGMSource.Play();
            _changeMusic2 = true;
        }

    }

}
