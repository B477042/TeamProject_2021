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
    //LeftTop point the player can go to  -6.4,15
    [SerializeField] private Vector2 Pos_LeftTop;
    //RightDown point the player can go to 206,-8
    [SerializeField] private Vector2 Pos_RightDown;

    //Refer to the transform information for the object
    [SerializeField] private GameObject Obj_Player;
    [SerializeField] private Sprite BG;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        setBG();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBG();
    }

    // Get BG Texture From GameObject's Sprite Renderer Component
    void setBG()
    {
        
        //Add Sprite Renderer to GameObject
        spriteRenderer=gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = BG;
        
    }

    void UpdateBG()
    {
       Vector3 pos_Standard = Obj_Player.transform.localPosition;
       
    }


}
