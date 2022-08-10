using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

   
    public float moveSpeed;

    RectTransform rectTransform;

    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        
        rectTransform = gameObject.GetComponent<RectTransform>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);


        if (rectTransform.offsetMin.y < -5523.966f) //-2742.148, -2000, -4797.888f
        {
            transform.position = startPos;
        }
    }

}
