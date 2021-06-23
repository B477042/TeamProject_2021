using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   If Player Overlapped, Player will take damage enough to die
*/
public class DeadZoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag=="Player")
        {
            
            other.GetComponent<GamePlayer>().TakeDamage(other.gameObject,gameObject,5000000);
        }
        if(other.gameObject.tag=="Enemy")
        {
            other.GetComponent<EnemyCharacter>().TakeDamage(other.gameObject,gameObject,500000000);
        }
    }
     
}
