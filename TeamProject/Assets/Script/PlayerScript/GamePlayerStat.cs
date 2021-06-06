using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// It deals with the gameObjecet's numerical information.
// All of numerical information 
public class GamePlayerStat : MonoBehaviour
{
    //=========================================
    //          Stat Variables
    //Default Speed of gameObject
    [SerializeField]
    private float speed=65.0f;
    //Accelation Factor
    [SerializeField]
    private float accelFactor=1.0f;
    //Jump value factor
    [SerializeField]
    private float jumpFactor=70.0f;
    public float ATK{get;set;}
    public float HP{
            set 
            {
                HP=value;
                OnHpChanged.Invoke(HP);
            }
            get{return HP;}
        }


    //========================================
    //          Variable Get Func
    public float GetSpeed(){return speed;}
    public float GetAccelFactor(){return accelFactor;}
    public float GetJumpFactor(){return jumpFactor;}
    //=========================================
    //          Delegate
    public delegate void FOnHpChanged(float newValue);
    //Called When Hp is changed
    public FOnHpChanged OnHpChanged;

   
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

}
