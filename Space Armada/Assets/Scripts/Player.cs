using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int livesLeft;

    // Start is called before the first frame update
    void Start()
    {
        livesLeft = 1;
        GameUI.instance.setLivesText(livesLeft);
    }

    // Update is called once per frame
    void Update()
    {
        //Bounds for the player
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -15.49f, 15.49f), Mathf.Clamp(transform.position.y, -13.51f, 13.51f));
    }
}
