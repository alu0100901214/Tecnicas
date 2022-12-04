using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField]
    private CinemachineVirtualCamera vcamA;


    public float force = 200f;
    public float jumpForce = 1000f;
    public NoiseSettings myNoiseProfile;

    // Delegate Event for Background
    public delegate void parallax(bool right);
    public event parallax OnMove;
    public event parallax OnStop;

    private bool isJumping;


    private float inputHorizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        isJumping = false;
    }


    void Update(){ 
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetKey(KeyCode.E)){
            vcamA.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = myNoiseProfile;
        } else{
            vcamA.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = null;
        }
    }


    void FixedUpdate() {
        
        // Move character Horizontal

        if(inputHorizontal != 0){
            rb.AddForce(new Vector2(inputHorizontal * force, 0f));
            animator.SetBool("isWalking", true);
        } else {
            OnStop(false);
            animator.SetBool("isWalking", false);
        }

        // Flip character

        if(inputHorizontal > 0){
            spriteRenderer.flipX = false;
            OnMove(true);
        } else if(inputHorizontal < 0){
            spriteRenderer.flipX = true;
            OnMove(false);
        }


        // Jump character

        if( (Input.GetKey(KeyCode.Space)) && (!isJumping)){
            //isJumping = true;
            rb.AddForce(transform.up * jumpForce);
        }
            
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Platform"){
            isJumping = false;
        }
    }

        void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Platform"){
            isJumping = true;
        }
    }



}
