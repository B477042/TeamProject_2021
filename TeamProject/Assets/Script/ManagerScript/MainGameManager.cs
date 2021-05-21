using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
*   Main Game Manager
*   : singleton class
*   Main Features : 
*   1) Record the score
*   2) 
*/


public class MainGameManager : MonoBehaviour
{
    
    private static MainGameManager instance = null;
    public static MainGameManager Instance
    {
        get
        {
            return instance;
        }
    }



    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        // Debug.LogWarning("Game manger instance Called");

        DontDestroyOnLoad(this);
    }


}

