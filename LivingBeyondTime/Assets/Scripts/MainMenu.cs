using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    
    public bool IsStarting = false;

    public void StartGame()
    {
        //SpriteRenderer Sprite = Player.GetComponent<SpriteRenderer>();
        //Sprite.flipX = false;
        IsStarting = true;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
