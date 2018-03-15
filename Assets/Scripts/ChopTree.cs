using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChopTree : MonoBehaviour
{
    [SerializeField] string nextLevel;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene();
        }
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
    
    public void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextLevel))
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (sceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                sceneIndex = 0;
            }

            SceneManager.LoadScene(sceneIndex);
        }
    }
}
