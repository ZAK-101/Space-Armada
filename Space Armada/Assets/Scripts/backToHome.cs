using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToHome : MonoBehaviour
{
   public void backToHomescreen()
    {
        SceneManager.LoadScene(0);
    }
}
