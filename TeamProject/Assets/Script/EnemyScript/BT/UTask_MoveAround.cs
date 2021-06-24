using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTask_MoveAround : UBTNode
{
    private float offsetA=1f;
    private float offsetB=-1f;
    private float offsetX=1f;
    private float offsetY=-1f;

    public override bool ExecuteNode(EnemyController AIController)
    {
      float x = Random.Range(offsetA,offsetB);
      float y = Random.Range(offsetX,offsetY);
      AIController.currentNode=this;
      Vector2 newDest = new Vector2(x,y);

      AIController.MoveTo(newDest);
      return true;
    }
}
