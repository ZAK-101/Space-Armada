using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    public float speed;

    Weapon weapon;
    public GameObject weaponObj;

    public void Awake()
    {
        weapon = weaponObj.GetComponent<Weapon>();
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //the player shoots if the space key is down/pressed
        if (Input.GetKeyDown("space"))
        {
            weapon.shoot();
            
        }
    }

    private void FixedUpdate()
    {
        move();

    }

    void move()
    {
        //player movement - unity input manager (project settings)
        //a or the left arrow is equal to -1
        //d or the right arrow is equal to 1
        moveInput = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }

}
