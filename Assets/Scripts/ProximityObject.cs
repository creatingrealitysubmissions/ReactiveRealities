using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityObject : MonoBehaviour
{
    bool inProximity = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnProximityEnter()
    {
        Debug.Log("entered proximity");
        transform.localScale = new Vector3(transform.localScale.x * 0.5f, transform.localScale.x * 0.5f, transform.localScale.x * 0.5f);
    }

    void OnProximityExit()
    {
        Debug.Log("exit proximity");
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
