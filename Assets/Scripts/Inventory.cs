using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private List<Item> _inventory;

    private void Start()
    {
        _inventory = new List<Item>();
    }

    public void Add(Item item)
    {
        _inventory.Add(item);
    }

    private void Remove(Item item)
    {
        _inventory.Remove(item);
    }
}
