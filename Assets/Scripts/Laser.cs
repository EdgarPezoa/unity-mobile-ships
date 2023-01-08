using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DIRECTION
{
    UP = 1,
    DOWN = -1
}

public class Laser : MonoBehaviour
{
    [SerializeField] float laserSpeed = 15f;
    [SerializeField] int damage = 3;
    [SerializeField] string harm = "Enemy";
    [SerializeField] DIRECTION direcction = DIRECTION.UP;

    void Update()
    {
        Move();
    }

    //CUSTOM METHODS
    void Move()
    {
        Vector2 newPos = new Vector2();
        newPos.x = transform.position.x;
        newPos.y = (transform.position.y + ((int)direcction * laserSpeed) * Time.deltaTime);
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            Destroy(gameObject);
            return;
        }
        if (other.tag == harm)
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            enemyHealth.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
