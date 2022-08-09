using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlTutorialScene : MonoBehaviour
{
   public void backToHomescreen()
    {
        SceneManager.LoadScene(0);
    }

    public void loadEnemyTutorial()
    {
        SceneManager.LoadScene(3);
    }
}
