using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    [Header("Configs")]
    public Player PlayerScript;

    [Header("Active")]
    public GameObject[] Activate;

    [Header("Deactive")]
    public GameObject[] Deactivate;

    // Update is called once per frame
    void Update()
    {
        if(PlayerScript.Keys == 2)
        {
            foreach (GameObject item in Activate)
            {
                item.gameObject.SetActive(true);
            }

            foreach (GameObject item in Deactivate)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}
