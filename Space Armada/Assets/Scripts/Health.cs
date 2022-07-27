using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public delegate void OnDeath();
    public event OnDeath onDeath;

    SpriteRenderer gameObj;

    // Start is called before the first frame update
    void Start()
    {
        gameObj = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int value)
    {
        if (currentHealth <= 0)
            return;

        currentHealth -= value;

        if (currentHealth >= 1)
        {
            StartCoroutine(flashEffect());
        }
        
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            death();
        }
    }

    public void death()
    {

        if (onDeath != null)
        {
            onDeath();
        }

    }

    IEnumerator flashEffect()
    {
        gameObj.color = new Color(0.6603774f, 0.3706835f, 0.3706835f, 1f);
        yield return new WaitForSeconds(0.15f);
        gameObj.color = new Color(1f, 1f, 1f, 1f);

    }
}
