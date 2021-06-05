using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum EPlayerState
    {
        Default=0,
        OnGround,
        InAir,
        Attack,
        Jump
         
    };
public class GamePlayerState : MonoBehaviour
{
//    public delegate void  FOnFliped(bool NewValue);
//     public FOnFliped OnFliped;
    public EPlayerState playerState = EPlayerState.OnGround;
    public bool bIsFacingR=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }


   
}
