using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    int health;

    private void Start()
    {
        Restore();
    }

    //CUSTOM METHODS
    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
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

}
