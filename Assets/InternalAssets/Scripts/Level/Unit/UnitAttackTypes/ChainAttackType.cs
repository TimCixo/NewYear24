using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChainAttackType : IUnitAttack
{
    public float Attack(float damage, float modifier, List<GameObject> enemies)
    {
        int targetIndex = (int)modifier;
        var targets = enemies
            .Where((e, index) => index <= targetIndex * 2 && e != null)
            .Select(c => c.GetComponent<EnemyLifecycleManager>())
            .ToList();

        foreach (var target in targets)
        {
            target.Presenter.TakeDamage(damage);
        }

        return 1;
    }
}