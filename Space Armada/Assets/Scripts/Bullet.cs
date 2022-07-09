using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        //bullet travel
        rb2d.velocity = transform.up * speed;
    }

    private void Update()
    {
        //destroying the bullets
        if (transform.position.y > 15f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Invaders invader = other.GetComponent<Invaders>();
            if (invader != null)
            {
                invader.destroySelf();
            }


            Destroy(gameObject);
        }
        
        
    }

}
