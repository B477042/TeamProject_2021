using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyCharacter : Damageable,I_Attack
{

    Rigidbody2D rigid;
    EnemyState state;
    //=================================================    
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


    private void Awake() 
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        state = gameObject.GetComponent<EnemyState>();
    }
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

    public void ReceiveTarget(GameObject newTarget)
    {
        Target=newTarget;
        targetPos=Target.gameObject.transform.position;
    }
    public void MoveTo(Vector2 Dircetion)
    {
        state.State=EEnemyState.Walk;
        rigid.AddForce(Dircetion);
    } 

}
