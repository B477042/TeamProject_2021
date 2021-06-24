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
public class GamePlayer : Damageable, I_Attack
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
    //Bullet Manager Component
    private Mag mag;
    private Vector3 prevPoint;
[SerializeField]private GameObject FirePoint;
[SerializeField]private AudioSource GunShot;

    public FOnLanding OnLanding;
    private void Awake()
    {
             MainGameManager.Instance.Player = gameObject; 
             GunShot=gameObject.GetComponent<AudioSource>();
    }

    //==================================================
    // Start is called before the first frame update
    void Start()
    {
        initializeComponents();
        // if(!MainGameManager.Instance.Player)
        //     MainGameManager.Instance.Player = gameObject;
        prevPoint=gameObject.transform.position;

        //Regist Delegates
        stat.OnHpIsZero+=onHpIsZero;
        state.OnDoubleJump+=onDoubleJump;

    }


    
    void FixedUpdate()
    {
        checkVelocity();
    }
    
    //===============================================
    //      Colllision Functions
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Landscape")
        {
            setAnimState(EPlayerState.OnGround);
            OnLanding.Invoke();
        }


    }

    private void OnCollisionExit2D(Collision2D other) {
           if(other.gameObject.tag=="Landscape")
        {
            setAnimState(EPlayerState.InAir);
            
        }
    }

    //===============================================
    //      Animator Funtions
    private void setAnimState(EPlayerState NewState) 
    {
        state.playerState = NewState;
        animator.SetInteger("State",(int)state.playerState);
      
    }
    private float checkVelocity()
    {
      
        //If Player's state is InAir return
        if(state.playerState==EPlayerState.InAir||state.playerState==EPlayerState.Dead ||state.playerState==EPlayerState.DoubleJump)return 0;

        var displacement=gameObject.transform.position-prevPoint;
        prevPoint=gameObject.transform.position;
        float result =  Vector3.Magnitude( displacement);
        //print("check velocity"+result);

        if(result!=0.0f)
        {
            setAnimState(EPlayerState.Walk);
        }
        else
         {
            setAnimState(EPlayerState.OnGround);
         }

       
        return result;
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
        if(state.IsCanJump())
        {
            Vector2 newForce =new Vector2(0.0f,stat.GetJumpFactor());
            rigid.AddForce(newForce);
            setAnimState(EPlayerState.InAir);
            state.bIsInAir=true;
        }
    }
    //Attack 
    public void Attack()
    {
        var DestPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 StartPoint = FirePoint.transform.position;
        
        if(mag.Fire(StartPoint,DestPos))
            GunShot.Play();
    }
    //Take Damage form I_TakeDamage
    public override float TakeDamage(GameObject DamagedObject, GameObject DamageCausor, float Amount)
    {
        print("Player Take Damage : "+Amount);
        stat.HP-=Amount;
        return Amount;
    }    


    //========================================================================
    //  private funcs
    //Initialize Components Value
    void initializeComponents()
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
        mag = gameObject.GetComponent<Mag>();
        if(!mag){print("There isn't mag");return;}
    }
    //Freeze Rigid body 
    void onHpIsZero()
    {
        rigid.constraints= RigidbodyConstraints2D.FreezeAll;
    }
    void onDoubleJump()
    {
         print("Double Jump");
        setAnimState(EPlayerState.DoubleJump);
    }


}
