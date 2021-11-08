using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    [Header("Player Components")]
    public Animator playerAnimator;
    public Rigidbody2D playerRigidbody;
    public Collider2D coll;

    public LayerMask ground;
    //FSM States
    public enum State { idle, running, jumping, falling, hurt, death }
    public State state = State.idle;

    Player playerScript;
    SpikeTileset SpikeTilesetScript;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        playerScript = GetComponent<Player>();
        SpikeTilesetScript = GetComponent<SpikeTileset>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.horizontalMove < 0)
        {
            state = State.running;
        }
        else if (playerScript.horizontalMove > 0)
        {
            state = State.running;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }

        VelocityState();
        playerAnimator.SetInteger("state", (int)state);
    }

    private void VelocityState()
    {
        if (state == State.jumping)//LT par try mo i-play. Hyper sya ih //state == State.jumping;
        {
            if(playerRigidbody.velocity.y < 0f)
            {
                state = State.falling;
            }
        }

        else if (state == State.falling)
        {
            if(coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
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

    private void Attack()
    {
        playerAnimator.SetTrigger("SpearAttack");
    }

   public void DeathAnimation()
   {
        if (SpikeTilesetScript.TotalHearts  == 0)
        {
            playerAnimator.SetTrigger("Death");
        }
   }



}

