using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    
    [SerializeField] int breakableBloks; 

     SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBloks++;

    }

    public void BlockDestroyed()
    {
        breakableBloks--;
        if (breakableBloks <=0)
        {
            sceneloader.LoadNextScene();
        }

    }



}
