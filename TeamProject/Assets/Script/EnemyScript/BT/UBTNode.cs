using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UBTNode : MonoBehaviour,I_TreeNode
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    public int ExecuteNode()
    {
        print("Default Node Executed" );
        return 0;
    }
}
