using UnityEngine;
using UnityEngine.UI;

public class EnemyLifecycleView : MonoBehaviour
{
    [SerializeField, Tooltip("Health bar UI element")]
    private Image _healthBar;

    private void Awake()
    {
        _healthBar.enabled = false;
    }

    public void SetHealth(float health, float maxHealth)
    {
        if (!_healthBar.enabled)
        {
            _healthBar.enabled = true;
        }

        if (health <= 0)
        {
            _healthBar.fillAmount = 0;
        }
        else
        {
            _healthBar.fillAmount = health / maxHealth;
        }
    }
}