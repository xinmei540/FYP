using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public int slotID;
    public Item slotItem;
    public Image slotImage;
    public Text slotNumber;
    public string slotInfo;

    public GameObject itemInSlot;

    public void ItemOnClick()
    {
        InventoryMange.UpdateItemInfo(slotInfo);
    }

    public void SetupSlot(Item item)
    {
        if(item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }

        slotImage.sprite = item.itemImage;
        slotNumber.text = item.itemNumber.ToString();
        slotInfo = item.itemInfo;
    }
}
