using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public GameObject Player;
    public BoxCollider2D Boundary;
    public MainMenu MainMenuScript;

    void Start()
    {
        Boundary = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (MainMenuScript.IsStarting)
        {
            Boundary.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Future: Add Feature 
            //Debug.Log("Hit");
        }
    }
}
