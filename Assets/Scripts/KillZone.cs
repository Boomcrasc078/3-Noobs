using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = spawnPosition.position;
            collision.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }
    }
}
