using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    Vector2 oldInput;
    Animator animator;
    Health health;
    enum AnimationPosition
    {
        IDDLE = 0,
        LEFT = -10,
        RIGHT = 10,
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }

    private void Start()
    {
        Vector2 startingPosition;
        startingPosition.x = transform.position.x;
        startingPosition.y = transform.position.y;
        rawInput = startingPosition;
        oldInput = startingPosition;
    }

    void Update()
    {
        if (rawInput.x != 0 && rawInput.y != 0)
        {
            MovePlayer();
        }
        else
        {
            Animate((int)AnimationPosition.IDDLE);
        }

    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        float gap = 1f;
        if (Mathf.Abs(oldInput.x - rawInput.x) >= 0 && Mathf.Abs(oldInput.x - rawInput.x) <= gap)
        {
            Animate((int)AnimationPosition.IDDLE);
        }
        else if (oldInput.x > rawInput.x)
        {
            Animate((int)AnimationPosition.LEFT);
        }
        else if (oldInput.x < rawInput.x)
        {
            Animate((int)AnimationPosition.RIGHT);
        }
        else
        {
            Animate((int)AnimationPosition.IDDLE);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            rawInput.y = rawInput.y + 32;
        }
        oldInput = rawInput;
    }

    //CUSTOM METHODS
    void MovePlayer()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(rawInput);
        newPos.z = 0;
        transform.position = newPos;
    }

    void Animate(int xPos)
    {
        animator.SetFloat("xPos", xPos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            health.DealDamage(enemy.GetBodyDamage());
            enemyHealth.DestroyGameObject();
        }
    }
}

