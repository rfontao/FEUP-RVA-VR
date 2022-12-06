using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BossSpawner : MonoBehaviour
{

    [SerializeField] private GameObject slime;
    void Start()
    {}

    void Update()
    {}

    public void UpdateDeadSlimes()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
