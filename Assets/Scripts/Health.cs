using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] ParticleSystem hitEffect;
    DeathAudio deathAudio;
    int health;

    private void Awake()
    {
        deathAudio = GetComponent<DeathAudio>();
    }

    private void Start()
    {
        Restore();
    }

    //CUSTOM METHODS
    public int getHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            PlayHitEffect();
            deathAudio.PlayDeathAudio();
        }
    }

    public void Heal(int heal)
    {
        health += heal;
        OverHealth();
    }

    public void Restore()
    {
        health = maxHealth;
    }

    void OverHealth()
    {

        if (health > maxHealth)
        {
            Restore();
        }
    }

    void PlayHitEffect()
    {
        ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }

}
