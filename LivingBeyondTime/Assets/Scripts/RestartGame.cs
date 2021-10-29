using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public GameObject Teleport;
    public GameObject Player;

    public void Restart()
    {
        Player.transform.position = Teleport.transform.position;
    }
}
