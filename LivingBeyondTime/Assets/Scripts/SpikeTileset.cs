using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTileset : MonoBehaviour
{
    public GameObject[] Hearts;
    public int TotalHearts;
    void Start()
    {
        TotalHearts = Hearts.Length;
    }

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < Hearts.Length; i++)
            {
                if(Hearts[i].activeInHierarchy)
                {
                    Hearts[i].SetActive(false);
                    TotalHearts--;
                    HealthChecker(TotalHearts);
                    break;
                }
            }
        }
    }
    public void HealthChecker(int TotalHearts)
    {
        if(TotalHearts == 0)
        {
            Debug.Log("Player is dead");
        }
    }
}
