using System.Collections.Generic;

public class Inventory : Singleton<Inventory>
{
    private List<Item> _itemList = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    
    public void Add(Item item)
    {
        _itemList.Add(item);
        onItemChangedCallback?.Invoke();
    }

    private void Remove(Item item)
    {
        _itemList.Remove(item);
        onItemChangedCallback?.Invoke();
    }
    
    public List<Item> GetItems()
    {
        return _itemList; 
    }
}
