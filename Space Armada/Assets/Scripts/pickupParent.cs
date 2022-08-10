using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupParent : MonoBehaviour
{
    protected string namePickup;
    [SerializeField] protected float duration;
    private bool isHit = false;

    public float moveSpeed;

    public pickupParent()
    {
        namePickup = "default";
        duration = 1.0f;

    }


    protected virtual void Update()
    {
        if(isHit == true)
        {
            transform.Translate(Vector2.zero);
            return;
        }

        //movement(direction * speed * sync)
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        if (transform.position.y < -20f)
        {

            Destroy(gameObject);

        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (namePickup == "rapidFire")
            {
                removeShootDelay();
                Debug.Log("rapidFire");
            }

            else if (namePickup == "addGun")
            {
                additionalGun();
                Debug.Log("addGun");
            }

            else if (namePickup == "addLife")
            {
                additionalLife();
                Debug.Log("addLife");
            }
        }

        AudioManager.instance.playSound(sfxAudio.sfx_ting);
        //disabling the sprite renderer and its collider
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        isHit = true;
    }


    protected virtual void removeShootDelay()
    {

    }

    protected virtual void additionalGun()
    {

    }

    protected virtual void additionalLife()
    {

    }
}
