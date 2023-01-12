using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] int maxHealth = 10;
    [SerializeField] bool isPlayer = false;
    [SerializeField] int scorePoints = 0;
    [SerializeField] int deathScorePoints = 0;
    [SerializeField] GameObject UI;
    Score score;
    DeathAudio deathAudio;
    CameraShake cameraShake;
    int health;

    private void Awake()
    {
        deathAudio = GetComponent<DeathAudio>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        UI = GameObject.Find("UI");
        score = UI.GetComponent<Score>();
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
        ShakeScreen();
        AddScore(scorePoints);
        if (health <= 0)
        {
            DestroyGameObject();

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

    void ShakeScreen()
    {
        if (isPlayer)
        {
            cameraShake.Play();
        }
    }

    void AddScore(int scorePoint)
    {
        if (!isPlayer)
        {
            score.AddScore(scorePoint);
        }
    }

    public void DestroyGameObject()
    {
        PlayHitEffect();
        AddScore(deathScorePoints);
        deathAudio.PlayDeathAudio();
        Destroy(gameObject);
    }
}
