using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mag : MonoBehaviour
{
    //Capacity of this mag
    [SerializeField] private ushort Capacity=6;
    
 
    [SerializeField] private GameObject obj_Bullet;

    private List<GameObject> list_Bullets=new List<GameObject>();
    private ushort idx_current=0;
    
    private float delay= 0.3f;
    //

    // Start is called before the first frame update
    void Start()
    {
        if(obj_Bullet)
            for(int i=0; i<Capacity;++i)
                list_Bullets.Add(Instantiate<GameObject>(obj_Bullet));
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //after report. calculate angle shoot
    /*
    *   Params
    *   StartPoint : GameObject position
    *   DestPoint : Mouse-click coordinates
    */
    public bool Fire(Vector2 StartPoint, Vector2 DestPoint)
    {
        bool bResult=true;
        var bullet = list_Bullets[idx_current];

        bullet.transform.position = StartPoint;
        var proj = bullet.GetComponent<Projectile>();
        var forwardVector = gameObject.transform.position+gameObject.transform.forward;
        var bIsFacingR = gameObject.GetComponent<GamePlayerState>().bIsFacingR;

        bResult =proj.Fire(StartPoint,DestPoint,bIsFacingR,gameObject.tag );

        ++idx_current;
        if(idx_current>=Capacity)
            idx_current=0;

        delay++;

        return bResult;
    }

    
}
