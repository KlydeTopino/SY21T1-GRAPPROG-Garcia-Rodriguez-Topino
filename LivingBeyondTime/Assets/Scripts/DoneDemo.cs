using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoneDemo : MonoBehaviour
{
    public bool isDemoDone;
    [Header("Effects")]
    public ParticleSystem DemoDoneEffect;

    [Header("Global Light Configurations")]
    public GameObject DemoFolder;
    public GameObject GlobalLightsVolume;
    public GameObject InGameUI;

    [Header("Demo Done Message")]
    public TextMeshProUGUI Message1;
    public TextMeshProUGUI Message2;

    [Header("Skull Light Configurations")]
    public float AddAlpha;
    public DayNightCycle DayNightCycleScript;

    [Header("Player Configurations")]
    public Player PlayerScript;
    public PlayerCombat PlayerCombatScript;
    public GameObject Teleport;


    // Start is called before the first frame update
    void Start()
    {
        isDemoDone = false;
        DemoFolder.SetActive(false);

        Message1.GetComponent<TextMeshPro>();
        Message2.GetComponent<TextMeshPro>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDemoDone = true;
            DemoFolder.SetActive(true);
            
            DemoDoneEffect.Play();

            for (int i = 0; i <= 255; i++)
            {
                Message1.color += new Color(0, 0, 0, AddAlpha);
                Message2.color += new Color(0, 0, 0, AddAlpha);
            }
            
            if (isDemoDone) // if lights havent been turned on
            {
                for (int i = 0; i < DayNightCycleScript.lights.Length; i++)
                {
                    DayNightCycleScript.lights[i].SetActive(true); // turn them all on
                }
            }
            collision.transform.position = Teleport.transform.position;

            GlobalLightsVolume.SetActive(false);
            InGameUI.SetActive(false);
            PlayerScript.enabled = false;
            PlayerCombatScript.enabled = false;
        }
    }
}
