using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum sfxAudio
{
    sfx_boom,
    sfx_laser,
    sfx_ting

}

public class AudioManager : MonoBehaviour
{
   
    public static AudioManager instance;
    public AudioSource source;
    List<AudioClip> clips = new List<AudioClip>();

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
       
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (string audio in System.Enum.GetNames(typeof(sfxAudio)))
            clips.Add(Resources.Load<AudioClip>("sfx/" + audio));

    }

    public void playSound(sfxAudio audio)
    {
        source.PlayOneShot(clips[(int)audio]);

    }
}
