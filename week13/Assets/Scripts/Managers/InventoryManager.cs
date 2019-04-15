﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    private List<string> _items;

    public void Startup() {
        Debug.Log("Inventory manager starting...");

        _items = new List<string>();

        status = ManagerStatus.Started;
    }

    void DisplayItems() {
        string itemDisplay = "Items: ";
        foreach (string item in _items) {
            itemDisplay += item + " ";
        }
        Debug.Log(itemDisplay);
    }

    public void AddItem(string name) {
        _items.Add(name);
        DisplayItems();
    }
}
