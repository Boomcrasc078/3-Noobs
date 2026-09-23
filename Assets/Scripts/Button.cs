using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;
    [SerializeField] private bool allowPlayersOnButton;
    [SerializeField] private bool allowBoxesOnButton;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && allowPlayersOnButton || collision.gameObject.CompareTag("Box") && allowBoxesOnButton)
        {
            onActivate.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && allowPlayersOnButton || collision.gameObject.CompareTag("Box") && allowBoxesOnButton)
        {
            onDeactivate.Invoke();
        }
    }
}
