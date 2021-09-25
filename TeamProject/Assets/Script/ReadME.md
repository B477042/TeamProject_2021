# About Files
As i said in front of this project's ReadMe, Zheng Jun was not good at programming because he's goal is to be artist. So file structre was being mess.
But i think it can be good example of co-op mistakes. So, i don't wanna fix this mess.

## About codes that located this folder
And I don't know about in this folder. 
Some codes was written by me. But i wasn't let my codes in default script folder. 
I think when we merged this project, this project occured.


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


## Files location

- Player script in [PlayerScript](https://github.com/B477042/TeamProject_2021/tree/main/TeamProject/Assets/Script/PlayerScript)
- Enemy script in [EnemyScript](https://github.com/B477042/TeamProject_2021/tree/main/TeamProject/Assets/Script/EnemyScript)
 - Behavior Tree in [BT](https://github.com/B477042/TeamProject_2021/tree/main/TeamProject/Assets/Script/EnemyScript/BT)
- Interface i used in [Interface](https://github.com/B477042/TeamProject_2021/tree/main/TeamProject/Assets/Script/Interface)
- Objects script in [ObjectScript](https://github.com/B477042/TeamProject_2021/tree/main/TeamProject/Assets/Script/ObjectScript)
- Manager type script in [ManagerScript](https://github.com/B477042/TeamProject_2021/tree/main/TeamProject/Assets/Script/ManagerScript)
- All delegate is collected in [Delegate](https://github.com/B477042/TeamProject_2021/tree/main/TeamProject/Assets/Script/Delegate)



---
This ReadMe written by Young Wook Choi
