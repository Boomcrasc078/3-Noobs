using Unity.VisualScripting;
using UnityEngine;
public class FallingPlatform : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody2D;
    private Vector3 startPosition;
    bool isOn = true;

    void Awake()
    {
        startPosition = transform.position;
        isOn = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(TurnOff), 1f);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(TurnOn), 5f);
        }
    }

    void TurnOn()
    {
        isOn = true;
        animator.SetBool("Enabled", true);
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;

    }

    void Update()
    {
        if (isOn)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, Vector3.Distance(transform.position, startPosition) * 10 * Time.deltaTime);
        }
    }

    void TurnOff()
    {
        isOn = false;
        animator.SetBool("Enabled", false);
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}

