using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*   Main Player's Script
*   A class that handles the behavior of the player.
*   It is also a class that interacts with the animator. And Collision.
*   The difference with the player controller is:
*   The controller commands the operation and the player(this script) processes it.
*   Stat and State components is controlled by this for only
*/
public class GamePlayer : MonoBehaviour
{
    //Point gameObject's Animator
    private Animator animator;
    //Point gameObject's Rigidbody2D
    private Rigidbody2D rigid;
    //Point gameObject's Game Player Stat
    private GamePlayerStat stat;
    //Point gameObject's Game Player State
    private GamePlayerState state;
    private BoxCollider2D collision;

    // Start is called before the first frame update
    void Start()
    {
        animator=gameObject.GetComponent<Animator>();
        if(!animator){print("there isn't Animator");return;}

        rigid = gameObject.GetComponent<Rigidbody2D>();
        if(!rigid){print("There isn't rigid_2d");return;}

        stat = gameObject.GetComponent<GamePlayerStat>();
        if(!stat){print("There isn't Game Player Stat");return;}

        state = gameObject.GetComponent<GamePlayerState>();
        if(!state){print("Thee isn't Game Player State");return;}

        collision = gameObject.GetComponent<BoxCollider2D>();
        if(!collision){print("There isn't BoxCollider2D");return;}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //===============================================
    //      Colllision Functions
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Landscape")
        {
            print("landscape!");
            setAnimState(EPlayerState.OnGround);
        }


    }
    //===============================================
    //      Animator Funtions
    private void setAnimState(EPlayerState NewState) 
    {
        state.playerState = NewState;
        animator.SetInteger("State",(int)state.playerState);
        print("state changed");
    }
    

    
    //===============================================
    //      public functions

    public float MoveHorizenial(float Axis)
    {
        Vector2 newForce = new Vector2 (stat.GetSpeed()*stat.GetAccelFactor()*Axis,0.0f);
        rigid.AddForce(newForce);
        if(Axis<0)
        {
            if(state.bIsFacingR)
            {
                state.bIsFacingR=false;
                gameObject.transform.localScale=new Vector3(-1.0f,1.0f,1.0f);
            }
        }
        else
        {
            if(!state.bIsFacingR)
            {
                state.bIsFacingR=true;
                gameObject.transform.localScale=new Vector3(1.0f,1.0f,1.0f);
            }
           
        }

        return 0.0f;
    }
    public void Jump()
    {
        Vector2 newForce =new Vector2(0.0f,stat.GetJumpFactor());
        rigid.AddForce(newForce);
        setAnimState(EPlayerState.InAir);
    }

    public void Attack()
    {
        print("attack");
        //state.playerState = EPlayerState.Attack;
        
    }

}
