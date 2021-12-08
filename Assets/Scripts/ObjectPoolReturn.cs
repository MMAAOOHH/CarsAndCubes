using UnityEngine;

public class ObjectPoolReturn : MonoBehaviour
{
    private ObjectPool _objectPool;
    
    private void Awake()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
    }

    private void OnDisable()
    {
        if (_objectPool != null)
        {
            _objectPool.Return(gameObject);
        }
    }
}
