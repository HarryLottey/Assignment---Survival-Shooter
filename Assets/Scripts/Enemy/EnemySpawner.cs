using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public float spawnTimer;
    public float spawnInterval = 10f;
    public GameObject enemyPrefab;

    int spawnPointMaxIndex = 8;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer > spawnInterval)
        {
            

            for (int i = 0; i < spawnPoints.Length; i++) 
            {
                Instantiate(enemyPrefab, spawnPoints[i].localPosition, spawnPoints[i].localRotation);
                //Instantiate(enemyPrefab, spawnPoints[i]);
                spawnTimer = 0f;
                spawnInterval -= 0.05f;
            }
           
        }

        if (spawnInterval <= 5f)
        {
            spawnInterval = 10f;
        }

    }
}
