using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyTutorialScene : MonoBehaviour
{
    public void backToPrevious()
    {
        SceneManager.LoadScene(2);
    }

    public void loadPowerUpTutorial()
    {
        SceneManager.LoadScene(4);
    }
}
