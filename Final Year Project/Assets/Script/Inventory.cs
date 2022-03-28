using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public Item itemName;
    public int numberOfKeys;
    public List<Item> itemList = new List<Item>();

    public void AddItem(Item itemAdd)
    {
        if(itemAdd.equip)
        {
            numberOfKeys++;
        }
        else
        {
            if(!itemList.Contains(itemAdd))
            {
                itemList.Add(itemAdd);
            }
        }
    }
}
