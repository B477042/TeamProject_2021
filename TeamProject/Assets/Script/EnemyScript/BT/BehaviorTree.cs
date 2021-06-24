using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree  : MonoBehaviour
{
    private EnemyController controller;
    private UBTNode rootNode;
    private bool bPower=true;
    // Start is called before the first frame update
    void Start()
    {
        controller=gameObject.GetComponent<EnemyController>();
        if(!controller)
        {
            print("Error, can't find enemy controller");
        }

        makeTree();
    }

    private void Update()
    {
        runBT();
    }
    private void runBT()
    {
        if(!bPower)return;

        rootNode.ExecuteNode(controller);



    }
    //==================================================
    //      Building Tree Functions

    //트리 구조는 project에 별도 pdf로 첨부
    private void makeTree()
    {
        rootNode = gameObject.AddComponent<URootNode>();

        var node0=gameObject.AddComponent<USelectorNode>();
        var node1=gameObject.AddComponent<UConditionNode>();
        var node2=gameObject.AddComponent<USequenceNode>();
        var node3=gameObject.AddComponent<USequenceNode>();
        var node4=gameObject.AddComponent<UTask_MoveTo>();
        var node5=gameObject.AddComponent<UTask_Attack>();
        var node6=gameObject.AddComponent<UTask_Attack>();
        var node7=gameObject.AddComponent<UTask_ScanTarget>();
        var node8=gameObject.AddComponent<UTask_MoveAround>();

        //Link child Node and parent node
        rootNode.AddChildNode(node0);

        node0.AddChildNode(node1);
        node0.AddChildNode(node2);

        node1.AddChildNode(node3);

        node2.AddChildNode(node4);
        node2.AddChildNode(node5);

        node3.AddChildNode(node7);
        node3.AddChildNode(node8);

        node1.SetCondition(controller.BlackBoard,"GameObject","GameObject",ECondition.notSet);


    }


     
    
     

}
