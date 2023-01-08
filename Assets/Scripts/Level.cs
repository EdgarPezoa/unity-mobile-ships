using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] List<Wave> waves;
    [SerializeField] float startLevelAt = 3f;
    [SerializeField] float waveGapTime = 0.5f;

    private void Start()
    {
        StartCoroutine(startWaves());
    }

    IEnumerator startWaves()
    {
        do
        {
            foreach (Wave wave in waves)
            {
                for (int i = 0; i < wave.GetEnemyCount(); i++)
                {
                    GameObject enemy = Instantiate(
                        wave.GetEnemy(i),
                        wave.GetStartingWayPoint().position,
                        Quaternion.identity,
                        transform
                    );

                    FollowPath enemyPath = enemy.GetComponent<FollowPath>();
                    enemyPath.setPaths(wave.GetWayPoints());
                    enemyPath.setMoveSpeed(wave.GetMoveSpeed());

                    yield return new WaitForSeconds(wave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(waveGapTime);
            }
        } while (true);
    }

}
