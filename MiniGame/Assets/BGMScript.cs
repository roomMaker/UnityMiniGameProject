using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BGMScript : MonoBehaviour
{
    //배경음 바꾸기
    public AudioClip[] BGM;
    public AudioSource BGMSource;
    private bool _changeMusic;
    private bool _changeMusic1;
    private bool _changeMusic2;
    private void Start()
    {
        _changeMusic = false;
        _changeMusic1 = false;
        _changeMusic2 = false;
    }

    private void Update()
    {
        if (GameManager.Instance.GameSceneIndex == 1 && _changeMusic == false)
        {
            BGMSource.clip = BGM[1];
            BGMSource.Play();
            _changeMusic = true;
        }
        //숲
        else if (GameManager.Instance.GameSceneIndex == 4 && _changeMusic1 == false )
        {
            BGMSource.clip = BGM[2];
            BGMSource.Play();
            _changeMusic1 = true;
        }
        //지하실
        else if (GameManager.Instance.GameSceneIndex == 6 && _changeMusic2 == false)
        {
            BGMSource.clip = BGM[0];
            BGMSource.Play();
            _changeMusic2 = true;
        }

    }

}
