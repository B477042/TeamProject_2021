using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct FBlackBoard
{
    private const string  GAMEOBJECT="GameObject";


    private GameObject targetObject;

    public GameObject TargetObject
    {
        get
        {
            return targetObject;
        }
        set
        {
            targetObject=value;
            //DataDic[GAMEOBJECT]=targetObject;
        }
    }

    public Dictionary<string,Object> DataDic;

    public void init()
    {
        DataDic=new Dictionary<string, Object>();
        targetObject=null;

    }
}

/*
* A Controller Component. Order to enemy character script or move gaemObject(Owner)
* Include AI FSM or Behavior Tree.
* 
*/
public class EnemyController : MonoBehaviour
{
    private EnemyCharacter character;
    
    [SerializeField]private BehaviorTree behaviorTree;
    //======================================
    //      Used As BalckBoard For BT
    //      Variables
    public FBlackBoard BlackBoard;
    
    private void Awake()
    {
        BlackBoard.init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        behaviorTree = gameObject.GetComponent< BehaviorTree>();
        if(!behaviorTree)
        {
            print("Error, can't find BT");
            
        }
        character= gameObject.GetComponent<EnemyCharacter>();
        if(!character)
        {
            print(gameObject.name+"doesn't has EnemyCharacter.cs");
            Destroy(gameObject);
        }

    }
    public void MoveTo(Vector2 Direction)
    {
        character.MoveTo(Direction);
    }
    public void Attack()
    {
        character.Attack();
    }



}
