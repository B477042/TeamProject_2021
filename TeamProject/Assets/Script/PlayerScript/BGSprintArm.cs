using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSprintArm : MonoBehaviour
{
    public Vector3 pos_Start;
    public Vector3 pos_End;
    private Sprite BG;
    // Start is called before the first frame update
    void Start()
    {
        setBG();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

// Get BG Texture From GameObject's Sprite Renderer Component
    void setBG()
    {
        var comp_sprite = gameObject.GetComponent<SpriteRenderer>();
        if(!comp_sprite){print("There isn't any sprite renderer in gameObject");return;}
        BG = comp_sprite.sprite;
        
    }

    void UpdateBG()
    {
        
    }


}
