using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum EPlayerState
    {
        Default=0,
        OnGround=1,
        InAir=2,
        Attack=3,
        Walk=4,
        Dead=5,
        DoubleJump=6
         
    };

public enum EPlayerJumpState
{
    OnGround=0,
    Jump,
    DoubleJump
}
    /*
    *   This script desgined for represent player's state.
    *   This script's variable will be used for Animator.
    *   Such as OnAir, Walk, etc... 
    */
public class GamePlayerState : MonoBehaviour
{

    public EPlayerState playerState = EPlayerState.OnGround;
    public bool bIsFacingR=true;
    public bool bIsADS=false;
    public bool bIsDamaged=false;
    public bool bIsDead=false;
    public bool bIsInAir=false;
    private EPlayerJumpState jumpState=EPlayerJumpState.OnGround;
    public FOnDoubleJump OnDoubleJump;
    
    // Start is called before the first frame update
    void Start()
    {
        var stat = gameObject.GetComponent<GamePlayerStat>();
        if(!stat)return;

        stat.OnHpIsZero+=onHpIsZero;
        var player = gameObject.GetComponent<GamePlayer>();
        if(!player)return;
        player.OnLanding+=resetJumpState;
    }

    private void onHpIsZero()
    {
        print("hp is zero");
        
    }
    //Called when Player land at landscape
    private void resetJumpState()
    {
        jumpState=EPlayerJumpState.OnGround;
    }
    //Return true if can jump. and Change State. 
    //Because if player can jump on the game, that means player' state is changed
    public bool IsCanJump()
    {
    
        switch(jumpState)
        {
            case EPlayerJumpState.OnGround:
            jumpState++;
            return true;
             

            case EPlayerJumpState.Jump:
            jumpState++;
            OnDoubleJump.Invoke();
           
            return true;
             

            case EPlayerJumpState.DoubleJump:
            return false;
             
        }

        return false;
    }
   
}
