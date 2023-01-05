using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    [SerializeField] float laserSpeed = 15f;

    void Update()
    {
        Move();
    }

    //CUSTOM METHODS
    void Move()
    {
        Vector2 newPos = new Vector2();
        newPos.x = transform.position.x;
        newPos.y = transform.position.y + laserSpeed * Time.deltaTime;
        transform.position = newPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
