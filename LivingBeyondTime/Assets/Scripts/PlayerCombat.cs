using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator playerAnimator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = .5f;
    public int attackDamage = 1;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public float constant = 1f;

    PlayerCombat PlayerCombatScript;
    PlayerFSM PlayerFSMScript;


    // Start is called before the first frame update
    void Start()
    {
        PlayerCombatScript = GetComponent<PlayerCombat>();
        PlayerFSMScript = GetComponent<PlayerFSM>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerFSMScript.hasDied)
        {
            PlayerCombatScript.enabled = false;
        }

        if (Time.time >= nextAttackTime) //Checks if it exceeds the nextAttackTime so the player can attack again
        {
            if (Input.GetButtonDown("Attack"))
            {
                Attack();
                nextAttackTime = Time.time + constant / attackRate; // interval of attacks to avoid spamming the attack button
            }
        }
    }

    void Attack()
    {
        //Trigger Attack Animation
        playerAnimator.SetTrigger("SpearAttack");
        //Determines the range of the attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
