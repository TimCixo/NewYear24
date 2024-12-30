using System.Collections.Generic;

public class StageLifecycleModel
{
    public uint I = 0;
    public float Interval = 0.0f;
    public List<StageInfo> Stages = new List<StageInfo>();
    public EnemySpawnerPresenter EnemySpawner;
}