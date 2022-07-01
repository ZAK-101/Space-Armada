using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firingPoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot()
    {
        //spawning the bullet
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}
