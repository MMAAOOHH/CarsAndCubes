using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Rigidbody[] cells;
    [SerializeField] private float _force = 20f;
    private float _radius = 2f;
    private Vector3 _center;

    private void Start()
    {
        _center = transform.position;
    }
    
    public void Explode()
    {
        foreach (var item in cells)
        {
            item.AddExplosionForce(_force,_center, _radius);
        }
    }
}
