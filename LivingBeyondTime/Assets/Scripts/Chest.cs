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
    public GameObject Potion;
    public int KeyOffset;
    public int PotionOffset;

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
            SummonPotion();

            ClosedChestCollider.enabled = false;
            ClosedChestSprite.enabled = false;
        }
    }

    public void SummonKey()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + KeyOffset, transform.position.z);

        Instantiate(Item, spawnPos, Quaternion.identity);
    }

    public void SummonPotion()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + PotionOffset, transform.position.z);

        Instantiate(Potion, spawnPos, Quaternion.identity);
    }

}
