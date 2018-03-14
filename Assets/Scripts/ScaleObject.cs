using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    [SerializeField] float scaleSpeed;

    float originalScale;

    // Use this for initialization
    void Start()
    {
        originalScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Scale(float multiplier)
    {
        StopAllCoroutines();
        StartCoroutine(ProcessScale(originalScale * multiplier));
    }

    IEnumerator ProcessScale(float scale)
    {
        Vector3 scaleTarget = new Vector3(scale, scale, scale);
        while (Mathf.Abs(transform.localScale.x - scale) > 0.001f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, scaleTarget, scaleSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
