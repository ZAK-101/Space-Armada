using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Rigidbody2D rb2d;
    private float moveInput;
    public float speed;

    public Weapon weapon;
    public GameObject weaponObj;

    public float fireDelay;
    public float timer;

    public void Awake()
    {
        weapon = weaponObj.GetComponent<Weapon>();
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        fireDelay = 0.75f;
        timer = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        fireDelay -= Time.deltaTime;
        if (fireDelay <= 0f)
        {
            fireDelay = 0f;

            //the player shoots if the space key is down/pressed
            if (Input.GetKeyDown("space"))
            {

               fireDelay = timer;
               weapon.shoot();
            }
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
