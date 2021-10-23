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
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
