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
    [SerializeField]private float speed=100.0f;
    //Accelation Factor
    [SerializeField]private float accelFactor=1.0f;
    //Jump value factor
    [SerializeField]private float jumpFactor=70.0f;
    private float MaxHP=100.0f;
    private float hp;
    public float ATK{get;set;}
    public float HP{
             get{return hp;}
            set 
            {
                hp=value;
            
                //OnHpChanged.Invoke(hp);
                if(hp<=0)
                {
                    OnHpIsZero.Invoke();
                }
            }
           
        }


    //========================================
    //          Variable Get Func
    public float GetSpeed(){return speed;}
    public float GetAccelFactor(){return accelFactor;}
    public float GetJumpFactor(){return jumpFactor;}
    public float GetHPRatio(){return HP/MaxHP;}
    //=========================================
    //          Delegate
  
    //Called When Hp is changed
    public FOnHpChanged OnHpChanged;
    public FOnHpIsZero OnHpIsZero;
   
    private void Awake() 
    {
        ATK=10.0f;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        HP=MaxHP;    
    }
    

}
