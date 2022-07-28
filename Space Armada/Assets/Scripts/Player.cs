using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Health health;

    // Start is called before the first frame update
    void Start()
    {
        GameUI.instance.setLivesText(health.currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Bounds for the player
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -13.85f, 13.85f), Mathf.Clamp(transform.position.y, -13.51f, 13.51f));
    }
}
