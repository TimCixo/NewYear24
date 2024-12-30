using System.Collections;
using UnityEngine;

public class StageLifecyclePresenter
{
    private StageLifecycleModel _model;
    private StageLifecycleView _view;

    public StageLifecyclePresenter(StageLifecycleModel model, StageLifecycleView view)
    {
        _model = model;
        _view = view;

        _view.OnStart += () => _view.StartCoroutine(TryStartNextStage());
        _model.EnemySpawner.OnStageEnd += () => _view.StartCoroutine(TryStartNextStage());
    }

    private IEnumerator TryStartNextStage()
    {
        if (_model.I >= _model.Stages.Count) 
        {
            yield break;
        }

        yield return new WaitForSeconds(_model.Interval);

        _model.EnemySpawner.StartStage(_model.Stages[_model.I++]);
    }
}