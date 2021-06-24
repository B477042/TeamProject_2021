using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyCharacter : Damageable,I_Attack
{
    //Receive value from controller
    private Vector3 targetPos;
    public GameObject Target;
    //=================================================
    //Stat Variables
    private float hp=150;
    public float HP
    {
        get{return hp;}
        
    }
    [SerializeField]private float score=100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        
    }
    public override float TakeDamage(GameObject DamagedObject, GameObject DamageCausor, float Amount)
    {
        
        hp-=Amount;
        //If This Character dead
        if(hp<0)
        {
            //If This Character is killed by Player. Add Score 
            if(DamageCausor.tag=="Player")
            {
                MainGameManager.Instance.AddScore(score);
                Destroy(gameObject);
            }
        }

        return Amount;
    }



}
