using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



/*
* A Controller Component. Order to enemy character script or move gaemObject(Owner)
* Include AI FSM or Behavior Tree.
* 
*/
public class EnemyController : MonoBehaviour
{
    private EnemyCharacter owingCharacter;
    public GameObject TargetObject{get;set;}
    public StateMachineBehaviour FSM;

    // Start is called before the first frame update
    void Start()
    {
      owingCharacter= gameObject.GetComponent<EnemyCharacter>();
        if(!owingCharacter)
        {
            print(gameObject.name+"doesn't has EnemyCharacter.cs");
            Destroy(gameObject);
        }

    }




}
