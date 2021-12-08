using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private InputManager _inputManager;
    
    private LayerMask _checkLayer;
    [SerializeField] private float _checkRadius = 5f;
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _boostMultiplier;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _checkLayer = LayerMask.GetMask("Interactable");
    }
    
    private void Start()
    {
        _inputManager = InputManager.Instance;
    }

    private void Update()
    {
        var nearestGameObject = GetNearestGameObject();
        if (nearestGameObject == null) return;
        
        if (_inputManager.ActionKeyPressed)
        {   
            var interactable = nearestGameObject.GetComponent<IInteractable>();
            if (interactable == null) return;
            interactable.Interact();
        }
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var moveSpeed = _inputManager.SpaceKeyPressed ? Sprint(_moveSpeed) : _moveSpeed;
        _rigidbody.velocity = new Vector3(_inputManager.MovementInput.x, 0f, _inputManager.MovementInput.y) * moveSpeed;
    }
    
    private float Sprint(float speed)
    {
        speed *= _boostMultiplier;
        return speed;
    }
    
    private GameObject GetNearestGameObject()
    {
        GameObject nearestGameObject = null;
        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _checkRadius, _checkLayer);
        float minDistance = Mathf.Infinity;
        foreach (var hit in hitColliders)
        {
            float distance = Vector3.Distance(transform.position, hit.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestGameObject = hit.gameObject;
            }
        }
        
        return nearestGameObject;
    }
}
