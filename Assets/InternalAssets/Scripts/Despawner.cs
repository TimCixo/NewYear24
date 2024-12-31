using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyLifecycleManager enemyLifecycle = other.gameObject.GetComponent<EnemyLifecycleManager>();
        Debug.Log("Despawner: OnTriggerEnter2D");
        if (enemyLifecycle != null)
        {
            enemyLifecycle.Presenter.Die();
            Debug.Log("Despawner: Die");
        }
    }
}
