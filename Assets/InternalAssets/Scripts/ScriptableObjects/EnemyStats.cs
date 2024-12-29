using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Stats/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [SerializeField, Tooltip("Enemy movement speed")]
    private float _movementSpeed = 0f;
    [SerializeField, Tooltip("Base enemy hit points")] 
    private float _hitPoints = 0f;

    public float MovementSpeed => _movementSpeed;
    public float HitPoints => _hitPoints;
}