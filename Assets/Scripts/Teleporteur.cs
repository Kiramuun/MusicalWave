using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporteur : MonoBehaviour
{
    [SerializeField] Transform _transformTp;
    [SerializeField] GameObject _particle;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //StartCoroutine(Teleport());
        collision.transform.position = _transformTp.position;
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.5f);
        _particle.transform.position = new Vector3(_transformTp.transform.position.x, _transformTp.transform.position.y, _transformTp.transform.position.z);
    }
}
