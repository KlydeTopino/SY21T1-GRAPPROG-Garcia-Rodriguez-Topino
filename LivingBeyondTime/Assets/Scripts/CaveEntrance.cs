using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveEntrance : MonoBehaviour
{
    public GameObject Teleport;
    public GameObject NightSky;
    public GameObject InteractIcon;

    private bool canEnter = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canEnter = true;
            InteractIcon.SetActive(true);
            EnterCave(collision, canEnter);
        }    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canEnter = true;
            EnterCave(collision, canEnter);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InteractIcon.SetActive(false);
        }
    }

    public void EnterCave(Collider2D collision, bool isEnter)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetButtonDown("Enter") && isEnter)
        {
            collision.transform.position = Teleport.transform.position;
            NightSky.SetActive(false);
            InteractIcon.SetActive(false);
            isEnter = false;
        }
    }
}
