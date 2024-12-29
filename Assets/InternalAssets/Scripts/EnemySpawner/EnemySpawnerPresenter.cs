using System.Collections;
using UnityEngine;

public class EnemySpawnerPresenter
{
    private EnemySpawnerModel _model;
    private EnemySpawnerView _view;

    public EnemySpawnerPresenter(EnemySpawnerModel model, EnemySpawnerView view)
    {
        _model = model;
        _view = view;
    }

    public void Start()
    {
        _view.StartCoroutine(StageSpawn());
    }

    private IEnumerator StageSpawn()
    {
        for (int i = 0; i < _model.StageInfo.Waves.Length; i++)
        {
            GameObject enemy = _model.StageInfo.Waves[i].Enemy;
            // TODO: Add enemy spawnRate (_model.StageInfo.Interval * enemy.spawnRateCoefitient)

            for (int j = 0; j < _model.StageInfo.Waves[i].Count; j++)
            {
                SpawnEnemy(enemy);

                yield return new WaitForSeconds(_model.StageInfo.Interval); // TODO: Update to spawnRate
            }
        }

        yield return null;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject spawnedEnemy = Object.Instantiate(enemy);

        // TODO: spawnedEnemy(_model.Path)

        _model.EnemyCount++;
    }

    private void EnemyDied()
    {
        _model.EnemyCount--;
    }
}