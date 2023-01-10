using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    Vector2 oldInput;
    Animator animator;
    enum AnimationPosition
    {
        IDDLE = 0,
        LEFT = -10,
        RIGHT = 10,
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
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
        oldInput = rawInput;
    }

    //CUSTOM METHODS
    void MovePlayer()
    {
        rawInput.y = rawInput.y;
        Vector3 newPos = Camera.main.ScreenToWorldPoint(rawInput);
        newPos.z = 0;
        transform.position = newPos;
    }

    void Animate(int xPos)
    {
        animator.SetFloat("xPos", xPos);
    }
}

