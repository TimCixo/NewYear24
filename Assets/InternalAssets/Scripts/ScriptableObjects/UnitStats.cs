using UnityEngine;

[CreateAssetMenu(fileName = "UnitStats", menuName = "Stats/UnitStats")]
public class UnitStats : ScriptableObject
{
    [Header("Unit Stats")]
    [SerializeField, Tooltip("Unit attack type")]
    private UnitAttackType _unitAttackType;
    [SerializeField, Tooltip("Unit attack damage")]
    private float _attackDamage = 0f;
    [SerializeField, Tooltip("Unit attack modifier: speed, radius, length etc.")] 
    private float _attackModifier = 0f;
    [Header("Unit upgrade coefficients")]
    [SerializeField, Tooltip("Attack damage enhancement multiplier")]
    private float _attackDamageCoefficient = 0f;
    [SerializeField, Tooltip("Attack modifier enhancement multiplier")] 
    private float _attackModifierCoefficient = 0f;

    public UnitAttackType UnitAttackType => _unitAttackType;
    public float AttackDamage => _attackDamage;
    public float AttackModifier => _attackModifier;
    public float AttackDamageCoefficient => _attackDamageCoefficient;
    public float AttackModifierCoefficient => _attackModifierCoefficient;
}
