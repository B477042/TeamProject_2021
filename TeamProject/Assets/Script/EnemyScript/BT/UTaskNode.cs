using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTaskNode : UBTNode
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override bool ExecuteNode(EnemyController AIController)
    {
      
      print("TaskNode");
      return true;
    }
}
