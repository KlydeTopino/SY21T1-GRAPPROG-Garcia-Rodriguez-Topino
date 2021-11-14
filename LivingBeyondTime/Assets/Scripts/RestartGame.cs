using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public GameObject Teleport;
    public GameObject Player;
    public GameObject Heart1, Heart2, Heart3;
    public SpikeTileset Tileset;

    Player playerScript;
    
    PlayerFSM playerFSMScript;

    private void Start()
    {
        playerScript = Player.gameObject.GetComponent<Player>();
        playerFSMScript = Player.gameObject.GetComponent<PlayerFSM>();
    }

    public void Restart()
    {
        Player.transform.position = Teleport.transform.position;
        
        playerScript.enabled = true;
        
        playerFSMScript.enabled = true; 
        playerFSMScript.hasDied = false;
        playerFSMScript.playerAnimator.SetTrigger("SpearAttack");
    }

    public void RestartHearts()
    {
        SoundManager.PlaySound("Respawn");
        Tileset.TotalHearts = Tileset.Hearts.Length;
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        Heart3.SetActive(true);
    }
}
