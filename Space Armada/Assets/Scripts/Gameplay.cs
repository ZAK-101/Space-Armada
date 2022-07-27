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

        StartCoroutine(getChildHealthComponent());
    }

    private void Update()
    {
      
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

        gameOver.setup(invader.amountKilled);
    }


}
