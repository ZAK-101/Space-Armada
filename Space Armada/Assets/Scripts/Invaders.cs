using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public int rows = 5;
    public int columns = 11;
    public GameObject[] invaderPrefabs;

    public float invadersSpacing;

    private void Awake()
    {
        spawnInvaders();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnInvaders()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = invadersSpacing * (this.columns - 1);
            float height = invadersSpacing * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPos = new Vector3 (centering.x, centering.y + (row * invadersSpacing), 0.0f);

            for (int col = 0; col < this.columns; col++)
            {
                GameObject invader = Instantiate(this.invaderPrefabs[row], this.transform);
                Vector3 pos = rowPos;
                pos.x += col * invadersSpacing;
                invader.transform.localPosition = pos;
            }
        }
    }
}
