using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.VFX;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] AudioSource EnemyKillSound;
    Dictionary<string, AudioSource> AudioDictionary = new Dictionary<string, AudioSource>();


    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        AudioDictionary.Add("kill",EnemyKillSound);
       
    }

    public void PlaySFX(string sfx)
    {
        AudioDictionary[sfx].Play();
    }
    public void PlayBGM(string bgm){
        
         AudioDictionary[bgm].Play();
    }
    public void StopBGM(string bgm){
        
         AudioDictionary[bgm].Stop();
    }
}
