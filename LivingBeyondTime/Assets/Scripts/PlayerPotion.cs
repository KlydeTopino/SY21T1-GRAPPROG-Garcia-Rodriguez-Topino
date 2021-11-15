using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPotion : MonoBehaviour
{
    public Player PlayerScript;
    public SpikeTileset SpikeTilesetScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Potion") || Input.GetKeyDown(KeyCode.E)) && (PlayerScript.Potion >= 1 && SpikeTilesetScript.TotalHearts <= 2))
        {
            for (int i = 0; i < SpikeTilesetScript.Hearts.Length; i++)
            {
                if (!SpikeTilesetScript.HeartHeal[i].activeInHierarchy)
                {
                    SpikeTilesetScript.HeartHeal[i].SetActive(true);
                    SpikeTilesetScript.TotalHearts++;
                    PlayerScript.Potion--;
                    //SoundManager.PlaySound("Hurt");
                    //Debug.Log("Use Potion");
                    break;
                }
            }
        }
    }
}
