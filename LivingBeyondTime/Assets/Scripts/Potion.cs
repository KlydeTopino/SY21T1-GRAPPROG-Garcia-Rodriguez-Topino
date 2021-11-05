using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Potion : MonoBehaviour
{
    [HideInInspector] public BoxCollider2D PotionCollider;
    public TextMeshProUGUI PotionQuantityText;
    public Player PlayerScript;
    private bool isExecuted = false;

    // Start is called before the first frame update
    void Start()
    {
        PotionCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isExecuted)
        {
            isExecuted = true;
            PotionCollider.enabled = false;
            PlayerScript.Potion += 1;
            PotionQuantityText.text = "x " + PlayerScript.Potion;
            Destroy(gameObject);
        }
    }
}
