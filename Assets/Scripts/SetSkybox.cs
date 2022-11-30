using System;
using UnityEngine;

[RequireComponent(typeof(Skybox))]
public class SetSkybox : MonoBehaviour
{
    [SerializeField] private Material daySkybox;
    [SerializeField] private Material nightSkybox;

    private void Start()
    {
        var now = DateTime.Now;
        var skybox = GetComponent<Skybox>();

        if (now.Hour is > 18 or < 6)
        {
            skybox.material = nightSkybox;
            var light = GameObject.Find("Directional Light");
            light.SetActive(false);
            RenderSettings.ambientIntensity = 0.15f;
        }
        else
        {
            skybox.material = daySkybox;
        }
    }
}