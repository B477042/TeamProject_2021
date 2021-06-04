using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerController : MonoBehaviour
{
    //Delegate for mapping actions input functions
    public delegate void DeleActionFunc();
    //Delegate for mapping axis input functions
    public delegate float DeleAxisFunc(float value);
    //Dictionary for action inputs
    private Dictionary<KeyCode,DeleActionFunc> dic_ActionFuncs;
    //Dictionary for axis inputs
    private Dictionary<KeyCode,DeleAxisFunc>dic_AxisFuncs;
    //Point gameObject's Rigidbody2D
    private Rigidbody2D rigi_player;
 //===============================================================
 //                         Unity Funcs

    // Start is called before the first frame update
    void Start()
    {
        initInputDics();
        initComponents();
    }

    // Update is called once per frame
    void Update()
    {
      updateInput();
    }


//===============================================================
//                  Called at Start. Only Input Funcs

    private void initInputDics()
    {
        if(dic_AxisFuncs!=null||dic_ActionFuncs!=null){
            print("already init");
            return;
            }

        dic_ActionFuncs=new Dictionary<KeyCode, DeleActionFunc>();
        dic_AxisFuncs=new Dictionary<KeyCode, DeleAxisFunc>();

        //Bind Axis input
        DeleAxisFunc  moveHor = moveHorizenial;
      
        dic_AxisFuncs.Add(KeyCode.A,moveHor);
        dic_AxisFuncs.Add(KeyCode.D,moveHor);
    
        //Bind Action Input
        DeleActionFunc actJump = jump;
        dic_ActionFuncs.Add(KeyCode.Space,actJump);

       


    }
    
    private void updateInput()
    {
    //Change input process to bring key value from input options manager asap
    //We don't have much time, so i'll impliment input code by const value
    //Input.anyKeyDown
         //Action Input
        if(Input.anyKeyDown)
        {
          foreach(var tempDic in dic_ActionFuncs)
          {
        
              if(Input.GetKeyDown(tempDic.Key))
              {
                
                  tempDic.Value();
              }
          }
          
        }
        //Axis Input
        else if(Input.anyKey)
        {
            foreach(var tempDic in dic_AxisFuncs)
          {
              
              if(Input.GetKey(tempDic.Key))
              {
             
                tempDic.Value(Input.GetAxis("Horizontal"));
           
              }
          }
         
        }
        
      
    }

    private float moveHorizenial(float axis)
    {
        
        float speed_x = axis*300.0f;
        Vector2 vec_force=new Vector2(speed_x,1.0f);
        
        rigi_player.AddForce(vec_force);
       
        return axis;
    }
  
    private void jump()
    {
        Vector2 vec_force =new Vector2(0.0f,500.0f);
       rigi_player.AddForce(vec_force);

        var temp = gameObject.GetComponent<GamePlayerStat>();
        if(!temp)return;

        temp.HP=10.0f;

    }


   

//===============================================================   
//      Call at Start() or Awake()
    void initComponents()
    {
        rigi_player = gameObject.GetComponent<Rigidbody2D>();
        if(!rigi_player)
        {
            print("There isn't rigid_2d");
            return;
        }



    }

//===============================================================   
//     

  
}
