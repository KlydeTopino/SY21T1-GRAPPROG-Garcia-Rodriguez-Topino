using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    SpriteRenderer SpriteRender;
    BoxCollider2D BoxCollider2d;

    public int TimeToDisappear;
    // Update is called once per frame
    void Start()
    {
        SpriteRender = GetComponent<SpriteRenderer>();
        BoxCollider2d = GetComponent<BoxCollider2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Disappear(TimeToDisappear));
            Debug.Log("Starting");
            
        }
    }

    IEnumerator Disappear(int secs)
    {
        yield return new WaitForSeconds(secs);

        SpriteRender.enabled = false;
        BoxCollider2d.enabled = false;
        StartCoroutine(Appear(secs + 1));
    }

    IEnumerator Appear(int secs)
    {
        yield return new WaitForSeconds(secs);

        SpriteRender.enabled = true;
        BoxCollider2d.enabled = true;
    }
}
