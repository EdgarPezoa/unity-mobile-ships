using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int bodyDamage = 0;

    public int GetBodyDamage()
    {
        return bodyDamage;
    }
}
