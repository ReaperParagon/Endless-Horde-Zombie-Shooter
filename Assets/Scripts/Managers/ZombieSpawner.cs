using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public int numberOfZombiesPerSpawn = 3;
    public float spawnTimer = 2.0f;

    public GameObject[] zombiePrefabs;
    public SpawnerVolume[] spawnerVolumes;

    GameObject followGameObject;

    // Start is called before the first frame update
    void Start()
    {
        followGameObject = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(SpawnTimer_Coroutine());
    }

    private IEnumerator SpawnTimer_Coroutine()
    {
        for (int i = 0; i < numberOfZombiesPerSpawn; i++)
        {
            SpawnZombie();
        }

        yield return new WaitForSeconds(spawnTimer);

        StartCoroutine(SpawnTimer_Coroutine());
    }

    void SpawnZombie()
    {
        GameObject zombieToSpawn = zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];
        SpawnerVolume spawnVolume = spawnerVolumes[Random.Range(0, spawnerVolumes.Length)];

        if (!followGameObject) return;

        GameObject zombie = Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation, gameObject.transform);

        zombie.GetComponent<ZombieComponent>().Initialize(followGameObject);
    }
}
