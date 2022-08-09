using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class powerupTutorialScene : MonoBehaviour
{
    public void backToPrevious()
    {
        SceneManager.LoadScene(3);
    }

    public void backToHome()
    {
        SceneManager.LoadScene(0);
    }
}
