using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMange : MonoBehaviour
{
    static InventoryMange instance;

    public Inventory myBag;
    public GameObject grid;
    //public ItemSlot itemPrefab;
    public GameObject emptySlot;
    public Text itemInformation;

    public List<GameObject> slots = new List<GameObject>();
    void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }


    /*public static void CreateNewItem(Item item)
    {
        ItemSlot newItem = Instantiate(instance.itemPrefab, instance.grid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.grid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNumber.text = item.itemNumber.ToString();
    }*/

    public static void RefreshItem()
    {
        for(int i = 0; i < instance.grid.transform.childCount; i++)
        {
            if(instance.grid.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.grid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for(int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.grid.transform);
            instance.slots[i].GetComponent<ItemSlot>().slotID = i;
            instance.slots[i].GetComponent<ItemSlot>().SetupSlot(instance.myBag.itemList[i]);
        }
    }
}
