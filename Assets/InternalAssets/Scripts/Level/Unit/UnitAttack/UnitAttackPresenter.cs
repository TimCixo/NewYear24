using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitAttackPresenter
{
    private UnitAttackModel _model;
    private UnitAttackView _view;

    public float AttackDamage
    {
        get => _model.AttackDamage;
        set => _model.AttackDamage = value;
    }
    
    public float AttackModifier
    {
        get => _model.AttackModifier;
        set => _model.AttackModifier = value;
    }

    public UnitAttackPresenter(UnitAttackModel model, UnitAttackView view)
    {
        _model = model;
        _view = view;

        _view.OnFixedUpdate += OnFixedUpdate;
    }

    public void OnFixedUpdate()
    {
        if (_model.EnemySpawner.Enemies.Count <= 0)
        {
            return;
        }

        _model.Enemies = _model.EnemySpawner.Enemies.OrderBy(e => e.GetComponent<EnemyMovementManager>().Presenter.DistanceToEnd).ToList();
        _view.StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        float delay = 1 * _model.Attack.Attack(_model.AttackDamage, _model.AttackModifier, _model.Enemies);

        yield return new WaitForSeconds(delay);
    }
}