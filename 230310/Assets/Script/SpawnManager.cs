using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject targetPrefab_50m;
    public GameObject targetPrefab_100m;
    public GameObject targetPrefab_200m;

    [SerializeField]
    private TimeManager timeManager;

    private float spawnRate;
    private float timeAfterSpawn;
    private int[] targetPosition_randomX = new int[3];
    private int randomMin = -4;
    private int randomMax = 5;
    private int gameRound;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = 5f;
    }

    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }
        
        timeAfterSpawn += Time.deltaTime;

        gameRound = timeManager.gameRound;

        if (timeAfterSpawn >= spawnRate)
        {
            SetTargetPosition();
            SpawnTarget(gameRound);
            timeAfterSpawn = 0f;
        }
    }



    void SpawnTarget(int gameRound)
    {
        if (gameRound == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject target = Instantiate(targetPrefab_50m, new Vector3(targetPosition_randomX[i], 5f, 0), transform.rotation);
            }
        }
        else if (gameRound == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject target = Instantiate(targetPrefab_100m, new Vector3(targetPosition_randomX[i], 7f, 50), transform.rotation);
            }
        }
        else if (gameRound == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject target = Instantiate(targetPrefab_200m, new Vector3(targetPosition_randomX[i], 9f, 100), transform.rotation);
            }
        }
    }

    void SetTargetPosition()
    {
        do
        { 
            targetPosition_randomX[0] = Random.Range(randomMin, randomMax) * 10;
            targetPosition_randomX[1] = Random.Range(randomMin, randomMax) * 10;
            targetPosition_randomX[2] = Random.Range(randomMin, randomMax) * 10;
        }
        while (!((targetPosition_randomX[0] != targetPosition_randomX[1])
            && (targetPosition_randomX[0] != targetPosition_randomX[2])
            && (targetPosition_randomX[1] != targetPosition_randomX[2])));

    }
}
