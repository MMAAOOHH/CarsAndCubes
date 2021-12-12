using UnityEngine;

public class UIInventory : MonoBehaviour
{
    private Inventory _inventory;
    private Transform _inventorySlot;
    private Transform _slotTemplate;
    
    public void SetInventory(Inventory inventory)
    {
        this._inventory = inventory;
    }

    private void UpdateInventory()
    {
        foreach (Item item in _inventory.GetItems())
        {
            Instantiate(_slotTemplate, _inventorySlot);
        }
    }
}
