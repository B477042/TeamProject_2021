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





    }
    //==================================================
    //      Building Tree Functions

    private void makeTree()
    {
        
    }


    //Attach Child node to Parent node
    //If Success, return true
    private bool addNode(UBTNode Parent, UBTNode Child)
    {
        Child.AddParentNode(Parent);
        Parent.AddChildNode(Child);

        return true;
    }
    
     

}
