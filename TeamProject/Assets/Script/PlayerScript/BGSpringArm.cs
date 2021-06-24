using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
*   This script calculates which part of the background texture 
*   you want to show based on the player's location.
*   Select background texture from texture asset.
*   Calculates the ratio between the position of the player and the two end points of the level
*   This component is attached to BG Texture.
*/
public class BGSpringArm : MonoBehaviour
{
    //LeftTop point the player can go to  -6.4,15
    private Vector2 Pos_LeftTop ;
    //RightDown point the player can go to 206,-8
    private Vector2 Pos_RightDown;
    private Vector2 Pos_BG_LeftTop ;
    private Vector2 Pos_BG_RightDown ;

    //Refer to the transform information for the object
    private GameObject Obj_Player;
    //[SerializeField] private Sprite BG;
    [SerializeField]private Camera Camera;
    private SpriteRenderer spriteRenderer;
private void Awake() {
    Pos_LeftTop=new Vector2(-6.4f,15);
    Pos_RightDown=new Vector2(206,-8);
    Pos_BG_LeftTop=new Vector2(29.5f,2.5f);
    Pos_BG_RightDown=new Vector2(190.6f,2.5f);

}
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer=gameObject.GetComponent<SpriteRenderer>();
       
        Obj_Player=MainGameManager.Instance.Player;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBG();
    }


    
    void UpdateBG()
    {
       Vector2 pos_Standard = (Vector2)Obj_Player.transform.localPosition;
       Vector2 pos_New = (Vector2)gameObject.transform.position;
       float len_width = Pos_RightDown.x- Pos_LeftTop.x;

       float  ratio= pos_Standard.x/len_width;
       float resultX = Mathf.Lerp(Pos_BG_LeftTop.x,Pos_BG_RightDown.x,ratio);
       float resultY = Mathf.Lerp(Pos_BG_LeftTop.y,Pos_BG_RightDown.y,ratio);
       gameObject.transform.position =new Vector3(resultX,resultY,100);
        
    }


}
