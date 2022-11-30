using System;
using UnityEngine;

[RequireComponent(typeof(Skybox))]
public class SetSkybox : MonoBehaviour
{
    [SerializeField] private Material daySkybox;
    [SerializeField] private Material nightSkybox;

    private Skybox skybox;

    private void Start()
    {
        skybox = GetComponent<Skybox>();
        SetAutomatic();
    }

    public void SetAutomatic()
    {
        var now = DateTime.Now;
        if (now.Hour is > 18 or < 6)
        {
            SetNight();
        }
        else
        {
            SetDay();
        }
    }

    public void SetNight()
    {
        skybox.material = nightSkybox;
        var light = GameObject.Find("Directional Light");
        light.SetActive(false);
        RenderSettings.ambientIntensity = 0.15f;
    }

    public void SetDay()
    {
        skybox.material = daySkybox;
        var light = GameObject.Find("Directional Light");
        light.SetActive(true);
        RenderSettings.ambientIntensity = 1.0f;
    }
}