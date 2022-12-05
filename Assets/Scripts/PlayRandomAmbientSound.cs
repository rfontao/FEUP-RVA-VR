using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAmbientSound : MonoBehaviour
{
    [SerializeField]
    float min_time = 15;
    [SerializeField]
    float max_time = 85;

    float current_time = 0;

    [SerializeField]
    List<AudioClip> randomAudioClips = new List<AudioClip>();

    [SerializeField]
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        current_time = Random.Range(min_time, max_time);
    }

    // Update is called once per frame
    void Update()
    {
        current_time -= Time.deltaTime;

        if(current_time < 0){
            current_time += Random.Range(min_time, max_time);
            audioSource.clip = randomAudioClips[Random.Range(0, randomAudioClips.Count)];
            audioSource.Play();
        }
    }
}
