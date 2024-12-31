using System;
using System.Collections;
using System.Linq;
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

        _model.MaxEnemiesCount = (int)_model.StageInfo.Waves.Sum(wave => wave.Count);
        _view.StartCoroutine(SpawnStage());
    }

    private IEnumerator SpawnStage()
    {
        for (int i = 0; i < _model.StageInfo.Waves.Count; i++)
        {
            GameObject enemy = _model.StageInfo.Waves[i].Enemy;
            float spawnRate = _model.StageInfo.Interval * enemy.GetComponent<EnemyLifecycleManager>().Stats.SpawnRateCoefficient;

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
        GameObject spawnedEnemy = UnityEngine.Object.Instantiate(enemy, _view.transform.position, Quaternion.identity);

        spawnedEnemy.GetComponent<EnemyMovementManager>().Presenter.Path = _model.Path;
        spawnedEnemy.GetComponent<EnemyLifecycleManager>().Presenter.OnDeath += EnemyDied;

        spawnedEnemy.GetComponent<EnemyMovementManager>().Presenter.Start();

        _view.SetEnemiesCount(++_model.EnemiesCount, _model.MaxEnemiesCount);
    }

    private void EnemyDied()
    {
        _view.SetEnemiesCount(--_model.EnemiesCount, _model.MaxEnemiesCount);
    }
}