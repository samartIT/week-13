using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public string equippedItem { get; private set; } // for UI
    public bool EquipItem(string name) // for UI
    {
        if(_items.ContainsKey(name) && equippedItem != name)
        {
            equippedItem = name;
            Debug.Log("Equipped " + name);
            return true;
        }
        equippedItem = null;
        Debug.Log("Unquipped");
        return true;
    }

    public bool ConsumeItem(string name) // for UI
    {
        if (_items.ContainsKey(name))
        {
            _items[name]--;
            if (_items[name] == 0)
            {
                _items.Remove(name);
            }
        }
        else
        {
            Debug.Log("cannot consume " + name);
            return true;
        }

        DisplayItems();
        return true;
    }
    public List<string> GetItemList() // for UI
    {
        List<string> list = new List<string>(_items.Keys);
        return list;  
    }
    public int GetItemCount(string name) // for UI
    {
        if (_items.ContainsKey(name))
        {
            return _items[name];
        }
        return 0;
    }

    //private List<string> _items;
    private Dictionary<string, int> _items;

    public void Startup()
    {
        Debug.Log("Inventory manager starting...");

        //_items = new List<string>();
        _items = new Dictionary<string, int>();

        status = ManagerStatus.Started;
    }

    void DisplayItems()
    {
        string itemDisplay = "items: ";
        //foreach(string item in _items)
        //{
        //    itemDisplay += item + " ";
        //}
        foreach(KeyValuePair<string, int> item in _items)
        {
            itemDisplay += item.Key + "(" + item.Value + ") ";
        }
        Debug.Log(itemDisplay);
    }

    public void AddItem(string name)
    {
        //_items.Add(name);
        if (_items.ContainsKey(name))
        {
            _items[name] += 1;
        }
        else
        {
            _items[name] = 1;
        }
        DisplayItems();
    }
}
