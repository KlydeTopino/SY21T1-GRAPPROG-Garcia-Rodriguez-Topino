using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public Animator playerAnimator;
    public Rigidbody2D playerRigidbody;

    private enum State { idle, running, jumping }
    private State state = State.idle;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        VelocityState();
        playerAnimator.SetInteger("state", (int)state);
    }

    private void VelocityState()
    {
        if (Input.GetButtonDown("Jump"))//LT par try mo i-play. Hyper sya ih //state == State.jumping;
        {
            state = State.jumping;
        }

        else if (Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon)
        {
            state = State.running;
        }

        else
        {
            state = State.idle;
        }
    }
}
