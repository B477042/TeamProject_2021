using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour,I_TakeDamage
{
    
    public abstract float TakeDamage(GameObject DamagedObject, GameObject DamageCausor, float Amount);
    
}
