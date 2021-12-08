using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject solid;
    [SerializeField] private GameObject fractured;
    
    [SerializeField] private Rigidbody[] cells;
    [SerializeField] private float _force = 20f;
    
    private void Start()
    {
        fractured.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            solid.SetActive(false);
            fractured.SetActive(true);
            
            foreach (var item in cells)
            {
                AddForce(_force, item, other.transform);
            }

            GetComponent<Collider>().enabled = false;
        }
    }
    
    private void AddForce(float force, Rigidbody rb, Transform fromDirection)
    {
        Vector3 direction = transform.position - fromDirection.position;
        rb.AddForce(direction * force, ForceMode.Impulse);
    }
}
