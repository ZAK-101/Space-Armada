using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        //bullet travel
        rb2d.velocity = (transform.up * -1.0f) * speed;
    }

    private void Update()
    {
        //destroying the bullets
        if (transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            Health player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
            player.takeDamage(damage);
            GameUI.instance.setLivesText(player.currentHealth);
            Destroy(gameObject);
        }


    }
}
