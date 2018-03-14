using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProximityObject : MonoBehaviour
{
    [SerializeField] float triggeredScale;

    [SerializeField] UnityEvent triggeredEvent;
    [SerializeField] UnityEvent revertedEvent;

    float originalScale;
    bool inProximity = false;

    // Use this for initialization
    void Start()
    {
        originalScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnProximityEnter()
    {
        Debug.Log("entered proximity");
        transform.localScale = new Vector3(triggeredScale, triggeredScale, triggeredScale);
        triggeredEvent.Invoke();
    }

    void OnProximityExit()
    {
        Debug.Log("exit proximity");
        transform.localScale = new Vector3(originalScale, originalScale, originalScale);
        revertedEvent.Invoke();
    }

    void OnProximityStay()
    {
        Debug.Log("in proximity");
    }

    public void ToggleProximity(bool toggle)
    {
        if (inProximity)
        {
            if (toggle)
                OnProximityStay();
            else
                OnProximityExit();
        }
        else
        {
            if (toggle)
                OnProximityEnter();
        }
        inProximity = toggle;
    }
}
