using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{ 
    [SerializeField] AudioSource zombieAudioSources;
    private void OnTriggerEnter(Collider other) {

        if(other.CompareTag("Player")){
         zombieAudioSources.clip = AudioManager.Instance.GetZombieSound();
         zombieAudioSources.Play();
        }
    }
}
