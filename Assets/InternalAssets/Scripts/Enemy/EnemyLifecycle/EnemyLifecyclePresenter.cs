using UnityEngine;

public class EnemyLifecyclePresenter
{
    private EnemyLifecycleModel _model;
    private EnemyLifecycleView _view;

    public float MovementSpeed => _model.Stats.MovementSpeed;
    public float HitPoints => _model.HitPoints;
    public float SpawnRateCoefficient => _model.Stats.SpawnRateCoefficient;

    public System.Action OnDeath;

    public EnemyLifecyclePresenter(EnemyLifecycleModel model, EnemyLifecycleView view)
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