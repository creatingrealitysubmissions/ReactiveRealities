using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GazeObject : MonoBehaviour
{
    [SerializeField] UnityEvent detectedEvent;
    [SerializeField] UnityEvent focusedEvent;
    [SerializeField] UnityEvent detectExitEvent;

    bool detected = false, focused = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDetect()
    {
        if (!detected)
        {
            detected = true;
            detectedEvent.Invoke();
        }
    }

    public void OnDetectExit()
    {
        if (detected)
        {
            detected = false;
            focused = false;
            detectExitEvent.Invoke();
        }
    }

    public void OnFocus()
    {
        if (detected && !focused)
        {
            focused = true;
            focusedEvent.Invoke();
        }
    }
}
