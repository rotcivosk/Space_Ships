using UnityEngine;

public class BossController : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private BossPart[] bossParts;

    void Start()
    {
        currentHealth = maxHealth;

        // Get all BossPart components from children
        bossParts = GetComponentsInChildren<BossPart>();

        // Assign this BossController to each BossPart
        foreach (var part in bossParts)
        {
            part.SetBossController(this);
        }
    }

    // Method to handle damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Optionally, update a health bar UI here

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method called when any boss part dies
    public void Die()
    {
        // Destroy all parts
        foreach (var part in bossParts)
        {
            Destroy(part.gameObject);
        }

        // Notify the GameController that the boss has been defeated
        GameController.Instance.OnBossDefeated();

        // Destroy the boss object
        Destroy(gameObject);
    }
}
