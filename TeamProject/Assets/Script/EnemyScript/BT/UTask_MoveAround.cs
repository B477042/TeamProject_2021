using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTask_MoveAround : UBTNode
{
    

    public override bool ExecuteNode(EnemyController AIController)
    {
      float x = Random.Range(-1,1);
      float y = Random.Range(-1,1);
      
      return true;
    }
}
