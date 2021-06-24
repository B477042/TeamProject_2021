using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USelectorNode : UBTNode
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    public override bool ExecuteNode(EnemyController AIController)
    {
        bool bResult = false;

        foreach(var node in childNodes)
        {
            bResult=node.ExecuteNode(AIController);
            if(bResult)return true;
        }
        return false;
    }
}
