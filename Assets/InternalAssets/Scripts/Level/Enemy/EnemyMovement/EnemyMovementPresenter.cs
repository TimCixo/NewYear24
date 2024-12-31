using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMovementPresenter
{
    private EnemyMovementModel _model;
    private EnemyMovementView _view;

    public float DistanceToEnd => _model.DistanceToEnd;
    public PathPresenter Path { set { _model.Path = value; } }

    public EnemyMovementPresenter(EnemyMovementModel model, EnemyMovementView view)
    {
        _model = model;
        _view = view;
    }

    public void Start()
    {
        _model.Point = _model.Path.Points[0].transform;

        _view.OnFixedUpdate += OnFixedUpdate;
    }

    private void OnFixedUpdate()
    {
        float distance = Vector3.Distance(_view.transform.position, _model.Point.transform.position);

        if (distance < _model.DistanceThreshold)
        {
            NextPoint();
        }

        Rotate();
        Move();
        UpdateDistanceToEnd();
    }

    private void Rotate()
    {
        _model.EnemySpritePrefab.transform.up = _model.Point.transform.position - _view.transform.position;
    }

    private void Move()
    {
        float movementSpeed = _model.Lifecycle.MovementSpeed * Time.fixedDeltaTime / 2f;

        _view.transform.position = Vector3.MoveTowards(_view.transform.position, _model.Point.transform.position, movementSpeed);
    }

    private void NextPoint()
    {
        if (_model.I < _model.Path.Points.Count)
        {
            _model.Point = _model.Path.Points[_model.I++].transform;

        }
        else
        {
            _model.Point = _model.Path.EndPoint;
        }
    }

    private void UpdateDistanceToEnd()
    {
        float distanceToEnd = Vector3.Distance(_view.transform.position, _model.Path.EndPoint.position);

        if (_model.Path.Points.Count <= _model.I)
        {
            _model.DistanceToEnd = distanceToEnd;
            return;
        }

        // 1. Шлях від об'єкту до _model.Point
        float distanceToCurrentPoint = Vector3.Distance(_view.transform.position, _model.Path.Points[_model.I].transform.position);

        // 2. Сума усіх точок починаючи з _model.Path.Point[i] і закінчуючи _model.Path.Point.Last()
        float distanceBetweenPoints = 0f;
        for (int i = _model.I; i < _model.Path.Points.Count - 1; i++)
        {
            distanceBetweenPoints += Vector3.Distance(_model.Path.Points[i].transform.position, _model.Path.Points[i + 1].transform.position);
        }

        // 3. Шлях від _model.Path.Last() до _model.Path.EndPoint
        float distanceFromLastPointToEnd = Vector3.Distance(_model.Path.Points[_model.Path.Points.Count - 1].transform.position, _model.Path.EndPoint.position);

        // 4. Сума 1 2 і 3
        _model.DistanceToEnd = distanceToCurrentPoint + distanceBetweenPoints + distanceFromLastPointToEnd;
    }
}