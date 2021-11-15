using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    [Header("Player Components")]
    public Animator playerAnimator;
    public Rigidbody2D playerRigidbody;
    public Collider2D coll;
    public ParticleSystem DustPS;

    public LayerMask ground;
    //FSM States
    public enum State { idle, running, jumping, falling, hurt, death }
    public State state = State.idle;

    [Header("Configuration/s")]
    public SpikeTileset SpikeTilesetScript;
    Player playerScript;
    [HideInInspector] public bool hasDied = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        playerScript = GetComponent<Player>();
        //SpikeTilesetScript = GetComponent<SpikeTileset>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }

        if (state == State.running)
        {
            CreateDust();
        }

        VelocityState();
        playerAnimator.SetInteger("state", (int)state);
    }

    public void VelocityState()
    {
        if (SpikeTilesetScript.TotalHearts != 0 && !hasDied)
        {

            if (playerScript.horizontalMove < 0)
            {
                state = State.running;
            }
            else if (playerScript.horizontalMove > 0)
            {
                state = State.running;
            }

            if (state == State.jumping)//LT par try mo i-play. Hyper sya ih //state == State.jumping;
            {      
                if (playerRigidbody.velocity.y < 0f)
                {
                    state = State.falling;
                }
            }

            else if (state == State.falling)
            {
                if (coll.IsTouchingLayers(ground))
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
        else
        {
            // Play animation once
            if (!hasDied)
            {
                SoundManager.PlaySound("Dead");
                DeathAnimation();
                hasDied = true;
            }
        }

    }

    private void Attack()
    {
        playerAnimator.SetTrigger("SpearAttack");
        SoundManager.PlaySound("Attack");
    }

    public void DeathAnimation()
    {
        //state = State.death;
        playerAnimator.SetTrigger("Death");
        playerScript.enabled = false;
        this.enabled = false;
    }

    public void CreateDust()
    {
        DustPS.Play();
    }
}