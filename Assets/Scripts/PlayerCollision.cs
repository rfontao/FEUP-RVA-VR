using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private List<GameObject> hearts;

    private int numberHits;
    private float immunityTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(immunityTime < 20f) //prevents overflow in case the user is not hit in a very long time
            immunityTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (immunityTime > 5f)
        {
            immunityTime = 0f;
            hearts[numberHits].SetActive(false);
            numberHits++;
        }
    }
}
