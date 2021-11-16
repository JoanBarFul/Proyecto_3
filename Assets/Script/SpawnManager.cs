using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public float startDelay = 2.0f;
    public float repeatRate = 2.0f;
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    public PlayerController playerControllerScript;
    private int randomObj;

 
    void Start()
    {
        InvokeRepeating("Spawner", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

  
    void Update()
    {
      
    }
    private void Spawner()
    {
        if (!playerControllerScript.gameOver)
        { 
            Instantiate(obstaclePrefab[randomObj], spawnPos, obstaclePrefab[randomObj].transform.rotation);
            randomObj = Random.Range(0, obstaclePrefab.Length);
        }

    }
}
