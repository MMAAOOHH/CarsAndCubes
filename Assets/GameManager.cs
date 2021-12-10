using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InputManager _inputManager;
    [SerializeField] private GameObject _inventory;
    
    private void Start()
    {
        Application.targetFrameRate = 60;
        _inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if (!_inputManager.TabKeyPressed)
            return;
        DisplayInventory();
        
        if (!_inputManager.EscapeKeyPressed)
            return;
        Exit();
    }
    
    private void DisplayInventory()
    {
        _inventory.SetActive(!_inventory.activeInHierarchy);
    }
    
    private void Exit()
    {
        Application.Quit();
    }
}
