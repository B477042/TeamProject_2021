using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTask_ScanTarget : UBTNode
{
    private float radius=7.5f;
    public override bool ExecuteNode(EnemyController AIController)
    {
        AIController.currentNode=this;
        var blackBoard = AIController.BlackBoard;
        var currentPos=AIController.gameObject.transform.position;
        var result =Physics2D.OverlapCircleAll(currentPos,radius);
        foreach(var index in result)
        {
            //Successed for scan player
            if(index.gameObject.tag=="Player")
            {
                print("find");
                AIController.BlackBoard.TargetObject=index.gameObject;
                return false;
            }
        }

      
      return true;
    }
}
