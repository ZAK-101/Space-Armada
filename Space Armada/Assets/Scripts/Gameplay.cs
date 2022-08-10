using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{

    public static Gameplay instance;

    Player player;
    public GameObject player1;

    public Invader invader;
    public GameObject invaderParent;

    public GameOver gameOver;

    public Pause pause;
    public GameObject pauseObj;

    public GameObject[] pickups;

    Camera cam;
    Vector2 camBounds;

    private void Awake()
    {
        player = player1.GetComponent<Player>();
        instance = this;
    }

    private void OnDestroy()
    {
        instance = null;
    }

    private void Start()
    {
        player.health.onDeath += playerDeath;

        cam = Camera.main;
        camBounds = cam.ScreenToWorldPoint(Vector2.zero);

        InvokeRepeating("spawnPickups", 3f, 5f);

        StartCoroutine(getChildHealthComponent());

       
    }

    private void Update()
    {
      
    }

    private void spawnPickups()
    {
        int randomPickup = Random.Range(0, 3);

        for (int i = 0; i < pickups.Length; i++)
        {
           if (i == randomPickup)
           {
                Instantiate(pickups[i], camBounds * Vector2.down + new Vector2(Random.Range(-12.5f, 12.5f), 0), Quaternion.identity);
                break;
           }

           else
           {
                continue;
           }
        }
    }

    IEnumerator getChildHealthComponent()
    {
        for (int i = 0; i < invaderParent.transform.childCount; i++)
        {
            invaderParent.transform.GetChild(i).GetComponent<Health>().onDeath += enemyDeath;
        }

        yield return new WaitForSeconds(0.1f);
  
        StartCoroutine(getChildHealthComponent());
    }

    public void enemyDeath()
    {
        for (int i = 0; i < invaderParent.transform.childCount; i++)
        {
            if (invaderParent.transform.GetChild(i).GetComponent<Health>().currentHealth <= 0)
            {
             
                Destroy(invaderParent.transform.GetChild(i).gameObject);
            }
        }
    }

    public void playerDeath()
    {
        Destroy(player1);
        StartCoroutine(showGameOver());
        
    }

    IEnumerator showGameOver()
    { 
        yield return new WaitForSeconds(1f);
        pauseObj.SetActive(false);
        gameOver.setup(invader.amountKilled);
    }

    public void pauseSelect()
    {
        pause.pauseGame();
    }


}
