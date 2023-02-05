using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //Components
    Rigidbody2D rb;

    //Player
    float walkSpeed = 4f;
    float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    public GameObject interactionText;

    AudioSource audioSource; 

    //Animations
    Animator animator;
    string currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_DOWN = "Player_Walk_Down";
    const string PLAYER_WALK_UP = "Player_Walk_Up";
    const string PLAYER_WALK_LEFT = "Player_Walk_Left";
    const string PLAYER_WALK_RIGHT = "Player_Walk_Right";

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }

            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);

            if (inputHorizontal > 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT);
            }
            else if (inputHorizontal < 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT);
            }
            else if (inputVertical > 0)
            {
                ChangeAnimationState(PLAYER_WALK_UP);
            }
            else if (inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_WALK_DOWN);
            }
        }
        else 
        {
            audioSource.Stop();
            rb.velocity = new Vector2(0f,  0f);
            ChangeAnimationState(PLAYER_IDLE);
        }
    }

    //Animation state Changer
    void ChangeAnimationState(string newState)
    {
        //Stop animation from interrupting itself;
        if (currentState == newState) return;

        //Play new animation
        animator.Play(newState);

        //Update current state
        currentState = newState;
    }

    public void ShowInteraction(bool show)
    {
        if(interactionText.activeSelf != show)
            interactionText.SetActive(show);
    }
}
