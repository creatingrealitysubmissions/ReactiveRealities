using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GazeObject : MonoBehaviour
{
    [SerializeField] float scaleSpeed;
    [SerializeField] float detectedScale;

    [SerializeField] UnityEvent detectedEvent;
    [SerializeField] UnityEvent focusedEvent;

    bool detected = false;
    float originalScale;

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
        StopAllCoroutines();
        StartCoroutine(Scale(detectedScale));
        detectedEvent.Invoke();
    }

    public void OnFocus()
    {
        StopAllCoroutines();
        StartCoroutine(Scale(2 * detectedScale));
        focusedEvent.Invoke();
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
