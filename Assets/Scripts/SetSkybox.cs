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

        skybox.material = now.Hour is > 18 or < 6 ? nightSkybox : daySkybox;
    }
    
}
