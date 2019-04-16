using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
    private void OnGUI()
    {
        int posX = 10, posY = 10;
        int width = 100, height = 30;
        int buffer = 10;

        List<string> itemList = Manager.Inventory.GetItemList();
        if (itemList.Count == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No Item");
        }
        foreach (string item in itemList)
        {
            int count = Manager.Inventory.GetItemCount(item);
            Texture2D image = Resources.Load<Texture2D>("Icon/" + item);
            GUI.Box(new Rect(posX, posY, width, height), 
                new GUIContent("(", + count + ")", image));
            posX += width + buffer;
        }


        string equipped = Manager.Inventory.equippedItem;
        if (equipped != null)
        {
            posX = Screen.width - (width + buffer);
            Texture2D image = Resources.Load<Texture2D>("Icon/" + equipped);
            GUI.Box(new Rect(posX, posY, width, height),
                new GUIContent("Equipped", image));
        }

        posX = 10;
        posY += height + buffer;

        foreach (string item in itemList)
        {
            if(GUI.Button(new Rect(posX,posY,width,height),"Equip " + item))
            {
                Manager.Inventory.EquipItem(item);
            }
            if (item == "health")
            {
                if (GUI.Button(new Rect(posX,posY+height+buffer,width,height),"Use Health"))
                {
                    Manager.Inventory.ConsumeItem("health");
                    Manager.Player.ChangeHealth(25);
                }
            }
            posX += width + buffer;
        }
    }
}
