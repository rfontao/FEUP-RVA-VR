using System;
using UnityEngine;

[RequireComponent(typeof(Skybox))]
public class SetSkybox : MonoBehaviour
{
    [SerializeField] private Material daySkybox;
    [SerializeField] private Material nightSkybox;
    [SerializeField] private GameObject light;

    private Skybox skybox;

    private void Awake()
    {
        skybox = GetComponent<Skybox>();
        SetAutomatic();
    }

    private void Start()
    {
        
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
        light.SetActive(false);
        RenderSettings.ambientIntensity = 0.15f;
        RenderSettings.ambientLight = new Color32(15, 15, 15, 0);

    }

    public void SetDay()
    {
        skybox.material = daySkybox;
        light.SetActive(true);
        RenderSettings.ambientIntensity = 1.0f;
        RenderSettings.ambientLight = new Color32(170, 170, 170, 0);

    }
}