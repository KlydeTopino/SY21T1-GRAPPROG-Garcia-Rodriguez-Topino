using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public MainMenu MainMenuScript;
    public Transform PlayerTransform;
    
    public GameObject Camera;
    private Vector3 _cameraOffset;

    public bool startFollow;
    public bool offsetChecker;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.05f;

    void Start()
    {
        startFollow = false;
        offsetChecker = false;
    }

    void LateUpdate()
    {
        if (startFollow)
        {
            Vector3 newPos = PlayerTransform.position + _cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        }
    }

    void Update()
    {
        if (MainMenuScript.IsStarting)
        {
            Vector3 position = new Vector3(13, 0, -13);
            Camera.transform.position = Vector3.Lerp(Camera.transform.position, position, Time.deltaTime);
            if (!offsetChecker)
            {
                StartCoroutine(getCamOffset());
                offsetChecker = true;
            }
        }
    }

    IEnumerator getCamOffset()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Got the Offset sir!");
        _cameraOffset = transform.position - PlayerTransform.position;
        startFollow = true;
    }

}
