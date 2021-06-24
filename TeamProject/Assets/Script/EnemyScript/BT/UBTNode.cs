using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Basic Node For My Behavior Tree
    It can't be placed but child class nodes can place at Behavior Tree
    

*/
public abstract class UBTNode : MonoBehaviour,I_TreeNode
{
    private UBTNode parentNode=null;
    private List<UBTNode> childNodes=new List<UBTNode>();
    private bool bIsRootNode=false; 
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
    public abstract int ExecuteNode();


   
}
