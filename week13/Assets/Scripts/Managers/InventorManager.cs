using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public void Startup()
    {
        Debug.Log("Inventory manager staring...");
        status = ManagerStatus.Started;
    }
}
