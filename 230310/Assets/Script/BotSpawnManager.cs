using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotSpawnManager : MonoBehaviour
{
    public float spawnRate;
    public float timeAfterSpawn;

    [SerializeField]
    private GameObject enemyBot;

    void Start()
    {
        spawnRate = 2f;
        timeAfterSpawn = 0f;
        
    }

    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }
        
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            Spawn();
            
            timeAfterSpawn = 0f;
        }
    }

    private void Spawn()
    {
        GameObject bot = Instantiate(enemyBot, new Vector3(0, 1.5f, 45), transform.rotation);
    }
}
