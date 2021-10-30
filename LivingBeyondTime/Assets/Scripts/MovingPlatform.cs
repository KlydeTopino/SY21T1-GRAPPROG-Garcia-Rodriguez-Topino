using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform Pos1, Pos2;
    public float PlatformSpeed;
    public Transform StartPos;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = StartPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            if (transform.position == Pos1.position)
            {
                nextPos = Pos2.position;
            }
            if (transform.position == Pos2.position)
            {
                nextPos = Pos1.position;
            }
            // execute block of code here
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, PlatformSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Pos1.position, Pos2.position);
    }
}
