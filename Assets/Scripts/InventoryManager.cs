using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] private List<Item> _items;

    private void Start()
    {
        _items = new List<Item>();
    }

    public void Add(Item item)
    {
        _items.Add(item);
    }

    private void Remove(Item item)
    {
        _items.Remove(item);
    }
}
