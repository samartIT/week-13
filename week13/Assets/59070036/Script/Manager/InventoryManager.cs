using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    //private List<string> _item;
    private Dictionary<string, int> _item;

    public void Statup()
    {
        Debug.Log("Inventory manager starting...");
        //_item = new List<string>();
        _item = new Dictionary<string, int>();

        status = ManagerStatus.Started;
    }

    void DisplayItems()
    {
        string itemDisplay = "Items : ";
        //foreach(string item in _item)
        //{
        //    itemDisplay += _item + " ";
        //}
        foreach (KeyValuePair<string, int> item in _items)
        {
            itemDisplay += item.Key + "(" + item.Value + ") ";
        }
        Debug.Log(itemDisplay);
    }

    public void AddItem(string name)
    {
        //_item.Add(name);
        if(_item.ContainsKey(name))
        {
            _item[name] += 1;
        }else
        {
            _item[name] = 1;
        }
        DisplayItem();
    }
}
