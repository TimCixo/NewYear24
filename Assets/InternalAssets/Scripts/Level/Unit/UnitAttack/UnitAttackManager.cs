using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(UnitAttackView), typeof(Bootstrap))]
public class UnitAttackManager : MonoBehaviour, IBootstrapable
{
    [SerializeField, Tooltip("Enemy Spawner Manager")]
    private EnemySpawnerManager _enemySpawnerManager;
    [SerializeField, Tooltip("Unit attack info")]
    private UnitStats _unitStats;

    private UnitAttackModel _model;
    private UnitAttackView _view;
    private UnitAttackPresenter _presenter;

    public UnitAttackPresenter Presenter => _presenter;

    public void BootstrapInit()
    {
        _model = new UnitAttackModel();

        ModelInit();

        _view = GetComponent<UnitAttackView>();
        _presenter = new UnitAttackPresenter(_model, _view);
    }

    private void ModelInit()
    {
        _model.EnemySpawner = _enemySpawnerManager.Presenter;
        _model.Stats = _unitStats;
        _model.AttackDamage = _unitStats.AttackDamage;
        _model.AttackModifier = _unitStats.AttackModifier;
        _model.Attack = GetAttackType(_unitStats.UnitAttackType);
    }

    private IUnitAttack GetAttackType(UnitAttackType attackType) => attackType switch
    {
        UnitAttackType.Speed => new SpeedAttackType(),
        UnitAttackType.Splash => new SplashAttackType(),
        UnitAttackType.Chain => new ChainAttackType(),
        _ => null
    };
}