using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum sfxAudio
{
    sfx_boom_edited,
    sfx_boom_edited_new,
    sfx_boom_edited_new_2,
    sfx_laser_edited,
    sfx_ting_edited

}

public class AudioManager : MonoBehaviour
{
   
    public static AudioManager instance;
    public AudioSource source;

    List<AudioClip> clips = new List<AudioClip>();

    public AudioClip[] bgMusic;

    void Awake()
    {


        if (instance == null)
        {
            instance = this;
        }
       
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (string audio in System.Enum.GetNames(typeof(sfxAudio)))
            clips.Add(Resources.Load<AudioClip>("sfx/" + audio));

        SceneManager.sceneLoaded += OnSceneLoaded;

    }


    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (source.isPlaying && source.clip == bgMusic[1] && SceneManager.GetActiveScene().name != "Space Armada")
        {
            return;
        }

        if (SceneManager.GetActiveScene().name == "Space Armada")
        {
            source.clip = bgMusic[0];
            source.Play();
            

        }

        else
        {
            source.clip = bgMusic[1];
            source.Play();
        }


    }

    public void playBgMusic()
    {
        

        if (SceneManager.GetActiveScene().name == "Space Armada")
        {
            source.clip = bgMusic[0];
            source.Play();
          
        }

        else
        {
            source.clip = bgMusic[1];
            source.Play();
        }
    }

    public void playSound(sfxAudio audio)
    {
        source.PlayOneShot(clips[(int)audio]);

    }
}

/* IEnumerator sceneCheck()
    {

        playBgMusic();

        yield return new WaitForSeconds(0.5f);

        Debug.Log("repeating courortine");

        StartCoroutine(sceneCheck());
    }*/
