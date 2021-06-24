using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URootNode : UBTNode
{
    public override bool ExecuteNode(EnemyController AIController)
    {
        foreach(var node in childNodes)
        {
            node.ExecuteNode(AIController);
        }
    
      return true;
    }
}
