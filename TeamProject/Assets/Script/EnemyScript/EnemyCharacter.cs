using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyCharacter : MonoBehaviour,I_TakeDamage,I_Attack
{
    //Receive value from controller
    private Vector3 targetPos;
    public GameObject Target;

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
    public float TakeDamage(GameObject DamagedObject, GameObject DamageCausor, float Amount)
    {
        print("Enemy Take Damage : "+Amount);
        return Amount;
    }



}
