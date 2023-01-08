using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Wave", order = 0)]
public class Wave : ScriptableObject
{
    [SerializeField] List<GameObject> enemys;
    [SerializeField] Transform path;
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float spawnGapTime = 1f;
    [SerializeField] float spawnTimeRNG = 0.1f;
    [SerializeField] float minSpawnTime = 0.2f;

    public Transform GetStartingWayPoint()
    {
        return path.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in path)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemys.Count;
    }

    public GameObject GetEnemy(int index)
    {
        return enemys[index];
    }

    public float GetRandomSpawnTime()
    {
        float tempTime = Random.Range(
            spawnGapTime - spawnTimeRNG,
            spawnGapTime + spawnTimeRNG
        );

        return Mathf.Clamp(tempTime, minSpawnTime, float.MaxValue);
    }
}
