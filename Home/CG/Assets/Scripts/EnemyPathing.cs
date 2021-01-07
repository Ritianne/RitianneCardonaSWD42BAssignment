using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> tankWaypoints;
    [SerializeField] ObstacleWave obstacleWave;

    int tankWaypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Get the list from ObstacleWave
        tankWaypoints = obstacleWave.GetWaypoints();

        transform.position = tankWaypoints[tankWaypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        if (tankWaypointIndex <= tankWaypoints.Count - 1)
        {
            var targetPosition = tankWaypoints[tankWaypointIndex].transform.position;
            targetPosition.z = 0f;

            var tankMovement =  obstacleWave.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, tankMovement);

            if (transform.position == targetPosition)
            {
                tankWaypointIndex++;
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
