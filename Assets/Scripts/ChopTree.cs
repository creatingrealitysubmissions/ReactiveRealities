using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTree : MonoBehaviour
{
    [SerializeField] GameObject[] trees;

    int currentTreeIndex;

    // Use this for initialization
    void Start()
    {
        currentTreeIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentTreeIndex < trees.Length)
        {
            trees[currentTreeIndex].SetActive(false);
            currentTreeIndex++;
            if (currentTreeIndex < trees.Length)
                trees[currentTreeIndex].SetActive(true);
        }
    }
}
