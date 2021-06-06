using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanTriggerScript : MonoBehaviour
{
      //List of Enemy Objects to Spawn
    public List<GameObject> EnemyPrefabs=new List<GameObject>();
    private BoxCollider2D trigger=null;
    public bool  bIsActivated=false;
    //object number. Set Value in Editor
    public uint SpawnPattern=0;
   
  
    // Start is called before the first frame update
    void Start()
    {
        trigger = gameObject.GetComponent<BoxCollider2D>();
        if(!trigger)
            print("Box Trigger is null");
       
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(bIsActivated)return;
       
        if(other.gameObject.tag !="Player")
            {return;}
        
        bIsActivated=true;

        print("on trigger entered  " + EnemyPrefabs.Count+" : Size" );
        EnemySpawnManager.Instance.SpawnEnemy(other.gameObject.transform, SpawnPattern, EnemyPrefabs);
    
    }   
   
}
