using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage = 50;
    public ParticleSystem VFX_Hit;
    private bool bIsActivated=false;
    private Vector2 direction;
    private float speed=0.01f;
    private Vector3 originScale;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        originScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(!bIsActivated)return;

        Vector3 newPos = direction*speed;
        transform.position+=newPos;
    }

/*  
    @Params
    @StartPoint : Invoked component's GameObject position
    @DestPoint : The point where mouse clicked
*/
    public void Fire(Vector2 StartPoint, Vector2 DestPoint)
    {
        //Local variable. If true, gameObject is facing left
        bool bIsFacingLeft=true;
        //Calaculate Direction
        direction = DestPoint - StartPoint;
        
        //If Direction is negative number, Turn 180 degrees( scale*-1.0f ).
        //The gameobject is facing right side
        if(direction.x<0)
            {
               Vector3 newScale = new Vector3(originScale.x*-1,originScale.y,originScale.z);
               gameObject.transform.localScale=newScale;
               bIsFacingLeft=false;
            }
        else
            gameObject.transform.localScale=originScale;

        //Calaculate Angle between ForwardPoint and DestPoint
        //If Calaculate Angle is over +-90 Degrees. Don't fire
        // Vector2 vecA = DestPoint-StartPoint;
        // Vector2 vecB = ForwardPoint - StartPoint;
        // float dotProduct = Vector2.Dot(vecA,vecB);
        // float Angle = Mathf.Acos(dotProduct);
        // print("Angle is "+Angle);

        //Set This Object is Activated
        bIsActivated=true;
      
        //Show Game Object in Viewport
        ToggleHide(false);
    }
    public void ToggleHide(bool bResult)
    {
        if(!bResult)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            gameObject.transform.localScale = originScale;
            damage++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        VFX_Hit.Play();
        
        
    }
    


}
