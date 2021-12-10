using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InputManager _inputManager;
    [SerializeField] private GameObject shop;
    
    private void Start()
    {
        Application.targetFrameRate = 60;
        _inputManager = InputManager.Instance;
    }

    private void Update()
    {
        if (!_inputManager.TabKeyPressed)
            return;
        ShopDisplay();
        
        if (!_inputManager.EscapeKeyPressed)
            return;
        Exit();
    }
    
    private void ShopDisplay()
    {
        shop.SetActive(!shop.activeInHierarchy);
    }
    
    private void Exit()
    {
        Application.Quit();
    }
}
