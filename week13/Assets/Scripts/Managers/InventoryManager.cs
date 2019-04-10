using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
   public ManagerStatus status { get; private set; }

    private List<string> _item;

    public void Startup() {
        Debug.Log("Inventory manager starting...");
        _item = new List<string>();
        status = ManagerStatus.Started;
    }

    void DisplayItems()
    {
        string itemDisplay = "Items: ";
        foreach (string item in _item)
        {
            itemDisplay += item + " ";
        }
        Debug.Log(itemDisplay);
    }

    public void AddItem(string name)
    {
        _item.Add(name);
        DisplayItems();
    }
}
