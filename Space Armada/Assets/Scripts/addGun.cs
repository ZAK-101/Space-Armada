using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addGun : pickupParent
{
    private bool isActive = false;

    public addGun()
    {
        namePickup = "addGun"; 
        duration = 7.0f;
    }

    protected override void Update()
    {
        base.Update();
        if (isActive == true)
        {
            duration -= Time.deltaTime;
            PlayerController.instance.GetComponent<Weapon>().isAddGunActive = true;
        }

        if (duration <= 0)
        {
            PlayerController.instance.GetComponent<Weapon>().isAddGunActive = false;
            Destroy(gameObject);
        }
    }
 
    protected override void additionalGun()
    {
        isActive = true;
    }
}
