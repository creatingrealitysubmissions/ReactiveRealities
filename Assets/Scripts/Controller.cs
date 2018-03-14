using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.WSA.Input;

public class Controller : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InteractionSourceState[] interactionSourceStates = InteractionManager.GetCurrentReading();

        bool leftPressed = interactionSourceStates.Length > 0 && interactionSourceStates[0].selectPressed;//Input.GetAxis("10") == 1);
        bool rightPressed = interactionSourceStates.Length > 1 && interactionSourceStates[1].selectPressed;// Input.GetAxis("9") == 1);

        if (leftPressed && rightPressed)
        {
            Debug.Log("Both triggers pressed");
            Vector3 rightHandPosition = InputTracking.GetLocalPosition(XRNode.RightHand);
            Vector3 leftHandPosition = InputTracking.GetLocalPosition(XRNode.LeftHand);
        }
        else
        {
            if (leftPressed)
            {
                Debug.Log("Right trigger pressed");
                Vector3 rightHandPosition = InputTracking.GetLocalPosition(XRNode.RightHand);
                Debug.DrawLine(rightHandPosition, rightHandPosition * 2);
            }
            if (rightPressed)
            {
                Debug.Log("Left trigger pressed");
                Vector3 leftHandPosition = InputTracking.GetLocalPosition(XRNode.LeftHand);
                Debug.DrawLine(leftHandPosition, leftHandPosition * 2);
            }
        }
    }
}
