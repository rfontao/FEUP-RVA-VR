using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using Random = UnityEngine.Random;

public class DifficultyController : MonoBehaviour
{

    [SerializeField] private GameObject slime;
    [SerializeField] private GameObject turtle;
    [SerializeField] private TextMeshProUGUI text;

    private int currentDiff = 2;
    
    private GameObject[] spawnPoints;

    private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        boss = GameObject.FindGameObjectWithTag("Boss").transform.GetChild(0).gameObject;
        Debug.Log(GameObject.FindGameObjectWithTag("Boss").transform.GetChild(0).gameObject);
        spawnEnemies(4);
    }

    public void ChangeDifficulty(int diff)
    {
        if (currentDiff == diff) return;
        currentDiff = diff;
        spawnEnemies(diff * 2);
        boss.GetComponent<ArrowHit>().SetHP(diff * 4);
    }
    
    private void spawnEnemies(int numberEnemies)
    {
        DestroyEnemies();
        foreach (var point in spawnPoints)
        {
            for (int i = 0; i < numberEnemies; i++)
            {
                Vector3 v3 = Random.insideUnitCircle * 5;
                if(Random.Range(0,99) < 50)
                    Instantiate(slime, point.transform.position + v3, Quaternion.identity);
                else
                    Instantiate(turtle, point.transform.position + v3, Quaternion.identity);
            }
        }

        text.text = (numberEnemies * 2).ToString();
    }

    private void DestroyEnemies()
    {
        try
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject go in gos)
                Destroy(go);
            gos = GameObject.FindGameObjectsWithTag("DeadEnemy");
            foreach(GameObject go in gos)
                Destroy(go);
        }
        catch (Exception e)
        {
            //There are no enemies with a wanted created yet, most likely "DeadEnemy"
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
