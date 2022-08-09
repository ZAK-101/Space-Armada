using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firingPoint;
    public GameObject bulletPrefab;

    public Transform firingPoint2;
    public Transform firingPoint3;

    public bool isAddGunActive = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot()
    {
        if (isAddGunActive == true)
        {
            Instantiate(bulletPrefab, firingPoint2.position, firingPoint2.rotation);
            Instantiate(bulletPrefab, firingPoint3.position, firingPoint3.rotation);
        }

        else
        {
            //spawning the bullet
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        }
       
    }
}
