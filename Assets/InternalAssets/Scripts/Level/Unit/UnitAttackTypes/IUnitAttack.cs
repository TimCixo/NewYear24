using System.Collections.Generic;
using UnityEngine;

public interface IUnitAttack
{
    public float Attack(float damage, float modifier, List<GameObject> enemies);
}