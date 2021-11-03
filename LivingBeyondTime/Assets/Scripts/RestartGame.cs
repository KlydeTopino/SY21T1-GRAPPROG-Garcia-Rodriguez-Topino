using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public GameObject Teleport;
    public GameObject Player;
    public GameObject Heart1, Heart2, Heart3;
    public SpikeTileset Tileset;

    public void Restart()
    {
        Player.transform.position = Teleport.transform.position;
    }

    public void RestartHearts()
    {
        Tileset.TotalHearts = Tileset.Hearts.Length;
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        Heart3.SetActive(true);
    }
}
