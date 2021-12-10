using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _model;
    [SerializeField] private Image _UiIcon;
    
    private string _name;
    private string _description;
    private int _id;
    
    private InventoryManager _inventoryManager;

    private void Start()
    {
        _inventoryManager = InventoryManager.Instance;
        SetModel();
    }

    private void SetModel()
    {
        Vector3 offset = new Vector3(0, .5f, 0);
        Instantiate(_model,transform.position + offset, Quaternion.identity, transform);
    }
    
    public void Interact()
    {
        _inventoryManager.Add(this);
        gameObject.SetActive(false);
    }
}
