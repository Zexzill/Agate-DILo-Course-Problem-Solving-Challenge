using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawnerProblem9 : MonoBehaviour
{
    public GameObject Obstacle;
    public Transform Canvas;
    private Dictionary<string, GameObject> _obstacleDictionary = new Dictionary<string, GameObject>();
    public float SpawnInterval = 2;

    //sama seperti box spawner, ini digunakan untuk pemberian index nama gameobject prefab
    private int _totalSpawnedObstacle = 0;

    private void Start()
    {
        InvokeRepeating("ObstaclePooling", SpawnInterval, SpawnInterval);
    }

    private void ObstaclePooling()
    {
        for (int i = 0; i < _obstacleDictionary.Count; i++)
        {
            if (_obstacleDictionary.ContainsKey($"obstacle {i}"))
            {
                GameObject objToSpawn = _obstacleDictionary[$"obstacle {i}"].gameObject;
                ObstacleProblem9 obstacle = objToSpawn.GetComponent<ObstacleProblem9>();

                if (!objToSpawn.activeSelf)
                {
                    objToSpawn.transform.localPosition = GetRandomPosition(obstacle);
                    objToSpawn.SetActive(true);

                    return;
                }
            }
        }
        InstantiateObstacle();
    }

    private void InstantiateObstacle()
    {
        GameObject spawnedObstacle = Instantiate(Obstacle, Canvas);
        spawnedObstacle.name = $"obstacle {_totalSpawnedObstacle}";
        _totalSpawnedObstacle++;

        _obstacleDictionary.Add(spawnedObstacle.name, spawnedObstacle);

        ObstacleProblem9 obstacle = spawnedObstacle.GetComponent<ObstacleProblem9>();

        spawnedObstacle.transform.localPosition = GetRandomPosition(obstacle);
    }

    private Vector2 GetRandomPosition(ObstacleProblem9 obstacle)
    {
        float height = 260;
        float width = 420;

        bool isHorizontal = Random.Range(0, 2) == 0 ? true : false;

        float randomWidthPosition = 0;
        float randomHeightPosition = 0;


        if(isHorizontal)
        {
            bool isLeft = Random.Range(0, 2) == 0 ? true : false;

            randomWidthPosition = isLeft ? -width : width;
            randomHeightPosition = Random.Range(-140, 140);

            if(isLeft)
            {
                obstacle.direction = Vector2.right;
            }
            else
            {
                obstacle.direction = Vector2.left;
            }
        }
        else
        {
            bool isUpper = Random.Range(0, 2) == 0 ? true : false;

            randomHeightPosition = isUpper ? height : -height;
            randomWidthPosition = Random.Range(-140, 140);

            if(isUpper)
            {
                obstacle.direction = Vector2.down;
            }
            else
            {
                obstacle.direction = Vector2.up;
            }
        }

        return new Vector2(randomWidthPosition, randomHeightPosition);
    }
}
