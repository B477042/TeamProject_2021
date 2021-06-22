using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attack order Interface
public interface I_Attack {
    public void Attack();
}
//Damage Process Interface
public interface I_TakeDamage
{
    /*
    *   @Parmas
    *   @Damaged Object : GameObject that taken damage from other
    *   @Damage Causor : GameObject that invoke this function
    *   @Amount : number of damage
    */
    public float TakeDamage(GameObject DamagedObject, GameObject DamageCausor, float Amount);
}



