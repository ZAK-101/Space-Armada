using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rapidFire : pickupParent
{
    private bool isActive = false;

    public rapidFire()
    {
        namePickup = "rapidFire";
        duration = 5.0f;
    }

    protected override void Update()
    {
        base.Update();
        if (isActive == true)
        {
            duration -= Time.deltaTime;
            PlayerController.instance.timer = 0f;
        }
       
        if (duration <= 0)
        {
            PlayerController.instance.timer = 0.75f;
            Destroy(gameObject);
        }
    }

    protected override void removeShootDelay()
    {
        //Debug.Log("override succes");
        isActive = true;

    }
}
