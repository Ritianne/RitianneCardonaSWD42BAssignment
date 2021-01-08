using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> Waypoints;
    [SerializeField] ObstacleWave obstacleWave;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Get the list from ObstacleWave
        Waypoints = obstacleWave.GetWaypoints();

        transform.position = Waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        if (waypointIndex <= Waypoints.Count - 1)
        {
            var targetPosition = Waypoints[waypointIndex].transform.position;
            targetPosition.z = 0f;

            var movement = obstacleWave.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movement);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Set a wave config
    public void SetObstacleWave(ObstacleWave obstacleWaveToSet)
    {
        obstacleWave = obstacleWaveToSet;
    }
}
