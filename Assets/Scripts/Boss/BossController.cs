using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    [SerializeField] float maxHealthBoss = 1000;
    private float currentHealth;
    [SerializeField] Animator animatorLeftEye;
    private bool isAttacking = false;
    [SerializeField] private float attackInterval = 10f; 
    [SerializeField] Animator animatorRightEye;
    private bool isAttacking2 = false;
    [SerializeField] private float attackInterval2 = 10f; 
    private BossPart[] bossParts;
    void Start()
    {
        currentHealth = maxHealthBoss;

        // Get all BossPart components from children
        bossParts = GetComponentsInChildren<BossPart>();

        // Assign this BossController to each BossPart
        foreach (var part in bossParts)
        {
            part.SetBossController(this);
        }
        StartCoroutine(AttackRoutine());
        StartCoroutine(AttackRoutine2());
    }

    // Method to handle damage
    public void TakeDamageBoss(float damage)
    {
        currentHealth -= damage;

        // Optionally, update a health bar UI here

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Destroy all parts
        foreach (var part in bossParts)
        {
            Destroy(part.gameObject);
        }

        // Notify the GameController that the boss has been defeated
        GameController.Instance.OnBossDefeated();
        Destroy(gameObject);
    }
    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval);
            isAttacking = !isAttacking;
            animatorLeftEye.SetBool("isAttacking", isAttacking);
            yield return new WaitForSeconds(2f);

            // Turn off the attack
            isAttacking = false;
            animatorLeftEye.SetBool("isAttacking", isAttacking);
        }
    }
    private IEnumerator AttackRoutine2()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval2);
            isAttacking2 = !isAttacking2;
            animatorRightEye.SetBool("isAttacking", isAttacking2);
            yield return new WaitForSeconds(3f);

            // Turn off the attack
            isAttacking2 = false;
            animatorRightEye.SetBool("isAttacking", isAttacking2);
        }
    }
}
