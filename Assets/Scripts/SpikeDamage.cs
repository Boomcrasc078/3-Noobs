using Unity.Tutorials.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] private int damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
   
}
