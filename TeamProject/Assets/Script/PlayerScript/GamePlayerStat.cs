using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// It deals with the player's numerical information.
// All of numerical information 
public class GamePlayerStat : MonoBehaviour
{
    public delegate void FOnHpChanged(float newValue);
//Called When Hp is changed
    public FOnHpChanged OnHpChanged;

    public float HP{
        get
        { 
           
            return HP;
        }
        set
        {
            OnHpChanged.Invoke(HP);
        }
    }
    public float ATK{get;set;}

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

}
