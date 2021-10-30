using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveEntrance : MonoBehaviour
{
    public GameObject Teleport;
    public GameObject NightSky;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnterCave(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        EnterCave(collision);
    }

    public void EnterCave(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && (Input.GetButtonDown("Enter") || Input.GetButton("Enter")))
        {
            collision.transform.position = Teleport.transform.position;
            NightSky.SetActive(false);
            Debug.Log("ENTER");
        }
    }
}
