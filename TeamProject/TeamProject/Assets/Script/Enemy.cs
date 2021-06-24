using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float CDTime;
    private Animator EnemyAni;
    public int hp=2;

    private void Awake()
    {
        EnemyAni = this.GetComponent<Animator>();
    }
    private bool bDead;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="a1")
        {
            hp -= 1;
        
            if (hp <= 0)
            {
                if (!bDead)
                {
                    bDead = true;
                    Player.Score += 1;
                    EnemyAni.SetTrigger("Dead");
                    Destroy(this.gameObject, 0.5f);
                }
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            if(CDTime<2)
            {
                CDTime += Time.deltaTime;
            }
            else
            {
                collision.gameObject.GetComponent<Player>().CurHP -= 1;
                if(collision.gameObject.GetComponent<Player>().CurHP<0 && collision.gameObject != null)
                {
                    Destroy(collision.gameObject);
                }
                EnemyAni.SetTrigger("Attack");
                CDTime = 0;
            }
    
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (CDTime < 2)
            {
                CDTime += Time.deltaTime;
            }
            else
            {
                collision.gameObject.GetComponent<Player>().CurHP -= 1;
                if (collision.gameObject.GetComponent<Player>().CurHP < 0 && collision.gameObject != null)
                {
                    Destroy(collision.gameObject);
                }
                EnemyAni.SetTrigger("Attack");
                CDTime = 0;
            }
        }
    }
}
