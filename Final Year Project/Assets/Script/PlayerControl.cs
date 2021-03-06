using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    attack,
    interact
}

public class PlayerControl : MonoBehaviour
{
    public PlayerState currentState;

    public float speed = 5f;

    private Rigidbody2D _rb;
    private Animator Ani;

    private Vector2 LookDirection = Vector2.down;
    private Vector2 CurrentInput;

    private float x;
    private float y;

    public GameObject MyBag;
    private bool isOpen;

    public Inventory playerInventory;
    public SpriteRenderer getItemSprite;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(x, y);

        if(!Mathf.Approximately(movement.x, 0.0f) || !Mathf.Approximately(movement.y, 0.0f))
        {
            LookDirection.Set(movement.x, movement.y);
            LookDirection.Normalize();
        }

        Ani.SetFloat("Look X", LookDirection.x);
        Ani.SetFloat("Look Y", LookDirection.y);
        Ani.SetFloat("Speed", movement.magnitude);

        CurrentInput = movement;

        if(Input.GetKeyDown(KeyCode.Z) && currentState != PlayerState.attack)
        {
            StartCoroutine(Attack());
        }

        OpenMyBag();
    }

    public void RaiseItem()
    {
        if (currentState != PlayerState.interact)
        {
            getItemSprite.sprite = playerInventory.itemName.itemImage;
        }
        else
        {
            getItemSprite.sprite = null;
        }
    }

    private IEnumerator Attack()
    {
        Ani.SetBool("Attack", true);
        currentState = PlayerState.attack;
        yield return null;
        Ani.SetBool("Attack", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    private void FixedUpdate()
    {
        Vector2 position = _rb.position;
        position += CurrentInput * speed * Time.deltaTime;
        _rb.MovePosition(position);
    }

    void OpenMyBag()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            isOpen = !isOpen;
            MyBag.SetActive(isOpen);
        }
    }

}
