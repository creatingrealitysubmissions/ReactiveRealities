using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    [SerializeField] float lookDistance;
    [SerializeField] float detectTime;
    [SerializeField] float focusTime;
    
    float timer = 0;
    GazeObject detectedObject;

    // Use this for initialization
    void Start()
    {

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
                if (gazeObject && gazeObject != detectedObject)
                {
                    detectedObject = gazeObject;
                    Debug.Log("detect");
                    gazeObject.OnDetect();
                    if (timer > focusTime)
                    {
                        Debug.Log("focus");
                        gazeObject.OnFocus();
                    }
                }
                else
                {
                    timer = 0;
                    if (detectedObject)
                    {
                        detectedObject.OnDetectExit();
                        detectedObject = null;
                    }
                }
            }
        }
        else
        {
            timer = 0;
            if (detectedObject)
            {
                detectedObject.OnDetectExit();
                detectedObject = null;
            }
        }
    }
}
