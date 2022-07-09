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
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -10.5f, 10.5f), Mathf.Clamp(transform.position.y, -8.52f, -8.52f));
    }
}
