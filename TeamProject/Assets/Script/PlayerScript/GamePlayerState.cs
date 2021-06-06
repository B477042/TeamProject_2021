using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum EPlayerState
    {
        Default=0,
        OnGround=1,
        InAir=2,
        Attack=3,
        Walk=4
         
    };
public class GamePlayerState : MonoBehaviour
{
//    public delegate void  FOnFliped(bool NewValue);
//     public FOnFliped OnFliped;
    public EPlayerState playerState = EPlayerState.OnGround;
    public bool bIsFacingR=true;
    public bool bIsADS=false;
    public bool bIsDamaged=false;
    public bool bIsDead=false;
    public bool bIsInAir=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }


   
}
