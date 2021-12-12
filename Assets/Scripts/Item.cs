using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _model;
    
    private Inventory _inventory;
    
    public Sprite _icon;
    public string _name;
    public int _amount;
    
    private void Start()
    {
        _inventory = Inventory.Instance;
        SetModel();
    }

    private void SetModel()
    {
        Vector3 offset = new Vector3(0, .5f, 0);
        Instantiate(_model,transform.position + offset, Quaternion.identity, transform);
    }

    private void AddToInventory()
    {
        _inventory.Add(this);
        gameObject.SetActive(false);
    }

    public void Interact()
    {
        AddToInventory();
    }
}
