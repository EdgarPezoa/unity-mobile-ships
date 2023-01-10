using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] GameObject Laser;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float minFireRateRND = .5f;
    [SerializeField] float maxFireRateRND = .5f;
    FireAudio fireAudio;

    private void Awake()
    {
        fireAudio = GetComponent<FireAudio>();
    }

    private void Start()
    {
        StartCoroutine(Fire());
    }

    //CUSTOM METHODS
    IEnumerator Fire()
    {
        while (true)
        {
            Instantiate(
                Laser,
                transform.position,
                Quaternion.identity
            );
            fireAudio.PlayLazerAudio();
            float tempTime = Random.Range(
            fireRate - minFireRateRND,
            fireRate + maxFireRateRND
        );
            yield return new WaitForSeconds(tempTime);
        }
    }
}
