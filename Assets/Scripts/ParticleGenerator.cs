using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{
    [SerializeField] GameObject _musicalParticle;
    [SerializeField] float _spawnTime = 1f;
    [SerializeField] float _spawnRadius = 1f;
    float _chrono = 0f;

    void Update()
    {
        _chrono += Time.deltaTime;

        if( _chrono >= _spawnTime)
        {
            Vector2 spawnPos = (Vector2)transform.position + Random.insideUnitCircle * _spawnRadius;
            GameObject Particle = Instantiate(_musicalParticle, spawnPos, Quaternion.identity);
            /*GameObject Particle = ObjectPool.Get();

            if(Particle == null)
            {
                return;
            }

            Particle.SetActive(true);
            Particle.transform.position = spawnPos;*/
            Particle.GetComponent<Rigidbody2D>().velocity = transform.right * 10f;
            _chrono = 0f;
        }
    }
}
