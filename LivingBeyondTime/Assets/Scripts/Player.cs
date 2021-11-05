using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Configs")]
    public PlayerController2D controller;
    public float runSpeed;
    

    public float horizontalMove = 0f;
    public bool jump = false;
    public Collider2D coll;
    public LayerMask ground;

    PlayerFSM PlayerFSMScript;

    [Header("Inventory")]
    public int Keys = 0;
    public int Potion = 0;

    void Start()
    {
        PlayerFSMScript = GetComponent<PlayerFSM>();
        coll = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Input.GetAxis("Horizontal") * 15f * Time.deltaTime, 0f, 0f);
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
       

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) && coll.IsTouchingLayers(ground))
        {
            jump = true;
            PlayerFSMScript.state = PlayerFSM.State.jumping;
            //state = State.jumping;
        }

        
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, jump);
        jump = false; //Single Jump Only
    }

}
