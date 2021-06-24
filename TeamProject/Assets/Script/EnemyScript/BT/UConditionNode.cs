using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECondition
{
    Null=0,
    set, 
    notSet

}


public class UConditionNode : UBTNode
{
    private ECondition condition=ECondition.Null;
    private string dataType;
    //Condition vaiable name
    private string conditionName;
    // Start is called before the first frame update
    
    public void SetCondition(FBlackBoard BlackBoard, string DataType, string ConditionName, ECondition newCondition)
    {
        switch(DataType)
        {
            

            case "GameObject":
            condition=newCondition;
            dataType=DataType;
            conditionName=ConditionName;

            break;
             
        }
    }
    public override bool ExecuteNode(EnemyController AIController)
    {
        bool bResult=false;
        var blackBoard = AIController.BlackBoard;


        //var dicValue = blackBoard.DataDic[conditionName];
        // //If BlackBoard dont has key value return false
        // if(!blackBoard.DataDic.ContainsKey(conditionName))
        // {
        //     print("condition error");
        //     return bResult;
        // }

        // //Check Condition
        // switch(condition)
        // {
        //     //If Dic Value is null return false
        //     case ECondition.set:
           
        //     if(dicValue==null)
        //     {
        //         return bResult;
        //     }

        //     break;
        //     //If Dic Value is not null return false
        //     case ECondition.notSet:

            
        //     if(dicValue!=null)
        //     {
        //         return bResult;
        //     }

        //     break;
        // }
        
        if(blackBoard.TargetObject==null)
        {
            //Execute child nodes
            foreach(var node in childNodes)
            {
                
                AIController.currentNode=node;
                bResult = node.ExecuteNode(AIController);
                if(!bResult)
                  return false;
            }
        }
        
        if(blackBoard.TargetObject!=null)
        return false;


        return true;
    }
}
