using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioSource[] _musicBox;
    [SerializeField] float _chronoDuration = 2f;
    int _musicBCount = 0;
    float _chrono = 0f;
    bool _fullVolume = true;

    void Start()
    {
        GameObject[] box = GameObject.FindGameObjectsWithTag("BoxZone");

        _musicBox = new AudioSource[box.Length];

        for(int i =0; i < box.Length; i++)
        {
            /*GameObject boxes = box[i];
            AudioSource audio = boxes.GetComponent<AudioSource>();
            _musicBox[i] = audio;*/

            _musicBox[i] = box[i].GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        /*_musicBCount = 0;
        foreach(AudioSource box in _musicBox)
        {
            if(box.volume == 1f)
            {
                _musicBCount++;
            }
        }

        if( _musicBCount >= _musicBox.Length)
        {
            _chrono += Time.deltaTime;
        }
        else
        {
            _chrono = 0f;
        }*/
        
        //_musicBCount = 0;
        _fullVolume = true;
        foreach(AudioSource box in _musicBox)
        {
            if(box.volume < 1f)
            {
                _fullVolume = false;
                break;
            }
        }

        if( _fullVolume)
        {
            _chrono += Time.deltaTime;
        }
        else
        {
            _chrono = 0f;
        }

        if(_chrono >= _chronoDuration)
        {
            Debug.Log("Win");
        }
    }
}
