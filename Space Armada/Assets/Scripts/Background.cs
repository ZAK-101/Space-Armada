using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    private float height;
    public float moveSpeed;

    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        height = 80f;
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        

        if (rectTransform.offsetMin.y < -2000f)
        {
            //Debug.Log("Gumagana");
            reposition();

        }
    }

    private void reposition()
    {

        Vector2 vector = new Vector2(0, height);
        gameObject.transform.position = (Vector2)transform.position + vector;
    }
}
