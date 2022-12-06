using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{

    public AudioMixer mixer;


    public void SetGlobalVolume(float value){
        mixer.SetFloat("MasterVol", Mathf.Log10(value) * 20);
    }

    public void SetAmbientVolume(float value){
        mixer.SetFloat("Ambient/MusicVol", Mathf.Log10(value) * 20);
    }

    public void SetCreatureVolume(float value){
        mixer.SetFloat("Objects/CreaturesVol", Mathf.Log10(value) * 20);
    }

    public void SetOtherVolume(float value){
        mixer.SetFloat("OtherVol", Mathf.Log10(value) * 20);
    }
}
