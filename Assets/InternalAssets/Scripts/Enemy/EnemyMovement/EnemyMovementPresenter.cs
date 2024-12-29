using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementPresenter
{
    private EnemyMovementModel _model;
    private EnemyMovementView _view;

    public List<GameObject> Points { set {_model.Points = value;}}

    public EnemyMovementPresenter(EnemyMovementModel model, EnemyMovementView view)
    {
        _model = model;
        _view = view;

        _view.OnFixedUpdate += OnFixedUpdate;
    }

    private void OnFixedUpdate()
    {
        float distance = Vector3.Distance(_view.transform.position, _model.Point.transform.position);

        if (distance < _model.DistanceThreshold)
        {
            NextPoint();
        }

        Move();
    }

    private void Move()
    {
        _view.transform.position = Vector3.MoveTowards(_view.transform.position, _model.Point.transform.position, _model.Presenter.MovementSpeed * Time.fixedDeltaTime);
    }

    private void NextPoint()
    {
        _model.Point = _model.Points[(int)_model.I++];
    }
}