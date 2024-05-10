using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ColorMusicBox : MonoBehaviour
{
    [Header(" Reference :")]
    [SerializeField] SpriteRenderer[] _volumeBarre;
    [SerializeField] AudioSource _musicSource;
    [SerializeField] Color _colorOn;
    [SerializeField] Color _colorOff;

    [Header(" Volume :")]
    [SerializeField] float _volumeIncrease = 0.02f;
    [SerializeField] float _volumeDecreasing = 0.1f;
    [SerializeField] float _intervalDecreasing = 1f;

    float _chrono = 0f;

    void Start()
    {
        _musicSource.volume = 0f;
    }

    void Update()
    {
        for(int i = 0; i< _volumeBarre.Length; i++)
        {
            float seuil =(float)i / (float)_volumeBarre.Length;

            if(_musicSource.volume > seuil) { _volumeBarre[i].color = _colorOn; }
            else { _volumeBarre[i].color = _colorOff; }
        }

        if(_chrono >= _intervalDecreasing) { _musicSource.volume -= _volumeDecreasing * Time.deltaTime; }
        else { _chrono += Time.deltaTime; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Particle"))
        {
            _musicSource.volume += _volumeIncrease;
            _chrono = 0f;
        }
    }
}
