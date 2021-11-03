using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; // using text mesh for the clock display

using UnityEngine.Rendering; // used to access the volume component

public class DayNightCycle : MonoBehaviour
{
    [Header("Basic Components")]
    //public TextMeshProUGUI timeDisplay; // Display Time
    //public TextMeshProUGUI dayDisplay; // Display Day
    public Volume ppv; // this is the post processing volume

    [Header("Time-related Components")]
    public float tick; // Increasing the tick, increases second rate
    public float seconds;
    public int mins;
    public int hours;
    public int days = 1;

    [Header("Night-related Components")]
    public GameObject NightSky;
    public CloudGenerator CloudGeneratorScript;
    [HideInInspector] public bool isChecked = false;
    [HideInInspector] public bool activateLights; // checks if lights are on
    [HideInInspector] public bool CloudSpawner;

    public GameObject[] lights; // all the lights we want on when its dark
    public GameObject[] Clouds; // all the clouds we want for day

    // Start is called before the first frame update
    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();

        Clouds = GameObject.FindGameObjectsWithTag("Clouds");
    }

    // Update is called once per frame
    void FixedUpdate() // we used fixed update, since update is frame dependant. 
    {
        CalcTime();
        DisplayTime();
        CloudControl();
    }

    void Update()
    {
        Clouds = GameObject.FindGameObjectsWithTag("Clouds");
    }

    public void CalcTime() // Used to calculate sec, min and hours
    {
        seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (seconds >= 60) // 60 sec = 1 min
        {
            seconds = 0;
            mins += 1;
        }

        if (mins >= 60) //60 min = 1 hr
        {
            mins = 0;
            hours += 1;
        }

        if (hours >= 24) //24 hr = 1 day
        {
            hours = 0;
            days += 1;
        }
        ControlPPV(); // changes post processing volume after calculation
    }

    public void ControlPPV() // used to adjust the post processing slider.
    {
        //NIGHT TIME
        if (hours >= 21 && hours < 22) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            ppv.weight = (float)mins / 60; // since dusk is 1 hr, we just divide the mins by 60 which will slowly increase from 0 - 1 
            CloudSpawner = false;

            for (int i = 0; i < 255; i++)
            {
                NightSky.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, (float) mins / 60); // change the alpha value of the stars so they become visible
            }

            foreach (var cloud in Clouds)
            {
                Destroy(cloud);
                //cloud.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -(float)mins / 60); // change the alpha value of the clouds so they become invisible
            }

            if (activateLights == false) // if lights havent been turned on
            {
                if (mins > 45) // wait until pretty dark
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true); // turn them all on
                    }
                    activateLights = true;
                }
            }
        }

        //DAY TIME
        if (hours >= 6 && hours < 7) // Dawn at 6:00 / 6am    -   until 7:00 / 7am
        {
            ppv.weight = 1 - (float)mins / 60; // we minus 1 because we want it to go from 1 - 0
            CloudSpawner = true;

            for (int i = 0; i < 255; i++)
            {
                NightSky.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -(float)mins / 60); // change the alpha value of the stars so they become invisible
            }

            foreach (var cloud in Clouds)
            {
                if (cloud != null)
                {
                    cloud.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, (float)mins / 60); // change the alpha value of the clouds so they become visible
                }         
            }

            if (activateLights == true) // if lights are on
            {
                if (mins > 45) // wait until pretty bright
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false); // shut them off
                    }
                    activateLights = false;
                }
            }
        }
    }

    public void DisplayTime() // Shows time and day in ui
    {
        //timeDisplay.text = string.Format("{0:00}:{1:00}", hours, mins); // The formatting ensures that there will always be 0's in empty spaces
        //dayDisplay.text = "Day: " + days; // display day counter
    }

    public void CloudControl()
    {
        //NIGHT TIME
        if (hours >= 21 && hours < 22) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            CloudGeneratorScript.CancelInvoke("AttemptSpawn");
            isChecked = true;
        }

        //DAY TIME
        if (hours >= 6 && hours < 7 && isChecked) // Dawn at 6:00 / 6am    -   until 7:00 / 7am
        {
            CloudGeneratorScript.Start();
            isChecked = false;
        }
    }
}