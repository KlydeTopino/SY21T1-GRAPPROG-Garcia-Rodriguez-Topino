using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer ClosedChestSprite;
    [HideInInspector] public BoxCollider2D ClosedChestCollider;

    public GameObject OpenedChest;
    public ParticleSystem GoldEffect;
    public GameObject Item;
    public int ItemOffset;
    // Start is called before the first frame update
    void Start()
    {
        ClosedChestSprite = gameObject.GetComponent<SpriteRenderer>();
        ClosedChestCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OpenedChest.SetActive(true);
            GoldEffect.Play();
            SummonKey();

            ClosedChestCollider.enabled = false;
            ClosedChestSprite.enabled = false;
        }
    }

    public void SummonKey()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + ItemOffset, transform.position.z);

        Instantiate(Item, spawnPos, Quaternion.identity);
    }
}
