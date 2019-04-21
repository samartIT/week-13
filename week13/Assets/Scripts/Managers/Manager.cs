using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayManager))]
[RequireComponent(typeof(InventorManager))]

public class Manager : MonoBehaviour
{
    public static PlayManager Player { get; private set; }
    public static InventorManager Inventory { get; private set; }

    private List<IGameManager> _startSequence;

    private void Awake()
    {
        Player = GetComponent<PlayManager>();
        Inventory = GetComponent<InventorManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(Player);
        _startSequence.Add(Inventory);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup();
        }
        yield return null;

        int numModules = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach(IGameManager manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }

            if (numReady > lastReady)
            {
                Debug.Log("Progress: " + numReady + "/" + numModules);
            }
            yield return null;
        }

        Debug.Log("All managers started up");

    }

}
