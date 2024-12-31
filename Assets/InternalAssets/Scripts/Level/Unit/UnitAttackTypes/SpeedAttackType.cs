using System.Collections.Generic;
using UnityEngine;

public class SpeedAttackType : IUnitAttack
{
    public float Attack(float damage, float modifier, List<GameObject> enemies)
    {
        enemies[0].GetComponent<EnemyLifecyclePresenter>().TakeDamage(damage);
        
        return 1 / modifier;
    }
}