using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
/*
*   Main Game Manager
*   : singleton class
*   Main Features : 
*   1) Record the score
*   2) 
*/


public class MainGameManager : MonoBehaviour
{
    
    





    private static  MainGameManager  instance = null;
    public static  MainGameManager  Instance
    {
        get
        {
            return instance;
        }
    }

    
   
    private void Awake()
    {
        if(instance!=null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
       // Debug.LogWarning("Game manger instance Called");

        DontDestroyOnLoad(this);
    }




=======
public class MainGameManager : MonoBehaviour
{
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        
    }

<<<<<<< Updated upstream
   
=======
    // Update is called once per frame
    void Update()
    {
        
    }
>>>>>>> Stashed changes
}
