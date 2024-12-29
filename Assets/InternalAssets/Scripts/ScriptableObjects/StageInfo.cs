using UnityEngine;

[CreateAssetMenu(fileName = "StageInfo", menuName = "Stats/StageInfo")]
public class Stage : ScriptableObject
{
    [Header("Stats")]
    [SerializeField, Tooltip("Array of enemy waves")]
    private WaveInfo[] _waves;
    [SerializeField, Tooltip("Interval between enemy waves")]
    private float _interval = 0f;

    public WaveInfo[] Waves => _waves;
    public float Interval => _interval;
}