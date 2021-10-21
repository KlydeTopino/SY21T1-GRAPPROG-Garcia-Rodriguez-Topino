using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public CinemachineBrain CineMachineCam;
    public MainMenu MainMenuScript;

    void Start()
    {
        CineMachineCam = GetComponent<CinemachineBrain>();
    }

    void Update()
    {
        if (MainMenuScript.IsStarting)
        {
            CineMachineCam.enabled = true;
        }
    }
}
