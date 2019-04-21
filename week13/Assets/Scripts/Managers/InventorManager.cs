using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    //private List<string> _items;
    private Dictionary<string, int> _items;

    public void Startup()
    {
        Debug.Log("Inventory manager staring...");

        //_items = new List<string>();
        _items = new Dictionary<string, int>();

        status = ManagerStatus.Started;
    }

    void DisplayItems()
    {
        string itemDisplay = "Items: ";
        //foreach(string item in _items)
        //{
            //itemDisplay += item + " ";
        //}
        foreach (KeyValuePair<string, int> item in _items)
        {
            itemDisplay += item.Key + "(" + item.Value + ")";
        }

        Debug.Log(itemDisplay);
    }

    public void AddItem(string name)
    {
        //_items.Add(name);
        if (_items.ContainsKey(name))
        {
            _items[name] += 1;
        } else
        {
            _items[name] = 1;
        }
        DisplayItems();
    }
}
