using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPSize : MonoBehaviour
{
    [SerializeField] TrailRenderer _musicalParticle;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Particle"))
        {
            collision.gameObject.GetComponent<TrailRenderer>().startWidth += 0.1f;
        }
    }
}
