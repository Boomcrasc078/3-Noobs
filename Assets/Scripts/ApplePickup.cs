using UnityEngine;

public class ApplePickup : MonoBehaviour
{
    [SerializeField] private GameObject appleParticleSystemGameObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerQuest>().AddApple();
            Instantiate(appleParticleSystemGameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
