using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    public GameObject Player;
    Player PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerScript = GetComponentInParent<Player>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Player.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("STAYING!");
            Player.transform.parent = null;
        }
    }
}
