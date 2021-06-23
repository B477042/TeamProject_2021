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
        Dead
         
    };

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
    // Start is called before the first frame update
    void Start()
    {
        var stat = gameObject.GetComponent<GamePlayerStat>();
        if(!stat)return;

        stat.OnHpIsZero+=onHpIsZero;
    }

    private void onHpIsZero()
    {
            print("hp is zero");
    }

   
}
