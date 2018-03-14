using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gaze : MonoBehaviour
{
    [SerializeField] float lookDistance;
    [SerializeField] float detectTime;
    [SerializeField] float focusTime;

    Camera camera;
    float timer = 0;

    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawLine(transform.position, transform.forward * lookDistance);
        if (Physics.Raycast(transform.position, transform.forward, out hit, lookDistance))
        {
            Debug.Log("hit");
            timer += Time.deltaTime;
            if (timer > detectTime)
            {
                GazeObject gazeObject = hit.collider.GetComponent<GazeObject>();
                if (gazeObject)
                {
                    Debug.Log("detect");
                    gazeObject.OnDetect();
                    if (timer > focusTime)
                    {
                        Debug.Log("focus");
                        gazeObject.OnFocus();
                    }
                }
            }
        }
        else
        {
            timer = 0;
        }
    }
}
