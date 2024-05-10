using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    static GameObject[] _pool;
    [SerializeField] GameObject _prefabCreate;
    [SerializeField] int _numbersCreate = 10;

    void Start()
    {
        _pool = new GameObject[_numbersCreate];

        for(int i = 0; i < _numbersCreate; i++)
        {
            _pool[i] = Instantiate(_prefabCreate, transform);
            _pool[i].SetActive(false);
        }
    }

    public static GameObject Get()
    {
        foreach(GameObject item in _pool)
        {
            if (!item.activeSelf)
            {
                return item;
            }
        }
        return null;
    }
}
