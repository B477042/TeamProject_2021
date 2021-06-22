using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmeraFollow : MonoBehaviour
{

    public Transform m_playerTransform;

    //�趨һ����ɫ�ܿ�������Զֵ Set the maximum value a character can see.
    public float Ahead;

    //����һ�������Ҫ�ƶ����ĵ� Set a point where the camera will move.
    public Vector3 targetPos;

    //����һ�������ٶȲ�ֵ Set a slow speed interpolation.
    public float smooth;


    void Start()
    {

        //��ȡ��ǰ��ɫ��transform Transform for current role
        //m_playerTransform = GameObject.Find("player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {


        //this.transform.position = new Vector3(m_playerTransform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);



        targetPos = new Vector3(m_playerTransform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        if (m_playerTransform.position.x > 0f)
        {
            targetPos = new Vector3(m_playerTransform.position.x + Ahead, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            targetPos = new Vector3(m_playerTransform.position.x - Ahead, gameObject.transform.position.y, gameObject.transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);

    }
}