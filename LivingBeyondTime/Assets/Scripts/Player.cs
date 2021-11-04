using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Configs")]
    public PlayerController2D controller;
    public float runSpeed;
    

    float horizontalMove = 0f;
    public bool jump = false;
    
    [Header("Inventory")]
    public int Keys = 0;


    void Start()
    {
        
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

        
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, jump);
        jump = false; //Single Jump Only
    }

}
