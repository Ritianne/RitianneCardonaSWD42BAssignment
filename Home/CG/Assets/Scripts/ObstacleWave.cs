using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]

public class ObstacleWave : ScriptableObject
{
    // The enemy that will spawn
    [SerializeField] GameObject enemyPrefab;

    // The path the wave will follow
    [SerializeField] GameObject pathPrefab;

    // Time between each enemy spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    // Random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;

    // Number of enemies in wave
    [SerializeField] int numberOfEnemies = 5;

    // The enemy's speed
    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        // Each wave has different waypoints
        var waveWayPoints = new List<Transform>();

        // Access pathPrefab and for each child add it to list waveWayPoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
}
