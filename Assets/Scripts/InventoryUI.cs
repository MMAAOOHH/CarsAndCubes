using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform _inventorySlotPanel;
    
    private Inventory _inventory;
    private InventorySlot[] _inventorySlots;
    
    private void Start()
    {
        _inventory = Inventory.Instance;
        _inventory.onItemChangedCallback += UpdateInventoryUi;

        _inventorySlots = _inventorySlotPanel.GetComponentsInChildren<InventorySlot>();
    }

    private void UpdateInventoryUi()
    {
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            if (i < _inventory.GetItems().Count)
            {
                _inventorySlots[i].AddToSlot(_inventory.GetItems()[i]);
            }
            else
            {
                _inventorySlots[i].ClearSlot();
            }
        }
    }
}
