using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USequenceNode : UBTNode
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
   
    public override bool ExecuteNode(EnemyController AIController)
    {

        bool bResult = true;

        foreach(var node in childNodes)
        {
            
            AIController.currentNode=node;
            bResult = node.ExecuteNode(AIController);
            if(!bResult)
                return false;
        }

        return true;
    }
}
