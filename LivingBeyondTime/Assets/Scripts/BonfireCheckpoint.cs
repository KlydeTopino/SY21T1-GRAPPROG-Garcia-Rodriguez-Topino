using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireCheckpoint : MonoBehaviour
{
    public GameObject TeleportRestart;
    public GameObject BonfireRestart;
    public GameObject InteractIcon;
    public bool canSetCheckpoint = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canSetCheckpoint = true;
            InteractIcon.SetActive(true);
            SetNewCheckpoint(collision, canSetCheckpoint);
        }  
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canSetCheckpoint = true;
            SetNewCheckpoint(collision, canSetCheckpoint);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InteractIcon.SetActive(false);
        }
    }

    public void SetNewCheckpoint(Collider2D collision, bool setCheckpoint)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetButtonDown("Enter") && setCheckpoint)
        {
            TeleportRestart.transform.position = BonfireRestart.transform.position;
            InteractIcon.SetActive(false);
            setCheckpoint = false;
        }
    }
}
