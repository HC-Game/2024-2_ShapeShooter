using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.VFX;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] zombie;

    private static AudioManager instance;
    [SerializeField] AudioSource[] audioSources;
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

        AudioDictionary.Add("kill",audioSources[0]);
        AudioDictionary.Add("hit",audioSources[1]);
        AudioDictionary.Add("falseHit",audioSources[2]);
        AudioDictionary.Add("MenuBGM",audioSources[3]);
        AudioDictionary.Add("InGameBGM",audioSources[4]);
        AudioDictionary.Add("GameOver",audioSources[5]);
        AudioDictionary.Add("Clear",audioSources[6]);
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
    public AudioClip GetZombieSound(){
       return zombie[Random.Range(0,zombie.Length)];
     
    }
}
