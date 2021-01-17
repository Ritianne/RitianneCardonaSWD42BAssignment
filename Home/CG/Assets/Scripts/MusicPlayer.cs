using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Runs before Start()
    void Awake()
    {
        SetUpSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUpSingleton()
    {
        // Get type of object attached to script (MusicPlayer)
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            // If there is more than one destroy last one
            Destroy(gameObject);
        }

        else
        {
            // Don't destroy when changing scenes
            DontDestroyOnLoad(gameObject);
        }
    }
}
