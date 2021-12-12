using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private List<Item> _itemList;
    
    public void Add(Item item)
    {
        _itemList.Add(item);
    }

    private void Remove(Item item)
    {
        _itemList.Remove(item);
    }
    
    public List<Item> GetItems()
    {
        return _itemList;
    }
}
