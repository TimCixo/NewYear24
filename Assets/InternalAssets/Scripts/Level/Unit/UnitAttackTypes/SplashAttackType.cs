using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SplashAttackType : IUnitAttack
{
    public float Attack(float damage, float modifier, List<GameObject> enemies)
    {
        var colliders = Physics.OverlapSphere(enemies[0].transform.position, modifier);
        var targets = colliders
            .Select(c => c.GetComponent<EnemyLifecycleManager>())
            .Where(p => p != null);

        foreach (var enemyPresenter in targets)
        {
            enemyPresenter.Presenter.TakeDamage(damage);
        }
        
        return 1.2f;
    }
}