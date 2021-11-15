using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveExit : MonoBehaviour
{
    public GameObject Teleport;
    public GameObject NightSky;
    public GameObject InteractIcon;
    public GameObject CaveIntro;
    public int SecsIntroExit;

    private bool canEnter = false;
    public BGSound BGSoundScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canEnter = true;
            InteractIcon.SetActive(true);
            CaveIntro.SetActive(true);

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
            StartCoroutine(CloseIntro());
        }
    }

    public void EnterCave(Collider2D collision, bool isEnter)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetButtonDown("Enter") && isEnter)
        {
            BGSoundScript.PlayWhatIsLoveMusic();
            collision.transform.position = Teleport.transform.position;
            NightSky.SetActive(true);
            InteractIcon.SetActive(false);
            isEnter = false;
        }
    }

    public IEnumerator CloseIntro()
    {
        yield return new WaitForSeconds(SecsIntroExit);
        CaveIntro.SetActive(false);
    }
}
