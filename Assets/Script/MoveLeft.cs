using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    public PlayerController playerControllerScript;
 
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
       
        if(!playerControllerScript.gameOver)
        { transform.Translate(Vector3.left * speed * Time.deltaTime); }

        if(transform.position.y <= -1)
        { Destroy(gameObject); }
    }
}
