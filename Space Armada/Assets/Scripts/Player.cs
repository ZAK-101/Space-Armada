using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Bounds for the player
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -4.975f, 4.975f), Mathf.Clamp(transform.position.y, -4.689f, 4.689f));
    }
}
