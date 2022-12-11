using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BossSpawner : MonoBehaviour
{

    [SerializeField] private GameObject slime;
    [SerializeField] private TextMeshProUGUI text;
    void Start()
    {}

    void Update()
    {}

    public void UpdateDeadSlimes()
    {
        int number = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (number == 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else text.text = number.ToString();

    }
}
