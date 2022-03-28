using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    public Item item;
    public bool Opened;
    public SignalSent raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator animator;
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && playerInRange)
        {
            if(!Opened)
            {
                OpenChest();
            }
            else
            {
                OpenedChest();
            }
        }
    }

    public void OpenChest()
    {
        dialogBox.SetActive(true);
        dialogText.text = item.itemInfo;
        playerInventory.AddItem(item);
        playerInventory.itemName = item;
        raiseItem.Raise();
        context.Raise();
    }

    public void OpenedChest()
    {
        if(!Opened)
        {
            dialogBox.SetActive(false);
            playerInventory.itemName = null;
            raiseItem.Raise();
            Opened = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger && !Opened)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger && !Opened)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
