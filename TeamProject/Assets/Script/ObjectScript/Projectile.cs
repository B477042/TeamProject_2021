using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage = 50;
    public ParticleSystem VFX_Hit;
    private bool bIsActivated=false;
    private Vector2 direction;
    private float speed=0.001f;
    private Vector3 originScale;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        originScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(!bIsActivated)return;

        Vector3 newPos = direction*speed;
        transform.position+=newPos;
    }

    public void Fire(Vector2 StartPoint, Vector2 DestPoint)
    {
        bIsActivated=true;
        direction = DestPoint - StartPoint;
        if(direction.x<0)
            {
               Vector3 newScale = new Vector3(originScale.x*-1,originScale.y,originScale.z);
               gameObject.transform.localScale=newScale;
            }
        else
            gameObject.transform.localScale=originScale;

        ToggleHide(false);
    }
    public void ToggleHide(bool bResult)
    {
        if(!bResult)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
            gameObject.transform.localScale = originScale;
            damage++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        VFX_Hit.Play();
        
        
    }
    


}
