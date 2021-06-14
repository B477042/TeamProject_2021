using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
*   This script calculates which part of the background texture 
*   you want to show based on the player's location.
*   Select background texture from texture asset.
*   Calculates the ratio between the position of the player and the two end points of the level
*   This component is attached to the camera.
*/
public class BGSprintArm : MonoBehaviour
{
    //Leftmost point the player can go to
    [SerializeField] private Vector3 Pos_Start;
    //Righttmost point the player can go to
    [SerializeField] private Vector3 Pos_End;
    //Refer to the transform information for the object
    [SerializeField] private GameObject Obj_Player;
    [SerializeField] private Sprite BG;

    // Start is called before the first frame update
    void Start()
    {
        //setBG();
         
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBG();
    }

    // Get BG Texture From GameObject's Sprite Renderer Component
    void setBG()
    {
        // var comp_sprite = gameObject.GetComponent<SpriteRenderer>();
        // if(!comp_sprite){print("There isn't any sprite renderer in gameObject");return;}
        // BG = comp_sprite.sprite;
        
    }

    void UpdateBG()
    {
       Vector3 pos_Standard = Obj_Player.transform.localPosition;
       
    }


}
