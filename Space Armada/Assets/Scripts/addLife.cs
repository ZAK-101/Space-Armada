using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addLife : pickupParent
{
    private int incrementValue = 1;

    public addLife()
    {
        namePickup = "addLife";
        duration = 0.0f;
    }



    protected override void additionalLife()
    {
        Health health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        health.incrementLife(incrementValue);
        GameUI.instance.setLivesText(health.currentHealth);
        Destroy(gameObject);
    }
}
