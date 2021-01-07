using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<ObstacleWave> obstacleWaveList;
    [SerializeField] bool looping = false;

    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            // Start coroutine that spawns all waves
            yield return StartCoroutine(SpawnAllWaves());
        }

        while (looping); // While looping == true
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllEnemiesInWave(ObstacleWave waveToSpawn)
    {
        for (int enemyCount = 1; enemyCount <= waveToSpawn.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
                            waveToSpawn.GetEnemyPrefab(),
                            waveToSpawn.GetWaypoints()[0].transform.position,
                            Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetObstacleWave(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach(ObstacleWave currentWave in obstacleWaveList)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}
