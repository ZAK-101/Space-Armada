using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public void loadPlayScene()
    {
        SceneManager.LoadScene(1);
    }

    public void loadTutorialScene()
    {
        SceneManager.LoadScene(2);
    }
    
    public void exitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
