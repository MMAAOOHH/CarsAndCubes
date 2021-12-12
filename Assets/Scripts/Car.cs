using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class Car : MonoBehaviour, IInteractable 
{
    private InputManager _inputManager;
    private Rigidbody _rigidbody;
    private GameObject _driver;
    
    private bool _hasPlayer;
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _boostMultiplier;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _inputManager = InputManager.Instance;
        _hasPlayer = false;
    }

    private void Update()
    {
        if (!_hasPlayer)
            return;
        if (_inputManager.ActionKeyPressed)
            Exit();
    }

    private void FixedUpdate()
    {
        if (!_hasPlayer) return;
        Drive();
    }
    
    public void Interact()
    {
        Enter(GameObject.Find("Player"));
    }

    public void Highlight()
    {
    }
    
    private void Enter(GameObject driver)
    {
        _driver = driver;
        _driver.transform.parent = transform;
        _driver.SetActive(false);
        _hasPlayer = true;
    }
    
    private void Exit()
    {
        _driver.transform.parent = null;
        _driver.SetActive(true);
        _hasPlayer = false;
        _driver = null;
    }
    
    private void Drive()
    {
        var moveSpeed = _inputManager.SpaceKeyPressed ? Sprint(_moveSpeed) : _moveSpeed;
        _rigidbody.AddForce(transform.forward * _inputManager.MovementInput.y * moveSpeed);
        
        Quaternion direction = Quaternion.Euler(Vector3.up * _inputManager.MovementInput.x * _turnSpeed);
        _rigidbody.MoveRotation(_rigidbody.rotation * direction);
    }
    
    private float Sprint(float speed)
    {
        speed *= _boostMultiplier;
        return speed;
    }
}
