using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public GameObject Player;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hello");
    }

}
