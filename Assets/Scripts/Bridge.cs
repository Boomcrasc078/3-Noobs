using UnityEngine;
using UnityEngine.UI;

public class Bridge : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenBridge()
    {
        animator.SetBool("Open", true);
    }

    public void CloseBridge()
    {
        animator.SetBool("Open", false);
    }
}
