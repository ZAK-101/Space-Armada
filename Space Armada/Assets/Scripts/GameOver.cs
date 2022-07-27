using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI finalScoreTxt;

    public void setup(int score)
    {
        gameObject.SetActive(true);
        finalScoreTxt.text = score.ToString() + " POINTS";
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
    }

    public void home()
    {
        SceneManager.LoadScene(0);
    }
}
