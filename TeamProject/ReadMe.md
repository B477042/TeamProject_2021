# About Code
Zheng Jun said he copied code. But I don't know about Zheng Jun's code came from. And he also doesn't know.
He copied code somewhere in the internet. 

## Coding Style
All of private variables and functions start small letter. Except properties.
All of public variables and functions start big letter.


And i'm skilled about UE4 more then Unity. So i was named after UE4 style such as U, F, A. But not all of them. 

>Example
>>Assets/Script/PlayerScript/GamePlayer.cs
```C#
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
.
.
.
}


```


---
This paragraphs written by Young Wook Choi
