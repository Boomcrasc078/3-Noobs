using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}