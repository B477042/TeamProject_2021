using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   It's a class that's in charge of manipulating the player.

*/


public class GamePlayerController : MonoBehaviour
{
    //Delegate for mapping actions input functions
    public delegate void DeleActionFunc();
    //Delegate for mapping axis input functions
    public delegate float DeleAxisFunc(float Value);
    //Dictionary for action inputs
    private Dictionary<KeyCode,DeleActionFunc> dic_ActionFuncs;
    //Dictionary for axis inputs
    private Dictionary<KeyCode,DeleAxisFunc>dic_AxisFuncs;
   
    //Point gameObject's player script
    private GamePlayer player;

 //===============================================================
 //                         Unity Funcs

    // Start is called before the first frame update
    void Start()
    {
        //Initialize input dictionary
        initInputDics();
        //Initialize component pointer
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
        dic_AxisFuncs.Add(KeyCode.A,moveHorizenial);
        dic_AxisFuncs.Add(KeyCode.D,moveHorizenial);
      
    
        //Bind Action Input
        dic_ActionFuncs.Add(KeyCode.Space,jump);
        dic_ActionFuncs.Add(KeyCode.Mouse0,attack);
       


    }
    
    private void updateInput()
    {
    //Change input process to bring key value from input options manager asap
    //We don't have much time, so i'll impliment input code by const value
    
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

        
       foreach(var tempDic in dic_AxisFuncs)
        {
            
            if(Input.GetKeyUp(tempDic.Key))
                {
                   // print( tempDic.Key+ "is up");
                }
        }
        
        

        
    }

    private float moveHorizenial(float Axis)
    {
        return   player.MoveHorizenial(Axis);
    }
  
    private void jump()
    {
        player.Jump();
    }
    private void attack()
    {
        player.Attack();
    }

   

//===============================================================   
//      Call at Start() or Awake()
    void initComponents()
    {
        player = gameObject.GetComponent<GamePlayer>();
        if(!player)
        {
            print("There isn't game player script");
            return;
        }
    }

//===============================================================   
//     

  
}
