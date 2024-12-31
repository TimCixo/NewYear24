using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerModel
{
    public int MaxEnemiesCount = 0;
    public List<GameObject> Enemies = new List<GameObject>();
    public StageInfo StageInfo;
    public PathPresenter Path;
}