using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Basic Node For My Behavior Tree
    It can't be placed but child class nodes can place at Behavior Tree
    

*/
public abstract class UBTNode : MonoBehaviour,I_TreeNode
{
    protected UBTNode parentNode=null;
    protected List<UBTNode> childNodes=new List<UBTNode>();
    protected List<UBTNode> conditionNodes=new List<UBTNode>();
    public List<UBTNode>ChildNodes()=>childNodes;

    protected bool bIsRootNode=false; 
    public bool IsRootNode()
    {
        return bIsRootNode;
    }


    //===============================
    //      Build Tree Func
    public bool AddChildNode(UBTNode newChild)
    {
        if(!newChild)return false;

        childNodes.Add(newChild);
        return true;
    }

    public bool AddParentNode(UBTNode newParent)
    {
        //parent cant change
        if(parentNode)return false;
        parentNode=newParent;
        return true;
    }
    



    //================================
    //      Abstract Func
    public abstract bool ExecuteNode(EnemyController AIController);


   
}
