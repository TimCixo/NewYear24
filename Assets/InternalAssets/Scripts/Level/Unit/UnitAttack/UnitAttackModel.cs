using System.Collections.Generic;
using UnityEngine;

public class UnitAttackModel
{
    public float AttackDamage = 0.0f;
    public float AttackModifier = 0.0f;
    public IUnitAttack Attack;
    public UnitStats Stats;
    public List<GameObject> Enemies;
    public EnemySpawnerPresenter EnemySpawner;
}