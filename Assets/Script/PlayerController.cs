using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float jumpForce = 400f;
    public float gravityMod = 1f;
    public bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnimator;
    private Animator playerdeath;
    private int randomDeath;
    public ParticleSystem particlesExplosion;
    public ParticleSystem particlesRun;
    private AudioSource playerAudio;
    public AudioClip jumpClip;
    public AudioClip explosionClip;
    private AudioSource cameraAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
        playerAnimator = GetComponent<Animator>();
        playerdeath = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        cameraAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            isOnGround = false;
            particlesRun.Stop();
            playerAudio.PlayOneShot(jumpClip, 1);
        }


        

    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        { 
        if (otherCollider.gameObject.CompareTag("Ground"))
        { isOnGround = true;
            particlesRun.Play();
        }
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log("GAME OVER");
            gameOver = true;
            randomDeath = Random.Range(1, 3);
            playerdeath.SetBool("Death_b", true);
            playerdeath.SetInteger("DeathType_int", randomDeath);
            particlesExplosion.Play();
            particlesRun.Stop();
            playerAudio.PlayOneShot(explosionClip, 1);
                cameraAudio.Stop();
            

        }
        }
    }

}
