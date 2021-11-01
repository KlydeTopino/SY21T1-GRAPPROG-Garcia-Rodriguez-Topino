using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveExit : MonoBehaviour
{
    public GameObject Teleport;
    public GameObject NightSky;

    private bool canEnter = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canEnter = true;
        EnterCave(collision, canEnter);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canEnter = true;
        EnterCave(collision, canEnter);
    }

    public void EnterCave(Collider2D collision, bool isEnter)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetButtonDown("Enter") && isEnter)
        {
            collision.transform.position = Teleport.transform.position;
            NightSky.SetActive(true);
            isEnter = false;
        }
    }
}
