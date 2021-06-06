using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage = 50;
    public ParticleSystem VFX_Hit;
    private bool bIsActivated=false;
    private Vector2 direction;
    private float speed=0.0001f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
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
            damage++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        VFX_Hit.Play();
        
        
    }
    


}
