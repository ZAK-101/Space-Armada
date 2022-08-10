using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject canvas;
    Canvas canvasRenderer;


    public void pauseGame()
    {
        canvasRenderer = canvas.GetComponent<Canvas>();
        canvasRenderer.sortingLayerID = SortingLayer.NameToID("menu");
        gameObject.SetActive(true);
        AudioManager.instance.source.Pause();
        Time.timeScale = 0f;
        
    }

    public void resumeGame()
    {
        canvasRenderer = canvas.GetComponent<Canvas>();
        canvasRenderer.sortingLayerID = SortingLayer.NameToID("Default");
        gameObject.SetActive(false);
        AudioManager.instance.source.Play();
        Time.timeScale = 1f;
        
    }

    public void home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


}
