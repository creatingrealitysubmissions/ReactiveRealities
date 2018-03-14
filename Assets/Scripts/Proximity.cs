using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour
{
    [SerializeField] float triggerDistance;
    [SerializeField] float revertDistance;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        ProximityObject proximityObject = other.GetComponent<ProximityObject>();
        if (proximityObject)
        {
            Vector3 position2D = Vector3.ProjectOnPlane(transform.position, Vector3.up);
            Vector3 objectPosition2D = Vector3.ProjectOnPlane(proximityObject.transform.position, Vector3.up);

            float distance = Vector3.Distance(position2D, objectPosition2D);
            Debug.Log("distance: " + distance);

            if (distance < triggerDistance)
            {
                proximityObject.ToggleProximity(true);
            }
            else if (distance > revertDistance)
            {
                proximityObject.ToggleProximity(false);
            }
        }
    }
}
