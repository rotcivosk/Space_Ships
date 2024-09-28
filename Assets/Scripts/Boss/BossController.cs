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
    [SerializeField] private ParticleSystem deathParticles; // Sistema de partículas que será tocado na morte
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

    // Método para tratar o dano
    public void TakeDamageBoss(float damage)
    {
        currentHealth -= damage;

        // Opcionalmente, atualizar uma barra de vida aqui

        if (currentHealth <= 0)
        {
            Die();
        }
    }

public void Die()
{
    // Reproduzir o sistema de partículas de morte usando o ParticleManager
    if (deathParticles != null)
    {
        ParticleManager.Instance.PlayBossParticlesAndReturn(deathParticles);
    }

    // Destruir todas as partes do chefe
    foreach (var part in bossParts)
    {
        Destroy(part.gameObject);
    }

    // Notificar o GameController que o chefe foi derrotado
    GameController.Instance.OnBossDefeated();

    // Destruir o próprio chefe
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

            // Desativar o ataque
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

            // Desativar o ataque
            isAttacking2 = false;
            animatorRightEye.SetBool("isAttacking", isAttacking2);
        }
    }
}
