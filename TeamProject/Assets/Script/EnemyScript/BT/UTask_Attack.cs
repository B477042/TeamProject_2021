using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTask_Attack : UBTNode
{
     

   public override bool ExecuteNode(EnemyController AIController)
   {
       AIController.Attack();
       
    AIController.currentNode=this;
       return true;

   }
}
