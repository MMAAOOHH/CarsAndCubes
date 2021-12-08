using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnRate;
    
    [SerializeField] private LayerMask _collisionLayerToIgnore;

    private ObjectPool _objectPool;

    private void Awake()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
    }

    private void Start()
    {
        InvokeRepeating((nameof(Spawn)), 1,_spawnRate);
    }

    private void Spawn()
    {
        Vector3 spawnPosition;
        do
        { 
            Vector3 position = GetRandomPosition();
            spawnPosition = new Vector3(position.x, 0, position.y);
            
        } while (IsBlockedPosition(spawnPosition));

        GameObject newObject = _objectPool.Get();
        newObject.transform.position = spawnPosition;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 position = Random.insideUnitCircle * _spawnRadius;
        return position;
    }

    private bool IsBlockedPosition(Vector3 desiredPosition)
    {
        var layerMask = ~_collisionLayerToIgnore;
        var collisionCheckRadius = 5f;
        
        return Physics.CheckSphere(desiredPosition, collisionCheckRadius,layerMask);
    }
}
