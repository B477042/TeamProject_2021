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
            var player = other.GetComponent<GamePlayer>();
            if(!player)return;
            player.TakeDamage(other.gameObject,gameObject,5000000);
        }
        if(other.gameObject.tag=="Enemy")
        {
            var enemy = other.GetComponent<EnemyCharacter>();
            if(!enemy)return;
            enemy.TakeDamage(other.gameObject,gameObject,500000000);
        }
    }
     
}
