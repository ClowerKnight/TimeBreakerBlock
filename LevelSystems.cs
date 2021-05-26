using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void level_ac(string level_name)
    {
        Application.LoadLevel(level_name);
    }
     


    
}
