using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTask_MoveTo : UBTNode
{
    private float minDist = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    public override bool ExecuteNode(EnemyController AIController)
    {
      var blackBoard = AIController.BlackBoard;
      var targetPos = blackBoard.TargetObject.transform.position;
      var currentPos= AIController.gameObject.transform.position;
      var dircetion = targetPos-currentPos;

     if(dircetion.x<=minDist)return true;

      AIController.MoveTo(dircetion*10);

    
      return false;
    }
}
