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
        IsStarting = true;
        SoundManager.PlaySound("Click");
    }

    public void QuitGame()
    {
        SoundManager.PlaySound("Click");
        Debug.Log("QUIT");
        Application.Quit();
    }
}
