using UnityEngine;

[CreateAssetMenu(fileName = "WaveInfo", menuName = "Stats/WaveInfo")]
public class WaveInfo : ScriptableObject
{
    [Header("Stats")]
    [SerializeField, Tooltip("Enemy prefab to spawn")]
    private GameObject _enemy;
    [SerializeField, Tooltip("Enemy count to spawn in this wave")]
    private uint _count = 0;

    public GameObject Enemy => _enemy;
    public float Count => _count;
}