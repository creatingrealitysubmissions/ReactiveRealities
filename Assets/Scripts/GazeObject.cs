using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GazeObject : MonoBehaviour
{
    [SerializeField] float scaleSpeed;
    [SerializeField] float detectedScale;
    [SerializeField] float focusedScale;

    [SerializeField] UnityEvent detectedEvent;
    [SerializeField] UnityEvent focusedEvent;
    
    float originalScale, scale;
    bool detected = false, focused = false;

    // Use this for initialization
    void Start()
    {
        originalScale = transform.localScale.x;
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
            StopAllCoroutines();
            StartCoroutine(Scale(originalScale * detectedScale));
        }
        detectedEvent.Invoke();
    }

    public void OnDetectExit()
    {
        if (detected)
        {
            detected = false;
            StopAllCoroutines();
            StartCoroutine(Scale(originalScale));
        }
    }

    public void OnFocus()
    {
        if (detected && !focused)
        {
            focused = true;
            StopAllCoroutines();
            StartCoroutine(Scale(originalScale * focusedScale));
        }
    }

    IEnumerator Scale(float scale)
    {
        Vector3 scaleTarget = new Vector3(scale, scale, scale);
        while (Mathf.Abs(transform.localScale.x - scale) > 0.001f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, scaleTarget, scaleSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
