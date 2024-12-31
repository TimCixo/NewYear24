using TMPro;
using UnityEngine;

public class EnemySpawnerView : MonoBehaviour
{
    [SerializeField, Tooltip("Text component to display current enemies count")]
    private TextMeshProUGUI _enemiesCount;

    public void SetEnemiesCount(int enemiesCount, int maxEnemimesCount)
    {
        _enemiesCount.text = $"{enemiesCount.ToString("000")}/{maxEnemimesCount.ToString("000")}";
    }
}