using System;
using UnityEngine;

[RequireComponent(typeof (Camera))]
public class CameraController : MonoBehaviour
{
    private Camera _cam;
    
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
  
    
    private float _smoothTime = 0.2f;
    private Vector3 _velocity = Vector3.zero;

    private void Awake()
    {
        _cam = Camera.main;
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
    
    private void FollowTarget()
    {
        Vector3 targetPosition = _target.transform.position + _offset;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
        transform.position = smoothPosition;
    }
}
