using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField]
    private MonoBehaviour[] _components;

    private void Awake()
    {
        BootstrapInit();
    }

    private void BootstrapInit()
    {
        foreach (MonoBehaviour component in _components)
        {
            if (component is IBootstrapable bootstrapable)
            {
                bootstrapable.BootstrapInit();
            }
        }
    }
}