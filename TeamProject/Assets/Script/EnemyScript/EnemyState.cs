using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEnemyState
{
    Idle=0,
    Walk,
    Attack,
    TakeDamage
}

public class EnemyState : MonoBehaviour
{
   
    public EEnemyState State=EEnemyState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
   
}
