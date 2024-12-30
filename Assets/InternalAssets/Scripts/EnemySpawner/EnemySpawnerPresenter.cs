using System;
using System.Collections;
using UnityEngine;

public class EnemySpawnerPresenter
{
    private EnemySpawnerModel _model;
    private EnemySpawnerView _view;

    public event Action OnStageEnd;

    public EnemySpawnerPresenter(EnemySpawnerModel model, EnemySpawnerView view)
    {
        _model = model;
        _view = view;
    }

    public void StartStage(StageInfo stageInfo)
    {
        _model.StageInfo = stageInfo;

        _view.StartCoroutine(SpawnStage());
    }

    private IEnumerator SpawnStage()
    {
        for (int i = 0; i < _model.StageInfo.Waves.Count; i++)
        {
            GameObject enemy = _model.StageInfo.Waves[i].Enemy;
            float spawnRate = _model.StageInfo.Interval * enemy.GetComponent<EnemyLifecyclePresenter>().SpawnRateCoefficient; // ! Init problem probably

            for (int j = 0; j < _model.StageInfo.Waves[i].Count; j++)
            {
                SpawnEnemy(enemy);

                yield return new WaitForSeconds(spawnRate);
            }
        }

        OnStageEnd?.Invoke();
    }

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject spawnedEnemy = UnityEngine.Object.Instantiate(enemy);

        spawnedEnemy.GetComponent<EnemyMovementPresenter>().Points = _model.Path.Points.ConvertAll(point => point.transform);
        spawnedEnemy.GetComponent<EnemyMovementPresenter>().EndPoint = _model.Path.EndPoint;
        spawnedEnemy.GetComponent<EnemyLifecyclePresenter>().OnDeath += EnemyDied;

        _model.EnemyCount++;
    }

    private void EnemyDied()
    {
        _model.EnemyCount--;
    }
}