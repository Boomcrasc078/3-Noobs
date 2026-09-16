using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int startingHealth = 5;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image image;
    [SerializeField] private Color normalHealthColor;
    [SerializeField] private Color lowHealthColor;
    private int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = startingHealth;
        UpdateHealthbar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthbar();
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        currentHealth = startingHealth;
        UpdateHealthbar();
        transform.position = spawnPosition.position;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }

    private void UpdateHealthbar()
    {
        healthSlider.value = currentHealth;

        if (currentHealth <= 2)
        {
            image.color = lowHealthColor;
        }
        else
        {
            image.color = normalHealthColor;
        }
    }

    public bool RestoreHealth(int healthToRestore)
    {
        if (currentHealth >= startingHealth)
        {
            return false;
        }
        currentHealth += healthToRestore;
        UpdateHealthbar();

if(currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }

        return true;
    }
}
