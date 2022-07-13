using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    public TextMeshProUGUI score;
    public TextMeshProUGUI enemiesLeft;
    public TextMeshProUGUI waves;
    public TextMeshProUGUI lives;
    
    public void Awake()
    {
        instance = this;
    }

    void OnDestroy()
    {
        instance = null;
    }

    public void setScoreText(int value)
    {
        score.text = value.ToString();
    }

    public void setEnemiesLeftText(int value)
    {
        enemiesLeft.text = value.ToString();
    }

    public void setWavesText(int value)
    {
        waves.text = value.ToString();
    }

    public void setLivesText(int value)
    {
        lives.text = value.ToString();
    }
}
