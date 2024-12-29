using UnityEngine;

public class EnemyLifecirclePresenter
{
    private EnemyLifecircleModel _model;
    private EnemyLifecircleView _view;

    public float MovementSpeed => _model.Stats.MovementSpeed;
    public float HitPoints => _model.HitPoints;
    public float SpawnRateCoefficient => _model.Stats.SpawnRateCoefficient;

    public System.Action OnDeath;

    public EnemyLifecirclePresenter(EnemyLifecircleModel model, EnemyLifecircleView view)
    {
        _model = model;
        _view = view;
    }

    public void TakeDamage(float damage)
    {
        _model.HitPoints -= damage;

        if (_model.HitPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnDeath?.Invoke();

        Object.Destroy(_view.gameObject);
    }
}