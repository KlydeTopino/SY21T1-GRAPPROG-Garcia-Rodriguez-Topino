using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Configs")]
    public PlayerController2D controller;
    public float runSpeed;
    public Animator playerAnimator;
    public Rigidbody2D playerRigidbody;

    float horizontalMove = 0f;
    public bool jump = false;
    
    [Header("Inventory")]
    public int Keys = 0;

    private enum State { idle, running, jumping }
    private State state = State.idle;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f, 0f);
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
       

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            //state = State.jumping;
        }

        UpdateKey();
        VelocityState();
        playerAnimator.SetInteger("state", (int)state);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, jump);
        jump = false; //Single Jump Only
    }

    public void UpdateKey()
    {

    }

    private void VelocityState()
    {
        if(state == State.jumping)
        {

        }

        else if(Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon)
        {
            state = State.running;
        }

        else
        {
            state = State.idle;
        }
    }

}
