using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public int damage;

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
            Health invader = other.GetComponent<Health>();
            Invader invaderAmount = GameObject.FindGameObjectWithTag("invaderManager").GetComponent<Invader>();
            if (invader != null)
            {
                invader.takeDamage(damage);

                if (invader.currentHealth <= 0)
                {
                    AudioManager.instance.playSound(sfxAudio.sfx_boom);

                    invaderAmount.amountKilled++;
                    invaderAmount.enemiesLeft--;
                   
                    GameUI.instance.setEnemiesLeftText(invaderAmount.enemiesLeft);
                    GameUI.instance.setScoreText(invaderAmount.amountKilled);
                }
               
              
            }


            Destroy(gameObject);
        }
        
        
    }

}
