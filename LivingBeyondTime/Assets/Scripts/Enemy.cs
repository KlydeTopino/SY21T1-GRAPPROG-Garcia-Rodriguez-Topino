using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator enemyAnimator;

    public int maxHearts = 3;
    int currentHearts;

    public float destroyDelay = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentHearts = maxHearts;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHearts -= damage;
        enemyAnimator.SetTrigger("Hurt");

        if (currentHearts <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");

        SoundManager.PlaySound("EnemyDead");
        enemyAnimator.SetBool("IsDead", true);

        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, destroyDelay);
    }
}
