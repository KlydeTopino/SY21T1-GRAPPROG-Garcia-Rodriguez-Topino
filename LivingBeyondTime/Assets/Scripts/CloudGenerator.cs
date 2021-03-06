using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] clouds;
    
    public float spawnInterval;

    [SerializeField]
    GameObject endPoint;

    Vector3 startPos;

    public int StartingClouds;

    public void Start()
    {
        startPos = transform.position;
        Prewarm();
        Invoke("AttemptSpawn", spawnInterval);
    }

    void SpawnCloud(Vector3 startPos)
    {
        int randomIndex = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex]);

        float startY = UnityEngine.Random.Range(startPos.y - 1f, startPos.y + 1f);
        cloud.transform.position = new Vector3(startPos.x, startY, startPos.z);

        float scale = UnityEngine.Random.Range(0.8f, 1.2f);
        cloud.transform.localScale = new Vector2(scale, scale);

        float speed = UnityEngine.Random.Range(0.5f, 1.5f);
        cloud.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.x);
    }

    void AttemptSpawn()
    {
        SpawnCloud(startPos);
        Invoke("AttemptSpawn", spawnInterval);
    }

    void Prewarm()
    {
        for (int i = 0; i < StartingClouds; i++)
        {
            Vector3 spawnPos = startPos + Vector3.left * (i * 2);
            SpawnCloud(spawnPos);
        }
    }
}
