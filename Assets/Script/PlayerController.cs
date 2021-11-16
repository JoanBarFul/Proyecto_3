using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float jumpForce = 400f;
    public float gravityMod = 1.5f;
    public bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnimator;
    private Animator playerdeath;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
        playerAnimator = GetComponent<Animator>();
        playerdeath = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            isOnGround = false;
        }

        

    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Ground"))
        { isOnGround = true; }
        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GAME OVER");
            gameOver = true;
            playerdeath.SetBool("Death_b", true);
        }

    }

}
