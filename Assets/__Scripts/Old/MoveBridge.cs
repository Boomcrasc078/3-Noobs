using UnityEngine;
using UnityEngine.UI;

public class MoveBridge : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Move");
            button.SetActive(false);
        }
    }
}
