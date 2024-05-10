using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMenu : MonoBehaviour
{
    [SerializeField] TrailRenderer _musicalParticle;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Particle"))
        {
            _musicalParticle.startColor = Random.ColorHSV(0f,1f,1f,1f,0.5f,1f);
        }
    }
}
