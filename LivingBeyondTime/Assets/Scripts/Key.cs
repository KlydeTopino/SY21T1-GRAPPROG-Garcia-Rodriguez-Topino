using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer KeySprite;
    [HideInInspector] public BoxCollider2D KeyCollider;
    public TextMeshProUGUI KeyQuantityText;
    public Player PlayerScript;
    private bool isExecuted = false;

    // Start is called before the first frame update
    void Start()
    {
        KeyCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isExecuted)
        {
            SoundManager.PlaySound("Pickup_Key");
            isExecuted = true;
            KeyCollider.enabled = false;
            PlayerScript.Keys += 1;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        KeyQuantityText.text = "x " + PlayerScript.Keys;
    }

}
