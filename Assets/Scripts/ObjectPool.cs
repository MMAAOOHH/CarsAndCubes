using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToPool;
    [SerializeField] private int _poolStartSize = 10;
    
    private Queue<GameObject> _objectPool = new Queue<GameObject>();
    
    private void Start()
    {
        for (int i = 0; i < _poolStartSize; i++)
        {
            GameObject go = Instantiate(_prefabToPool, transform);
            _objectPool.Enqueue(go);
            go.SetActive(false);
        }
    }

    public GameObject Get()
    {
        if (_objectPool.Count > 0)
        {
            GameObject go = _objectPool.Dequeue();
            go.SetActive(true);
            return go;
        }
        else
        {
            GameObject go = Instantiate(_prefabToPool);
            return go;
        }
    }

    public void Return(GameObject go)
    {
        _objectPool.Enqueue(go);
        go.SetActive(false);
    }
}
