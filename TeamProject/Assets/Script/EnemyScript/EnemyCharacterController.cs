using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyCharacterController : MonoBehaviour
{
    private EnemyCharacter owingCharacter;
    // Start is called before the first frame update
    void Start()
    {
      owingCharacter= gameObject.GetComponent<EnemyCharacter>();
        if(!owingCharacter)
        {
            print(gameObject.name+"doesn't has EnemyCharacter.cs");
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
