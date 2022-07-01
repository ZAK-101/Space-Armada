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
        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }

}
