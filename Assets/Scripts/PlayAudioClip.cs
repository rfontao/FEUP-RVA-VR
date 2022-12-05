using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioClip : MonoBehaviour
{
    
    [SerializeField]
    AudioClip walk;
    
    [SerializeField]
    AudioClip die;
    
    [SerializeField]
    AudioClip run;

    [SerializeField]
    AudioSource audioSource;

    public void EnemyWalk(){
        audioSource.clip = walk;
        audioSource.Play();
    }

    public void EnemyDie(){
        audioSource.clip = die;
        audioSource.Play();
    }

    public void EnemyRun(){
        audioSource.clip = run;
        audioSource.Play();
    }

}
