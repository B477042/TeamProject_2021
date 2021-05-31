using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanTriggerScript : MonoBehaviour
{
    private BoxCollider2D trigger=null;
    public bool  bIsActivated=false;
    //object number. Set Value in Editor
    public uint ObjectNum=0;
   
    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.GetComponent<BoxCollider2D>();
        if(!trigger)
            print("Box Trigger is null");
       

        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
         print("hello");
        if(bIsActivated)return;
       
    
        if(other.gameObject.tag !="Player")
            {print("Not Player");return;}
        
        bIsActivated=false;

        print("on trigger entered");
        EnemySpawnManager.Instance.SpawnEnemy(other.gameObject.transform, ObjectNum);
    


    }   
   
}
