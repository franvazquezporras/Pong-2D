using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] powerUps;

    private float spawnTime = 1;
    private float coolDownSpawn = 10;



    private void Start()
    {
        InvokeRepeating("SpawnPowerUp", spawnTime, coolDownSpawn);
    }


    public void SpawnPowerUp()
    {
        Vector2 spawnPosition = new Vector2(0, 0);
        spawnPosition = new Vector2(Random.Range(gameObject.transform.position.x - 3, gameObject.transform.position.x + 3),
                                    Random.Range(gameObject.transform.position.y - 3, gameObject.transform.position.y + 3));

        GameObject powerUp = Instantiate(powerUps[0], spawnPosition, gameObject.transform.rotation);
    }
}
